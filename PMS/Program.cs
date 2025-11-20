using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PMS.Common.Middleware;
using PMS.Data;
using PMS.Data.Data;
using PMS.Data.Interface;
using PMS.Jwt;
using PMS.Repository;
using PMS.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PmsWriteDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WriteConnection")));

builder.Services.AddDbContext<PmsReadDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ReadConnection"))
           .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<PmsReadDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureAuthentication(builder.Configuration);

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IReadDbContext, PmsReadDbContext>();
builder.Services.AddScoped<IWriteDbContext, PmsWriteDbContext>();

builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddSingleton<Mapper>();

builder.Services.AddSwagerGenerator();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();

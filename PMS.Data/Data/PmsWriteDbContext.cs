using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PMS.Data.Interface;
using PMS.Data.Models;

namespace PMS.Data.Data;

public partial class PmsWriteDbContext : IdentityDbContext<IdentityUser>, IWriteDbContext
{

    public PmsWriteDbContext(DbContextOptions<PmsWriteDbContext> options)
        : base(options)
    {

    }

    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<CoverType> CoverTypes { get; set; } = null!;
    public virtual DbSet<Product> Products { get; set; } = null!;
    public virtual DbSet<Company> Companies { get; set; } = null!;
    public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;
    public virtual DbSet<OrderHeader> OrderHeaders { get; set; } = null!;
    public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}

//Add-Migration InitProduct -Context PmsWriteDbContext -StartupProject PMS -Project PMS.Data


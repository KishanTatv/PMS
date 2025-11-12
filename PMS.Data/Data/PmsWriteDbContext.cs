using Microsoft.EntityFrameworkCore;
using PMS.Data.Interface;
using PMS.Data.Models;

namespace PMS.Data.Data;

public partial class PmsWriteDbContext : DbContext, IWriteDbContext
{

    public PmsWriteDbContext(DbContextOptions<PmsWriteDbContext> options)
        : base(options)
    {

    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<CoverType> CoverTypes { get; set; } = null!;
    public virtual DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}

using Microsoft.EntityFrameworkCore;
using PMS.Data.Interface;
using PMS.Data.Models;

namespace PMS.Data.Data
{
    public class PmsReadDbContext : DbContext, IReadDbContext
    {
        public PmsReadDbContext(DbContextOptions<PmsReadDbContext> options)
            : base(options) { }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
            => throw new InvalidOperationException("Read context cannot modify data.");

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => throw new InvalidOperationException("Read context cannot modify data.");
    }
}

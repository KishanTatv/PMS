using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PMS.Data.Interface;
using PMS.Data.Models;

namespace PMS.Data.Data;

public partial class PmsWriteDbContext : DbContext, IWriteDbContext
{
    public PmsWriteDbContext()
    {
    }

    public PmsWriteDbContext(DbContextOptions<PmsWriteDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=WriteConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

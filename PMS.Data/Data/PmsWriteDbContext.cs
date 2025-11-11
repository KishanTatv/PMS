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
    public virtual DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=WriteConnection");

}

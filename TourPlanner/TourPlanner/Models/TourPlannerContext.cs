using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TourPlanner.Models;

public partial class TourPlannerContext : DbContext
{
    public TourPlannerContext()
    {
    }

    public TourPlannerContext(DbContextOptions<TourPlannerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Userdatum> Userdata { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=TourPlanner;Username=postgres;Password=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Userdatum>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("userdata_pkey");

            entity.ToTable("userdata");

            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
            entity.Property(e => e.Technology)
                .HasMaxLength(100)
                .HasColumnName("technology");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

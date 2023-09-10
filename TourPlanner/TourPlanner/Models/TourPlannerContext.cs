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

    public virtual DbSet<Tour> Tours { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=TourPlanner;Username=postgres;Password=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(e => e.Tourname).HasName("tours_pkey");

            entity.ToTable("tours");

            entity.Property(e => e.Tourname)
                .HasMaxLength(255)
                .HasColumnName("tourname");
            entity.Property(e => e.Tourdescription)
                .HasMaxLength(255)
                .HasColumnName("tourdescription");
            entity.Property(e => e.Tourdistance)
                .HasMaxLength(255)
                .HasColumnName("tourdistance");
            entity.Property(e => e.Tourfrom)
                .HasMaxLength(255)
                .HasColumnName("tourfrom");
            entity.Property(e => e.Tourrouteinformation)
                .HasMaxLength(255)
                .HasColumnName("tourrouteinformation");
            entity.Property(e => e.Tourtimeestimate)
                .HasMaxLength(255)
                .HasColumnName("tourtimeestimate");
            entity.Property(e => e.Tourto)
                .HasMaxLength(255)
                .HasColumnName("tourto");
            entity.Property(e => e.Tourtransporttype)
                .HasMaxLength(255)
                .HasColumnName("tourtransporttype");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

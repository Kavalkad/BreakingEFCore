using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace groupby.Models;

public class TopCCContext : DbContext
{
    public TopCCContext()
    {
    }

    public TopCCContext(DbContextOptions<TopCCContext> options)
        : base(options)
    {
    }

    public DbSet<CyberClub> CyberClubs { get; set; }

    public DbSet<GamingPlace> GamingPlaces { get; set; }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Computer> Computers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlite("Datasource=groupby.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CyberClub>(entity =>
        {
            entity.ToTable("cyberclubs");
            entity.Property(e => e.CyberClubId).HasColumnName("cyberclub_id").IsRequired();
            entity.Property(e => e.Name).HasColumnName("name_cyberclub");

            entity.HasKey(e => e.CyberClubId);

            entity.HasMany(e => e.Employees).WithOne(e => e.CyberClub);
            entity.HasMany(c => c.Places).WithOne(p => p.CyberClub);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);

            entity.ToTable("employees");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id").IsRequired();
            entity.Property(e => e.Name).HasColumnName("name_employee");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Salary).HasColumnName("salary").IsRequired();

            entity
            .HasOne(e => e.CyberClub)
            .WithMany(c => c.Employees)
            .HasForeignKey(e => e.CyberClubId);
        });
        modelBuilder.Entity<Computer>(entity =>
        {
            entity.ToTable("computer");

            entity.HasKey(e => e.ComputerId);
            entity.Property(e => e.Power).HasColumnName("power");
            entity.Property(e => e.VideoCard).HasColumnName("videocard");

            entity.HasMany(c => c.GamingPlaces).WithOne(e => e.Computer).HasForeignKey(e => e.ComputerId);


        });
        modelBuilder.Entity<GamingPlace>(entity =>
        {
            entity.HasKey(e => e.GamingPlaceId);
            entity.ToTable("gaming_places");

            
            entity.Property(e => e.IsOrdered).HasColumnName("is_ordered");

            entity.HasOne(gp => gp.CyberClub).WithMany(c => c.Places).HasForeignKey(gp => gp.CyberClubId);
            entity.HasOne(gp => gp.Computer).WithMany(c => c.GamingPlaces).HasForeignKey(gp => gp.ComputerId);
        });
    }

}

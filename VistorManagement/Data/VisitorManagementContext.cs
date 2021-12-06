using System;
using Microsoft.EntityFrameworkCore;
using VistorManagement.Models;

namespace VistorManagement.Data
{
    public class VisitorManagementContext : DbContext
    {
        public VisitorManagementContext(DbContextOptions<VisitorManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<StaffMember> StaffMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitor>().ToTable("Visitor");
            modelBuilder.Entity<Visit>().ToTable("Visit");
            modelBuilder.Entity<Building>().ToTable("Building");
            modelBuilder.Entity<Campus>().ToTable("Campus");
            modelBuilder.Entity<StaffMember>().ToTable("StaffMember");
        }
    }
}

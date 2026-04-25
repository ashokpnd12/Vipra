using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using Vipra.Domain.Entities;

namespace Vipra.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Panditji> Panditjis { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<PanditjiSpecialization> PanditjiSpecializations { get; set; }
        public DbSet<Yajman> Yajmans { get; set; }
        public DbSet<YajmanPanditji> YajmanPanditjis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // PanditjiSpecialization (Many-to-Many)
            modelBuilder.Entity<PanditjiSpecialization>()
                .HasKey(x => new { x.PanditjiId, x.SpecializationId });

            modelBuilder.Entity<PanditjiSpecialization>()
                .HasOne(x => x.Panditji)
                .WithMany(p => p.PanditjiSpecializations)
                .HasForeignKey(x => x.PanditjiId);

            modelBuilder.Entity<PanditjiSpecialization>()
                .HasOne(x => x.Specialization)
                .WithMany(s => s.PanditjiSpecializations)
                .HasForeignKey(x => x.SpecializationId);

            // YajmanPanditji (Many-to-Many)
            modelBuilder.Entity<YajmanPanditji>()
                .HasKey(x => new { x.PanditjiId, x.YajmanId });

            modelBuilder.Entity<YajmanPanditji>()
                .HasOne(x => x.Panditji)
                .WithMany(p => p.YajmanPanditjis)
                .HasForeignKey(x => x.PanditjiId);

            modelBuilder.Entity<YajmanPanditji>()
                .HasOne(x => x.Yajman)
                .WithMany(y => y.YajmanPanditjis)
                .HasForeignKey(x => x.YajmanId);

            modelBuilder.Entity<Panditji>()
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Panditji>()
                .Property(x => x.MobileNumber)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFGetStarted.AspNetCore.ExistingDb.Models
{
    public partial class collegeContext : DbContext
    {
        public collegeContext()
        {
        }

        public collegeContext(DbContextOptions<collegeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CollegeCost> CollegeCost { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\advicenttest;Database=college;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CollegeCost>(entity =>
            {
                entity.HasKey(e => e.CollegeId);

                entity.Property(e => e.CollegeId).HasColumnName("collegeID");

                entity.Property(e => e.College).HasMaxLength(100);

                entity.Property(e => e.RoomBoard).HasColumnName("Room___Board");

                entity.Property(e => e.TuitionInState).HasColumnName("Tuition__in_state_");

                entity.Property(e => e.TuitionOutOfState).HasColumnName("Tuition__out_of_state_");
            });
        }
    }
}

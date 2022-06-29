using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain_Test.Models
{
    public partial class TUserDBContext : DbContext
    {
        public TUserDBContext()
        {
        }

        public TUserDBContext(DbContextOptions<TUserDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TenantTable> TenantTables { get; set; } = null!;
        public virtual DbSet<UserTable> UserTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= DESKTOP-JDL1I2U\\SQLEXPRESS;Database= TUserDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TenantTable>(entity =>
            {
                entity.HasKey(e => e.TenantId)
                    .HasName("PK__TenantTa__2E9B4781C857E93C");

                entity.ToTable("TenantTable");

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Emaill)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TenantName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserTabl__1788CCACC3294B68");

                entity.ToTable("UserTable");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Emaill)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.UserTables)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK__UserTable__Tenan__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AuthorService.Models
{
    public partial class DigitalBooksContext : DbContext
    {
        public DigitalBooksContext()
        {
        }

        public DigitalBooksContext(DbContextOptions<DigitalBooksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Purchase> Purchases { get; set; } = null!;
        public virtual DbSet<RoleMaster> RoleMasters { get; set; } = null!;
        public virtual DbSet<UserTable> UserTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET802;Initial Catalog=DigitalBooks;User ID=sa;Password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.BookName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Content).HasColumnType("ntext");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PublishedDate).HasColumnType("date");

                entity.Property(e => e.Publisher)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Book__CategoryId__2C3393D0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Book__UserId__2D27B809");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.ToTable("Purchase");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMode)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseDate).HasColumnType("date");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__Purchase__BookId__300424B4");
            });

            modelBuilder.Entity<RoleMaster>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__RoleMast__8AFACE1A92A263EF");

                entity.ToTable("RoleMaster");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserTabl__1788CC4CE6DC2FA1");

                entity.ToTable("UserTable");

                entity.HasIndex(e => e.EmailId, "UQ__UserTabl__7ED91ACEDC47A0B2")
                    .IsUnique();

                entity.Property(e => e.EmailId)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(500);

                entity.Property(e => e.UserName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserTables)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__UserTable__RoleI__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

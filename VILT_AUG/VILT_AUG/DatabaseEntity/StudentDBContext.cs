using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VILT_AUG.DatabaseEntity
{
    public partial class StudentDBContext : DbContext
    {
        public StudentDBContext()
        {
        }

        public StudentDBContext(DbContextOptions<StudentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDepartment> TblDepartments { get; set; } = null!;
        public virtual DbSet<TblStudent> TblStudents { get; set; } = null!;
        public virtual DbSet<TblStudent1> TblStudents1 { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET802;Initial Catalog=StudentDB;User ID=sa;Password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblDepartment>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PK__tblDepar__0148818EEB0D8308");

                entity.ToTable("tblDepartments");

                entity.Property(e => e.DeptId)
                    .ValueGeneratedNever()
                    .HasColumnName("DeptID");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblStudent>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_Student");

                entity.Property(e => e.Grade).HasMaxLength(50);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.StudentName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblStudent1>(entity =>
            {
                entity.HasKey(e => e.StudId)
                    .HasName("PK__tblStude__F5C0A81F7CEA07F0");

                entity.ToTable("tblStudents");

                entity.Property(e => e.StudId)
                    .ValueGeneratedNever()
                    .HasColumnName("StudID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.TblStudent1s)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("FK__tblStuden__DeptI__276EDEB3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

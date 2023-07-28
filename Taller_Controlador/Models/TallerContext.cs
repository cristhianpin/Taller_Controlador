using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Taller_Controlador.Models;

public partial class TallerContext : DbContext
{
    public TallerContext()
    {
    }

    public TallerContext(DbContextOptions<TallerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Taller;Trusted_Connection=true;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__course__2AA84FD16708F92F");

            entity.ToTable("course");

            entity.Property(e => e.CourseId)
                .ValueGeneratedNever()
                .HasColumnName("courseId");
            entity.Property(e => e.CourseName)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("courseName");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__student__4D11D63C131621BF");

            entity.ToTable("student");

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnName("studentId");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

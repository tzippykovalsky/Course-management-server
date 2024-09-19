using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using management_cursesDL.EF.Models;

namespace management_cursesDL.EF.Contexts;

public partial class CoursesManagementContext : DbContext
{
    public CoursesManagementContext()
    {
    }

    public CoursesManagementContext(DbContextOptions<CoursesManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //לזכור לשנות למאובטח יותר
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=PC-ASUS\\MYSQL;Initial Catalog=CoursesManagementDB;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseCode).HasName("PK__courses__AB6B45F0B72F8259");

            entity.ToTable("courses");

            entity.Property(e => e.CourseCode)
                .ValueGeneratedNever()
                .HasColumnName("course_code");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CourseDuration).HasColumnName("course_duration");
            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("course_name");
            entity.Property(e => e.DirectorId).HasColumnName("director_id");
            entity.Property(e => e.SchooleCode).HasColumnName("schoole_code");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Director).WithMany(p => p.CourseDirectors)
                .HasForeignKey(d => d.DirectorId)
                .HasConstraintName("FK__courses__directo__403A8C7D");

            entity.HasOne(d => d.SchooleCodeNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.SchooleCode)
                .HasConstraintName("FK__courses__schoole__412EB0B6");

            entity.HasOne(d => d.Teacher).WithMany(p => p.CourseTeachers)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__courses__teacher__3F466844");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.RepId).HasName("PK__Reports__DC905AF4C92F787B");

            entity.Property(e => e.RepId)
                .ValueGeneratedNever()
                .HasColumnName("rep_id");
            entity.Property(e => e.DirectorId).HasColumnName("director_id");
            entity.Property(e => e.FormTime).HasColumnName("formTime");
            entity.Property(e => e.NumHours)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("numHours");
            entity.Property(e => e.ReportDate).HasColumnName("reportDate");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.ToTime).HasColumnName("toTime");
            entity.Property(e => e.Travel)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("travel");

            entity.HasOne(d => d.Director).WithMany(p => p.ReportDirectors)
                .HasForeignKey(d => d.DirectorId)
                .HasConstraintName("FK__Reports__directo__47DBAE45");

            entity.HasOne(d => d.Teacher).WithMany(p => p.ReportTeachers)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__Reports__teacher__46E78A0C");
        });

        modelBuilder.Entity<School>(entity =>
        {
            entity.HasKey(e => e.SchooleCode).HasName("PK__schools__27FE222AE89B352F");

            entity.ToTable("schools");

            entity.Property(e => e.SchooleCode)
                .ValueGeneratedNever()
                .HasColumnName("schoole_code");
            entity.Property(e => e.Adress)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("adress");
            entity.Property(e => e.DirectorId).HasColumnName("director_id");
            entity.Property(e => e.SchooleName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("schoole_name");

            entity.HasOne(d => d.Director).WithMany(p => p.Schools)
                .HasForeignKey(d => d.DirectorId)
                .HasConstraintName("FK__schools__directo__3C69FB99");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.IdNumber).HasName("PK__students__D58CDE10C7C0DAC0");

            entity.ToTable("students");

            entity.Property(e => e.IdNumber)
                .ValueGeneratedNever()
                .HasColumnName("id_number");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.CourseCode).HasColumnName("course_code");
            entity.Property(e => e.Grade)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("grade");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");

            entity.HasOne(d => d.CourseCodeNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.CourseCode)
                .HasConstraintName("FK__students__course__440B1D61");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__B9BE370F1235E112");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UQ__users__AB6E616412237381").IsUnique();

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.Adress)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("adress");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PayLesson)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("pay_lesson");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Role).HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

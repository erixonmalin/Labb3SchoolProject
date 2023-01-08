using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Labb3SchoolProject.Models;

namespace Labb3SchoolProject.Data
{
    public partial class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
        {
        }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<OngoingCourse> OngoingCourses { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentGrade> StudentGrades { get; set; } = null!;
        public virtual DbSet<StudentInformation> StudentInformations { get; set; } = null!;
        public virtual DbSet<TeacherPosition> TeacherPositions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-7LJQQL26; Initial Catalog=SchoolOfRock; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseName).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Department).HasMaxLength(25);

                entity.Property(e => e.EmploymentDate).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Position)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TeacherPosition)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(e => e.GradeLevel)
                    .HasName("PK_Grade_1");

                entity.ToTable("Grade");

                entity.Property(e => e.GradeLevel).ValueGeneratedNever();
            });

            modelBuilder.Entity<OngoingCourse>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OngoingCourses");

                entity.Property(e => e.CourseId).ValueGeneratedOnAdd();

                entity.Property(e => e.CourseName).HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PersonalNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentGrade>(entity =>
            {
                entity.ToTable("StudentGrade");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.FkCourseId).HasColumnName("FK_CourseId");

                entity.Property(e => e.FkEmployeeId).HasColumnName("FK_EmployeeId");

                entity.Property(e => e.FkGradeLevelId).HasColumnName("FK_GradeLevelId");

                entity.Property(e => e.FkStudentId).HasColumnName("FK_StudentId");

                entity.HasOne(d => d.FkCourse)
                    .WithMany(p => p.StudentGrades)
                    .HasForeignKey(d => d.FkCourseId)
                    .HasConstraintName("FK_StudentGrade_Course");

                entity.HasOne(d => d.FkEmployee)
                    .WithMany(p => p.StudentGrades)
                    .HasForeignKey(d => d.FkEmployeeId)
                    .HasConstraintName("FK_StudentGrade_Employee");

                entity.HasOne(d => d.FkGradeLevel)
                    .WithMany(p => p.StudentGrades)
                    .HasForeignKey(d => d.FkGradeLevelId)
                    .HasConstraintName("FK_StudentGrade_Grade");

                entity.HasOne(d => d.FkStudent)
                    .WithMany(p => p.StudentGrades)
                    .HasForeignKey(d => d.FkStudentId)
                    .HasConstraintName("FK_StudentGrade_Student");
            });

            modelBuilder.Entity<StudentInformation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("StudentInformation");

                entity.Property(e => e.Course).HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Student).HasMaxLength(81);

                entity.Property(e => e.Teacher).HasMaxLength(71);
            });

            modelBuilder.Entity<TeacherPosition>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TeacherPositions");

                entity.Property(e => e.TeacherPosition1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TeacherPosition")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

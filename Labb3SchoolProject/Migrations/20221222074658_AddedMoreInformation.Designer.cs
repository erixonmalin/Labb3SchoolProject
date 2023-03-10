// <auto-generated />
using System;
using Labb3SchoolProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb3SchoolProject.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20221222074658_AddedMoreInformation")]
    partial class AddedMoreInformation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Labb3SchoolProject.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"), 1L, 1);

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CourseId");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("Labb3SchoolProject.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<string>("Department")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("char(25)")
                        .IsFixedLength();

                    b.HasKey("EmployeeId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("Labb3SchoolProject.Models.Grade", b =>
                {
                    b.Property<int>("GradeLevel")
                        .HasColumnType("int");

                    b.HasKey("GradeLevel")
                        .HasName("PK_Grade_1");

                    b.ToTable("Grade", (string)null);
                });

            modelBuilder.Entity("Labb3SchoolProject.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("Labb3SchoolProject.Models.StudentGrade", b =>
                {
                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("FkCourseId")
                        .HasColumnType("int")
                        .HasColumnName("FK_CourseId");

                    b.Property<int?>("FkEmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("FK_EmployeeId");

                    b.Property<int?>("FkGradeLevelId")
                        .HasColumnType("int")
                        .HasColumnName("FK_GradeLevelId");

                    b.Property<int?>("FkStudentId")
                        .HasColumnType("int")
                        .HasColumnName("FK_StudentId");

                    b.HasIndex("FkCourseId");

                    b.HasIndex("FkEmployeeId");

                    b.HasIndex("FkGradeLevelId");

                    b.HasIndex("FkStudentId");

                    b.ToTable("StudentGrade", (string)null);
                });

            modelBuilder.Entity("Labb3SchoolProject.Models.StudentGrade", b =>
                {
                    b.HasOne("Labb3SchoolProject.Models.Course", "FkCourse")
                        .WithMany()
                        .HasForeignKey("FkCourseId")
                        .HasConstraintName("FK_StudentGrade_Course");

                    b.HasOne("Labb3SchoolProject.Models.Employee", "FkEmployee")
                        .WithMany()
                        .HasForeignKey("FkEmployeeId")
                        .HasConstraintName("FK_StudentGrade_Employee");

                    b.HasOne("Labb3SchoolProject.Models.Grade", "FkGradeLevel")
                        .WithMany()
                        .HasForeignKey("FkGradeLevelId")
                        .HasConstraintName("FK_StudentGrade_Grade");

                    b.HasOne("Labb3SchoolProject.Models.Student", "FkStudent")
                        .WithMany()
                        .HasForeignKey("FkStudentId")
                        .HasConstraintName("FK_StudentGrade_Student");

                    b.Navigation("FkCourse");

                    b.Navigation("FkEmployee");

                    b.Navigation("FkGradeLevel");

                    b.Navigation("FkStudent");
                });
#pragma warning restore 612, 618
        }
    }
}

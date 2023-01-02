using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb3SchoolProject.Migrations
{
    public partial class AddedMoreInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Position = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    GradeLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade_1", x => x.GradeLevel);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersonalNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "StudentGrade",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    FK_GradeLevelId = table.Column<int>(type: "int", nullable: true),
                    FK_CourseId = table.Column<int>(type: "int", nullable: true),
                    FK_EmployeeId = table.Column<int>(type: "int", nullable: true),
                    FK_StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_StudentGrade_Course",
                        column: x => x.FK_CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId");
                    table.ForeignKey(
                        name: "FK_StudentGrade_Employee",
                        column: x => x.FK_EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_StudentGrade_Grade",
                        column: x => x.FK_GradeLevelId,
                        principalTable: "Grade",
                        principalColumn: "GradeLevel");
                    table.ForeignKey(
                        name: "FK_StudentGrade_Student",
                        column: x => x.FK_StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrade_FK_CourseId",
                table: "StudentGrade",
                column: "FK_CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrade_FK_EmployeeId",
                table: "StudentGrade",
                column: "FK_EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrade_FK_GradeLevelId",
                table: "StudentGrade",
                column: "FK_GradeLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrade_FK_StudentId",
                table: "StudentGrade",
                column: "FK_StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentGrade");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}

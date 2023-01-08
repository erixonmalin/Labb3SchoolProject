using Labb3SchoolProject.Data;
using Labb3SchoolProject.Models;

namespace Labb3SchoolProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Menu for user options
            OptionsMenu.MainMenu();


            //SQL-Query From SSMS

            //--Hämta översikt på personalen
            //SELECT FirstName + ' ' + LastName AS Employee, Position, DATEDIFF (year, EmploymentDate, GETDATE()) AS 'YearsOfEmployment'
            //FROM Employee

            //--------------------------------------------------------------
            //--Spara ner ny personal 
            //INSERT INTO Employee(FirstName, LastName, Position, Department, Salary, EmploymentDate)
            //VALUES('Olaf', 'Snowman', 'Student guard', 'Student assistant', 15000, '2023-01-02');

            //--------------------------------------------------------------
            //--Spara ner ny elev 
            //INSERT INTO Student(FirstName, LastName, PersonalNumber, [Year])
            //VALUES('Elsa', 'Frozen', 18910113 - 3447, 1);

            //---------------------------------------------------------------------
            //--Hämta alla betyg som satts(Lista med elevens namn, kursens namn, betyg, datum, lärare).
            //SELECT Student.FirstName + ' ' + Student.LastName AS Student, CourseName AS Course, GradeLevel AS Grade, Date, Employee.FirstName + ' ' + Employee.LastName AS Teacher
            //FROM Student, StudentGrade, Course, Grade, Employee
            //WHERE Student.StudentId = StudentGrade.FK_StudentId AND
            //Grade.GradeLevel = StudentGrade.FK_GradeLevelId AND
            //Course.CourseId = StudentGrade.FK_CourseId AND
            //Employee.EmployeeId = StudentGrade.FK_EmployeeId

            //----------------------------------------------------------------------
            //--View skapad -Hur många lärare arbetar på de olika avdelningarna(speciallärare, vanliga lärare, assistenter)
            //CREATE VIEW[TeacherPositions] AS
            //SELECT Employee.TeacherPosition, COUNT(Employee.TeacherPosition) AS 'Number'
            //FROM Employee
            //WHERE TeacherPosition = 'Special' OR TeacherPosition = 'Regular' OR TeacherPosition = 'Assistant'
            //GROUP BY TeacherPosition

            //--Kallar på View Table -TeacherPositions
            //SELECT* FROM TeacherPositions

            //--------------------------------------------------------------
            //--View skapad-Visa info om alla elever
            //CREATE VIEW StudentInformation AS
            //SELECT Student.FirstName + ' ' + Student.LastName AS Student, CourseName AS Course, GradeLevel AS Grade, Date, Employee.FirstName + ' ' + Employee.LastName AS Teacher
            //FROM Student, StudentGrade, Course, Grade, Employee
            //WHERE Student.StudentId = StudentGrade.FK_StudentId AND
            //Grade.GradeLevel = StudentGrade.FK_GradeLevelId AND
            //Course.CourseId = StudentGrade.FK_CourseId AND
            //Employee.EmployeeId = StudentGrade.FK_EmployeeId

            //--Kallar på View Table -StudentInformation
            //SELECT* FROM StudentInformation

            //----------------------------------------------------------
            //--View skapad-Visa lista på alla aktiva kurser
            //CREATE VIEW OngoingCourses AS

            //--Kalla på View Table -OngoingCourses
            //SELECT* FROM Course

            //--------------------------------------------------------------
            //--Total lön för varje avdelning
            //SELECT SUM(Salary) AS 'Monthly Salary, SEK', Department
            //FROM Employee
            //WHERE Salary > 0
            //GROUP BY Department
            //-------------------------------------------------------------- -
            //--Medelön per avdelning
            //SELECT AVG(Salary) AS 'Average Salary, SEK', Department
            //FROM Employee
            //WHERE Salary > 0
            //GROUP BY Department

            //---------------------------------------------------------------- -
            //--Stored Procedure som tar emot ett Id och returnerar viktig information om den elev som är registrerad med aktuellt id
            //CREATE PROCEDURE GetStudInfo
            //(
            //@StudentId int
            //)
            //AS
            //SELECT* FROM Student WHERE StudentId = @StudentId
            //GO

            //--Kör stored proceduren ovan
            //EXEC GetStudInfo @StudentId = 1

            //------------------------------------------------------------------------------
            //--Sätt betyg på en elev genom att använda Transactions ifall något går fel
            // Begin try
            //Begin Transaction TranGrade
            //Insert into StudentGrade(Date, FK_GradeLevelId, FK_CourseId, FK_EmployeeId, FK_StudentId)
            //Values('2022-12-01', 3, 1, 4, 23)
            //Print 'Successfull'
            //Commit transaction
            //End Try


            //BEGIN CATCH
            //ROLLBACK TRANSACTION TranGrade
            //Print 'Not successfull'
            //END CATCH

            //--Se så att betyget finns lagrat i databasen
            //Select* From StudentGrade
        }
    }
}
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

            //--Hämta personal (all personal eller bara från en kategori).
            //Select* From Employee  -> Visar alla anställda

            //Select* From Employee
            //Where Position = 'Cleaner' -> Välj här vilken kategori som ska hämtas

            //----------------------------------------------
            //--Hämta alla betyg som satts den senaste månaden (Lista med elevens namn, kursens namn, betyg, datum).
            //Select FirstName, LastName, CourseName, GradeLevel, Date
            //From Student, StudentGrade, Course, Grade
            //Where Student.StudentId = StudentGrade.FK_StudentId AND
            //Grade.GradeLevel = StudentGrade.FK_GradeLevelId AND
            //Course.CourseId = StudentGrade.FK_CourseId AND Date > '2022-11-19'

            //----------------------------------------------
            //--Hämta en lista med alla kurser och det snittbetyg som eleverna fått på den kursen samt det högsta och lägsta betyget som någon fått i kursen.
            //Select Course.CourseName, AVG(StudentGrade.FK_GradeLevelId) AS 'Average grade',
            //MIN(StudentGrade.FK_GradeLevelId) AS 'Lowest grade', MAX(StudentGrade.FK_GradeLevelId) AS 'Highest grade'
            //From StudentGrade
            //FULL JOIN Course ON Course.CourseId = StudentGrade.FK_CourseId
            //GROUP BY CourseName
        }
    }
}
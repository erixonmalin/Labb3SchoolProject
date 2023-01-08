using Labb3SchoolProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3SchoolProject.Models
{
    public class OptionsMenu
    {
        public static void MainMenu()
        {
            string exit;
            do
            {
                string input;
                Console.WriteLine("\nPlease, choose an option:\n" +
                                  "\n1 = See all students\n" +
                                  "2 = See all student in a class\n" +
                                  "3 = See student information\n" +
                                  "4 = See active courses\n" +
                                  "5 = See number of teachers in all the departments\n" +
                                  "6 = Add new staff\n" +
                                  "7 = Add new student\n" +
                                  "8 = Exit program\n");

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        OptionSeeAllStudents();
                        break;

                    case "2":
                        OptionSeeClass();
                        break;

                    case "3":
                        SeeStudentInfo();
                        break;
 
                    case "4":
                        SeeActiveCourses();
                        break;

                    case "5":
                        SeeTeacherInfo();
                        break;

                    case "6":
                        AddNewStaff();
                        break;

                    case "7":
                        AddNewStudent();
                        break;

                    case "8":
                        Console.WriteLine("Please confirm with entering 'Exit' to close the program.");
                        break;

                    default:
                        Console.WriteLine("\nNot a valid choice.");
                        break;
                }
                Console.WriteLine("\nPush enter if you want to see the menu.\n" +
                    "Push 'exit' to close the program.");
                exit = Console.ReadLine();
            } while (exit.ToLower() != "exit");
        }

        public static void OptionSeeAllStudents()
        {
            Console.Clear();
            string input = "";
            Console.WriteLine("Please, choose an option for how you want to order the list of students.\n" +
                              "\n1 = Sort by first name\n" +
                              "2 = Sort by last name\n" +
                              "3 = Exit");

            while (!input.ToLower().Equals("3"))
            {
                input = Console.ReadLine();
                Console.Clear();

                if (input == "1")
                {
                    using (var context = new SchoolDbContext())
                    {
                        var allStudents = context.Students.OrderBy(s => s.FirstName);

                        foreach (var student in allStudents)
                        {
                            Console.WriteLine(student.FirstName + " " + student.LastName);
                        }

                        Console.WriteLine("\nWould you like the list sorted by descending? Please enter 1.\n" +
                                          "Press 3 to go back.\n");

                        input = Console.ReadLine();

                        if (input == "1")
                        {
                            Console.Clear();
                            var myStudentss = context.Students.OrderByDescending(s => s.FirstName);

                            foreach (var student in myStudentss)
                            {
                                Console.WriteLine(student.FirstName + " " + student.LastName);
                            }
                            Console.WriteLine("\nPress 1 to sort the list by ascending.\n" +
                                              "Press 3 to go back.");
                        }
                        else if (input != "1")
                        {
                            Console.Clear();
                            var myStudentss = context.Students.OrderBy(s => s.FirstName);

                            foreach (var student in myStudentss)
                            {
                                Console.WriteLine(student.FirstName + " " + student.LastName);
                            }
                        }
                        else if (input == "3")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid choice");
                        }
                    }
                }

                else if (input == "2")
                {
                    using (var context = new SchoolDbContext())
                    {
                        var myStudents = context.Students.OrderBy(s => s.LastName);

                        foreach (var student in myStudents)
                        {
                            Console.WriteLine(student.LastName + " " + student.FirstName);
                        }

                        Console.WriteLine("\nWould you like the list sorted by descending? Please enter 1.\n" +
                                          "Press 3 to go back.\n");

                        input = Console.ReadLine();

                        if (input == "1")
                        {
                            Console.Clear();
                            var myStudentss = context.Students.OrderByDescending(s => s.LastName);

                            foreach (var student in myStudentss)
                            {
                                Console.WriteLine(student.LastName + " " + student.FirstName);
                            }
                            Console.WriteLine("\nPress 1 to sort the list by ascending.\n" +
                                              "Press 3 to go back.");
                        }
                        else if (input != "1")
                        {
                            Console.Clear();
                            var myStudentss = context.Students.OrderBy(s => s.LastName);

                            foreach (var student in myStudentss)
                            {
                                Console.WriteLine(student.LastName + " " + student.FirstName);
                            }
                        }
                    }
                }
                else if (input == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid choice");
                }
            }
        }

        public static void OptionSeeClass()
        {
            int inputChoice;
            Console.Clear();
            Console.WriteLine("Please, choose a class from the list\n" +
                              "1 = Year 1\n" +
                              "2 = Year 2\n" +
                              "3 = Year 3\n");

            inputChoice = int.Parse(Console.ReadLine());
            Console.Clear();
            using (var context = new SchoolDbContext())
            {
                var classes = from Student in context.Students
                              where Student.Year == inputChoice
                              orderby Student.LastName
                              select Student;

                foreach (var student in classes)
                {
                    Console.WriteLine($"Year: {student.Year}, {student.FirstName} {student.LastName}");
                }
            }
        }

        public static void SeeStudentInfo()
        {
            using (var context = new SchoolDbContext())
            {
                var studentInfo = from s in context.StudentInformations
                                 select s;
                Console.Clear();
                foreach (var studInfo in studentInfo)
                {
                    Console.WriteLine($"Student: {studInfo.Student}, , Course: {studInfo.Course}, Grade: {studInfo.Grade} \nTeacher: {studInfo.Teacher} Date: {studInfo.Date}\n");
                }
            }
        }

        public static void SeeActiveCourses()
        {
            using (var context = new SchoolDbContext())
            {
                var allCourses = from c in context.OngoingCourses
                                      select c;
                Console.Clear();
                foreach (var courses in allCourses)
                {
                    Console.WriteLine($"Course id: {courses.CourseId}, Course name: {courses.CourseName}");
                }
            }
        }

        public static void SeeTeacherInfo()
        {
            using (var context = new SchoolDbContext())
            {
                var teacherPosition = from t in context.TeacherPositions
                                      select t;
                Console.Clear();
                foreach (var teacher in teacherPosition)
                {
                    Console.WriteLine($"{teacher.TeacherPosition1} {teacher.Number}");
                }
            }
        }

        public static void AddNewStaff()
        {
            using SchoolDbContext context = new SchoolDbContext();
            Employee newEmployee = new Employee();
            string addMore;

            do
            {
                Console.Clear();
                Console.WriteLine("Please enter information to add new staff in the system.\n");
                Console.WriteLine("First name: ");
                newEmployee.FirstName = Console.ReadLine();

                Console.WriteLine("Last name: ");
                newEmployee.LastName = Console.ReadLine();

                Console.WriteLine("\nPosition: ");
                newEmployee.Position = Console.ReadLine();

                Console.WriteLine("Department: ");
                newEmployee.Department = Console.ReadLine();

                context.Employees.Add(newEmployee);
                context.SaveChanges();
                Console.WriteLine($"\nDatabase updated with new staff: {newEmployee.FirstName} {newEmployee.LastName}, {newEmployee.Position}.");

                Console.WriteLine("\nWould you like to add new staff, enter 1. \n" +
                                  "Exit, enter 2.");
                addMore = Console.ReadLine();

            } while (addMore == "1");
        }

        public static void AddNewStudent()
        {
            using SchoolDbContext context = new SchoolDbContext();
            Student newStudent = new Student();
            string addMore;

            do
            {
                Console.Clear();
                Console.WriteLine("Please enter information to add new staff in the system.\n");
                Console.WriteLine("First name: ");
                newStudent.FirstName = Console.ReadLine();

                Console.WriteLine("Last name: ");
                newStudent.LastName = Console.ReadLine();

                Console.WriteLine("\nPersonal number: ");
                newStudent.PersonalNumber = Console.ReadLine();

                Console.WriteLine("Year: ");
                newStudent.Year = int.Parse(Console.ReadLine());

                context.Students.Add(newStudent);
                context.SaveChanges();
                Console.WriteLine($"\nDatabase updated with new student: {newStudent.FirstName} {newStudent.LastName}, Personal number: {newStudent.PersonalNumber}, Year: {newStudent.Year}.");

                Console.WriteLine("\nWould you like to add another student, enter 1. \n" +
                                  "Exit, enter 2.");
                addMore = Console.ReadLine();

            } while (addMore == "1");
        }
    }
}

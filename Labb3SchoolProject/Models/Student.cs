using System;
using System.Collections.Generic;

namespace Labb3SchoolProject.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentGrades = new HashSet<StudentGrade>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PersonalNumber { get; set; } = null!;
        public int Year { get; set; }

        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
    }
}

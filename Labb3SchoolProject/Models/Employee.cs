using System;
using System.Collections.Generic;

namespace Labb3SchoolProject.Models
{
    public partial class Employee
    {
        public Employee()
        {
            StudentGrades = new HashSet<StudentGrade>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string Department { get; set; } = null!;
        public int Salary { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string? TeacherPosition { get; set; }

        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
    }
}

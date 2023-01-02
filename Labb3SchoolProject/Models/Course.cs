using System;
using System.Collections.Generic;

namespace Labb3SchoolProject.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentGrades = new HashSet<StudentGrade>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;

        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
    }
}

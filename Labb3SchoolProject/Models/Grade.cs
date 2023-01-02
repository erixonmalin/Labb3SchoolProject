using System;
using System.Collections.Generic;

namespace Labb3SchoolProject.Models
{
    public partial class Grade
    {
        public Grade()
        {
            StudentGrades = new HashSet<StudentGrade>();
        }

        public int GradeLevel { get; set; }

        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
    }
}

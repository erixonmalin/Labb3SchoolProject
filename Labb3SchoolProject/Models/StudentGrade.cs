using System;
using System.Collections.Generic;

namespace Labb3SchoolProject.Models
{
    public partial class StudentGrade
    {
        public DateTime? Date { get; set; }
        public int? FkGradeLevelId { get; set; }
        public int? FkCourseId { get; set; }
        public int? FkEmployeeId { get; set; }
        public int? FkStudentId { get; set; }

        public virtual Course? FkCourse { get; set; }
        public virtual Employee? FkEmployee { get; set; }
        public virtual Grade? FkGradeLevel { get; set; }
        public virtual Student? FkStudent { get; set; }
    }
}

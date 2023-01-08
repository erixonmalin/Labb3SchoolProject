using System;
using System.Collections.Generic;

namespace Labb3SchoolProject.Models
{
    public partial class StudentInformation
    {
        public string Student { get; set; } = null!;
        public string Course { get; set; } = null!;
        public int Grade { get; set; }
        public DateTime? Date { get; set; }
        public string Teacher { get; set; } = null!;
    }
}

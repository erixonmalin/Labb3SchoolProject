using System;
using System.Collections.Generic;

namespace Labb3SchoolProject.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PersonalNumber { get; set; } = null!;
        public int Year { get; set; }
    }
}

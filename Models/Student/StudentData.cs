using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication12.Models.Student
{
    public class StudentData
    {
        [Key, Column(Order = 0)]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }

    public class SudentDetails
    {
        [Key, Column(Order = 0)]
        public int StudentId { get; set; }

        public string StudentSchool { get; set; }
    }
}
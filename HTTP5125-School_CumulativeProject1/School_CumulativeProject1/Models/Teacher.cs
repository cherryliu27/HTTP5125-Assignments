using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_CumulativeProject1.Models
{
    public class Teacher
    {
        public int TeacherId {  get; set; }

        public string TeacherFname {  get; set; }

        public string TeacherLname {  get; set; }

        public string EmployeeNo { get; set; }

        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }
    }
}
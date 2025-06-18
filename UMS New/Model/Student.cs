using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UUMS_New.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string UT_Number { get; set; }
        public string Phone_Number { get; set; }
        public string Email { get; set; }

        public int UserID { get; set; }

        public int CourseID { get; set; }
    }
}
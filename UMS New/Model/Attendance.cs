using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS_New.Model
{
    internal class Attendance
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public string Date { get; set; }   // Format: "yyyy-MM-dd"
        public string Status { get; set; } // Present / Absent / Leave
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS_New.Model
{
    internal class Marks
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public int Mark { get; set; }
        public string Grade { get; set; } // Optional
    }
}

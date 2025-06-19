using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS_New.Model
{
    internal class Subject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
        public int CourseID { get; set; }
    }
}

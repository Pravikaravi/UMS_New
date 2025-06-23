using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS_New.Model
{
    internal class FeedbackForm
    {
        public int Id { get; set; }
        public string StudentID { get; set; }
        public string UT_Number { get; set; }
        public string SubjectID { get; set; }
        public string Feedback_Type { get; set; }

        public string Feedback { get; set; }
    }
}

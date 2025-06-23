
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS_New.Model
{
    internal class StudyMaterial
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public string UploadDate { get; set; }

        public int CourseID { get; set; }
        public int SubjectID { get; set; }
        public int LecturerID { get; set; }
    }
}

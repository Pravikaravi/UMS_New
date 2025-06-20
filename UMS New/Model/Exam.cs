using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS_New.Model
{
    internal class Exam
    {
        public int Id { get; set; }                // Exam ID primary key
        public string ExamName { get; set; }      // Exam title/name
        public DateTime ExamDate { get; set; }    // Date of the exam
        public TimeSpan StartTime { get; set; }   // Start time of the exam
        public int DurationMinutes { get; set; }  // Duration in minutes
        public int RoomId { get; set; }            // FK to Room table

        public int SubjectId { get; set; }         // FK to Subject table
        // Optional: You can add Subject object if you want to hold full subject details
        // public Subject AssignedSubject { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using UMS_New.Controller;
using UMS_New.Data;
using UMS_New.Model;

namespace UMS_New.Views.AdminDashboardFiles
{
    public partial class AddAttendance : UserControl
    {
        public AddAttendance()
        {
            InitializeComponent();
        }

        // 🔽 Method 1: GetSubjectsByCourse
        private List<Subject> GetSubjectsByCourse(int courseId)
        {
            var subjects = new List<Subject>();
            using (var conn = DBConfig.GetConnection())
            {
                string query = "SELECT * FROM Subject WHERE CourseID = @courseId";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@courseId", courseId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subjects.Add(new Subject
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                SubjectName = reader["SubjectName"].ToString(),
                                Description = reader["Description"].ToString(),
                                CourseID = Convert.ToInt32(reader["CourseID"])
                            });
                        }
                    }
                }
                conn.Close();
            }
            return subjects;
        }

        // 🔽 Method 2: GetStudentsByCourse (Fixed)
        private List<Student> GetStudentsByCourse(int courseId)
        {
            var students = new List<Student>();
            using (var conn = DBConfig.GetConnection())
            {
                string query = "SELECT * FROM Student WHERE CourseID = @courseId"; // Fetch students by CourseID
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@courseId", courseId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(new Student
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                StudentName = reader["StudentName"].ToString(),
                                UT_Number = reader["UT_Number"].ToString(),
                                Phone_Number = reader["Phone_Number"].ToString(),
                                Email = reader["Email"].ToString(),
                                UserID = Convert.ToInt32(reader["UserID"]),
                                CourseID = Convert.ToInt32(reader["CourseID"])
                            });
                        }
                    }
                }
                conn.Close();
            }
            return students;
        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Make sure something is selected and it’s a valid int
            if (cmbCourse.SelectedValue != null && int.TryParse(cmbCourse.SelectedValue.ToString(), out int courseId))
            {
                // Load subjects related to the selected course
                cmbSubject.DataSource = GetSubjectsByCourse(courseId);
                cmbSubject.DisplayMember = "SubjectName";
                cmbSubject.ValueMember = "Id";
            }
        }

        //  Load Courses and Setup ComboBox
        private void AddAttendance_Load(object sender, EventArgs e)
        {
            // Load courses from DB
            cmbCourse.DataSource = GetCoursesFromDB();
            cmbCourse.DisplayMember = "CourseName";
            cmbCourse.ValueMember = "Id";
        }

        private void dtpAttendanceDate_ValueChanged(object sender, EventArgs e)
        {
            // Get the new selected date in the correct format
            string selectedDate = dtpAttendanceDate.Value.ToString("yyyy-MM-dd");

            // Debug: Check if the date change is being detected
            Console.WriteLine($"Date changed to: {selectedDate}");

            // Clear all attendance statuses for all students
            foreach (DataGridViewRow row in dgvStudents.Rows)
            {
                if (row.IsNewRow) continue;
                row.Cells["AttendanceStatus"].Value = null; // Clear the status for all students
            }

            // Now, load the attendance data for this new date
            LoadAttendanceForDate(selectedDate);
        }


        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure that the subject and course are selected properly
            if (cmbSubject.SelectedValue != null && int.TryParse(cmbSubject.SelectedValue.ToString(), out int subjectId))
            {
                if (cmbCourse.SelectedValue != null && int.TryParse(cmbCourse.SelectedValue.ToString(), out int courseId))
                {
                    // Get the selected date
                    string selectedDate = dtpAttendanceDate.Value.ToString("yyyy-MM-dd");

                    // Debug: Checking the selected date and course
                    Console.WriteLine($"Subject changed. CourseId: {courseId}, Selected Date: {selectedDate}");

                    // Fetch students for the selected course
                    var students = GetStudentsByCourse(courseId);

                    // Clear the DataGridView and setup new columns
                    dgvStudents.Columns.Clear();

                    // Create a new DataTable to hold selected fields
                    DataTable table = new DataTable();
                    table.Columns.Add("Id", typeof(int));
                    table.Columns.Add("StudentName", typeof(string));
                    table.Columns.Add("UT_Number", typeof(string));

                    // Add students data to the table
                    foreach (var student in students)
                    {
                        table.Rows.Add(student.Id, student.StudentName, student.UT_Number);
                    }

                    dgvStudents.DataSource = table;

                    // Add the AttendanceStatus combo box column for each student
                    DataGridViewComboBoxColumn statusCol = new DataGridViewComboBoxColumn();
                    statusCol.Name = "AttendanceStatus";
                    statusCol.HeaderText = "Status";
                    statusCol.Items.AddRange("Present", "Absent", "Leave");
                    dgvStudents.Columns.Add(statusCol);

                    // Load attendance for the selected date
                    LoadAttendanceForDate(selectedDate);
                }
                else
                {
                    MessageBox.Show("Please select a valid course.");
                }
            }
            else
            {
                MessageBox.Show("Please select a valid subject.");
            }
        }

        private void LoadAttendanceForDate(string date)
        {
            // Get the selected subject id
            int subjectId = (int)cmbSubject.SelectedValue;

            // Debug: Output current subject and date
            Console.WriteLine($"Loading attendance for SubjectId: {subjectId}, Date: {date}");

            // Fetch attendance data for the selected subject and date
            List<Attendance> attendanceList = new attendanceController().GetAttendanceBySubjectDate(subjectId, date, DBConfig.GetConnection());

            // Loop through the DataGridView rows and check if attendance exists
            foreach (DataGridViewRow row in dgvStudents.Rows)
            {
                if (row.IsNewRow) continue;

                int studentId = (int)row.Cells["Id"].Value;

                // Look for attendance data for the current student and date
                var attendance = attendanceList.FirstOrDefault(a => a.StudentID == studentId);

                // If attendance exists for this student on the selected date, fill the status
                if (attendance != null)
                {
                    row.Cells["AttendanceStatus"].Value = attendance.Status;
                }
                else
                {
                    // No attendance for this student on this date, so leave it empty
                    row.Cells["AttendanceStatus"].Value = null;
                }
            }

            // Debug: After loading the data
            Console.WriteLine("Attendance loaded successfully.");
        }



        // Fetch Courses from DB
        private List<Course> GetCoursesFromDB()
        {
            var courses = new List<Course>();
            using (var conn = DBConfig.GetConnection())
            {
                string query = "SELECT * FROM Course";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        courses.Add(new Course
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            CourseName = reader["CourseName"].ToString(),
                            Duration = reader["Duration"].ToString(),
                            Description = reader["Description"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return courses;
        }

        private void lblSelectCourse_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //  Save Attendance Button Click
        // Save Attendance Button Click
        private void btnSaveAttendance_Click(object sender, EventArgs e)
        {
            var attendanceList = new List<Attendance>();
            int subjectId = (int)cmbSubject.SelectedValue;
            string date = dtpAttendanceDate.Value.ToString("yyyy-MM-dd");

            // Collect all the attendance data for each student
            foreach (DataGridViewRow row in dgvStudents.Rows)
            {
                if (row.IsNewRow) continue;

                int studentId = (int)row.Cells["Id"].Value;
                string status = row.Cells["AttendanceStatus"].Value?.ToString() ?? "Absent"; // Default to "Absent" if no status

                attendanceList.Add(new Attendance
                {
                    StudentID = studentId,
                    SubjectID = subjectId,
                    Date = date,
                    Status = status
                });
            }

            // Save the attendance data to the database
            using (var conn = DBConfig.GetConnection())
            {
                var controller = new attendanceController();
                foreach (var attendance in attendanceList)
                {
                    controller.MarkAttendance(attendance, conn);  // Save attendance for each student
                }
                conn.Close();
            }

            // Clear the DataGridView after saving
            foreach (DataGridViewRow row in dgvStudents.Rows)
            {
                if (row.IsNewRow) continue;
                row.Cells["AttendanceStatus"].Value = null;  // Clear the status for all students
            }

            MessageBox.Show("Attendance saved successfully!");
        }

    }
}

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

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure that SelectedValue is valid
            if (cmbSubject.SelectedValue != null && int.TryParse(cmbSubject.SelectedValue.ToString(), out int subjectId))
            {
                // Now use courseId, which is an integer
                if (cmbCourse.SelectedValue != null && int.TryParse(cmbCourse.SelectedValue.ToString(), out int courseId))
                {
                    // Now use courseId to fetch students for the selected course
                    var students = GetStudentsByCourse(courseId);

                    dgvStudents.Columns.Clear();

                    // Create a DataTable to hold selected fields
                    DataTable table = new DataTable();
                    table.Columns.Add("Id", typeof(int));
                    table.Columns.Add("StudentName", typeof(string));
                    table.Columns.Add("UT_Number", typeof(string));

                    // Add data to the table
                    foreach (var student in students)
                    {
                        table.Rows.Add(student.Id, student.StudentName, student.UT_Number);
                    }

                    dgvStudents.DataSource = table;

                    // Add AttendanceStatus combo box column
                    DataGridViewComboBoxColumn statusCol = new DataGridViewComboBoxColumn();
                    statusCol.Name = "AttendanceStatus";
                    statusCol.HeaderText = "Status";
                    statusCol.Items.AddRange("Present", "Absent", "Leave");
                    dgvStudents.Columns.Add(statusCol);

                    // Load previous attendance status for each student
                    string date = dtpAttendanceDate.Value.ToString("yyyy-MM-dd");

                    // Get the attendance for the selected subject and date
                    List<Attendance> attendanceList = new attendanceController().GetAttendanceBySubjectDate(subjectId, date, DBConfig.GetConnection());

                    // Loop through the grid rows and set the status for each student
                    foreach (DataGridViewRow row in dgvStudents.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int studentId = (int)row.Cells["Id"].Value;
                        var attendance = attendanceList.FirstOrDefault(a => a.StudentID == studentId);

                        if (attendance != null)
                        {
                            // Set the status based on existing attendance data
                            row.Cells["AttendanceStatus"].Value = attendance.Status;
                        }
                        else
                        {
                            // Set default to "Absent" if no attendance exists
                            row.Cells["AttendanceStatus"].Value = "Absent";
                        }
                    }
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
        // 🔽 Save Attendance Button Click
        private void btnSaveAttendance_Click(object sender, EventArgs e)
        {
            var attendanceList = new List<Attendance>();
            int subjectId = (int)cmbSubject.SelectedValue;
            string date = dtpAttendanceDate.Value.ToString("yyyy-MM-dd");

            foreach (DataGridViewRow row in dgvStudents.Rows)
            {
                if (row.IsNewRow) continue;

                int studentId = (int)row.Cells["Id"].Value;
                string status = row.Cells["AttendanceStatus"].Value?.ToString() ?? "Absent"; // default to "Absent" if nothing is selected

                attendanceList.Add(new Attendance
                {
                    StudentID = studentId,
                    SubjectID = subjectId,
                    Date = date,
                    Status = status
                });
            }

            using (var conn = DBConfig.GetConnection())
            {
                var controller = new attendanceController();
                foreach (var attendance in attendanceList)
                {
                    controller.MarkAttendance(attendance, conn);  // Mark attendance for each student
                }
                conn.Close();
            }

            MessageBox.Show("Attendance saved successfully!");
        }
    }
}

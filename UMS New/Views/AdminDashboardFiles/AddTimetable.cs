using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; // Required for LINQ
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMS_New.Controller;
using UMS_New.Model;
using UMS_New.Data;

namespace UMS_New.Views.DashboardFiles
{
    public partial class AddTimetable : UserControl
    {
        public AddTimetable()
        {
            InitializeComponent();
        }

        private void AddTimetable_Load(object sender, EventArgs e)
        {
            cmbDay.Items.AddRange(new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });
            cmbDay.SelectedIndex = 0;

            cmbTimeSlot.Items.AddRange(new string[] {
                "08:00 - 09:00",
                "09:00 - 10:00",
                "10:00 - 11:00",
                "11:00 - 12:00",
                "13:00 - 14:00",
                "14:00 - 15:00",
                "15:00 - 16:00"
            });
            cmbTimeSlot.SelectedIndex = 0;

            LoadSubjects();

            cmbDay.SelectedIndexChanged += DayOrTime_Changed;
            cmbTimeSlot.SelectedIndexChanged += DayOrTime_Changed;

            LoadFreeRoomsAndLecturers();
        }

        private void DayOrTime_Changed(object sender, EventArgs e)
        {
            LoadFreeRoomsAndLecturers();
        }

        private void LoadSubjects()
        {
            using (var conn = DBConfig.GetConnection())
            {
                var subjects = new subjectController().GetAllSubjects(conn);
                cmbSubject.DataSource = subjects;
                cmbSubject.DisplayMember = "SubjectName";
                cmbSubject.ValueMember = "Id";
            }
        }

        private void LoadFreeRoomsAndLecturers()
        {
            string selectedDay = cmbDay.SelectedItem.ToString();
            string selectedTime = cmbTimeSlot.SelectedItem.ToString();

            var timetableController = new timetableController();

            using (var conn = DBConfig.GetConnection())
            {
                // Get all rooms as DataTable and convert to list
                var roomTable = new roomController().GetAllRooms(conn);
                var allRooms = roomTable.AsEnumerable()
                                        .Select(row => new Room
                                        {
                                            Id = Convert.ToInt32(row["Id"]),
                                            RoomName = row["RoomName"].ToString()
                                        }).ToList();

                var freeRooms = allRooms
                                .Where(room => timetableController.IsRoomFree(room.Id, selectedDay, selectedTime))
                                .ToList();

                cmbRoom.DataSource = freeRooms;
                cmbRoom.DisplayMember = "RoomName";
                cmbRoom.ValueMember = "Id";

                // Get all lecturers
                var allLecturers = new userController().GetLecturers(conn);
                var freeLecturers = allLecturers
                                    .Where(lect => timetableController.IsLecturerFree(lect.Id, selectedDay, selectedTime))
                                    .ToList();

                cmbLecturer.DataSource = freeLecturers;
                cmbLecturer.DisplayMember = "Username";
                cmbLecturer.ValueMember = "Id";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbSubject.SelectedIndex == -1 || cmbRoom.SelectedIndex == -1 || cmbLecturer.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Subject, Room, and Lecturer.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Timetable entry = new Timetable()
            {
                SubjectID = Convert.ToInt32(cmbSubject.SelectedValue),
                DayOfWeek = cmbDay.SelectedItem.ToString(),
                TimeSlot = cmbTimeSlot.SelectedItem.ToString(),
                RoomID = Convert.ToInt32(cmbRoom.SelectedValue),
                LecturerID = Convert.ToInt32(cmbLecturer.SelectedValue),
            };

            var timetableController = new timetableController();

            using (var conn = DBConfig.GetConnection())
            {
                if (!timetableController.IsRoomFree(entry.RoomID, entry.DayOfWeek, entry.TimeSlot))
                {
                    MessageBox.Show("Selected room is no longer available.", "Room Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadFreeRoomsAndLecturers();
                    return;
                }

                if (!timetableController.IsLecturerFree(entry.LecturerID, entry.DayOfWeek, entry.TimeSlot))
                {
                    MessageBox.Show("Selected lecturer is no longer available.", "Lecturer Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadFreeRoomsAndLecturers();
                    return;
                }

                // ✅ NOW WE PASS THE CONNECTION TOO
                if (timetableController.AddTimetableEntry(entry, conn))
                {
                    MessageBox.Show("Timetable entry saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to save timetable entry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearForm()
        {
            cmbSubject.SelectedIndex = -1;
            cmbRoom.SelectedIndex = -1;
            cmbLecturer.SelectedIndex = -1;
            cmbDay.SelectedIndex = 0;
            cmbTimeSlot.SelectedIndex = 0;

            cmbTimeSlot.Visible = false;
            cmbRoom.Visible = false;
            cmbLecturer.Visible = false;
        }



    }
}

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UMS_New.Model;

namespace UMS_New.Controller
{
    internal class StudyMaterialController
    {
        private string connectionString = "Data Source=UMS_New.db;Version=3;";

        // ================= ADD MATERIAL =================
        public void AddMaterial(StudyMaterial material)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = @"INSERT INTO StudyMaterials 
                                (Title, Description, FilePath, UploadDate, SubjectID, LecturerID) 
                                 VALUES (@title, @desc, @path, @date, @subjectId, @lecturerId)";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", material.Title);
                    cmd.Parameters.AddWithValue("@desc", material.Description);
                    cmd.Parameters.AddWithValue("@path", material.FilePath);
                    cmd.Parameters.AddWithValue("@date", material.UploadDate);
                    cmd.Parameters.AddWithValue("@subjectId", material.SubjectID);
                    cmd.Parameters.AddWithValue("@lecturerId", material.LecturerID);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        // ================= GET ALL MATERIALS =================
        public List<StudyMaterial> GetAllMaterials()
        {
            List<StudyMaterial> list = new List<StudyMaterial>();

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM StudyMaterials";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new StudyMaterial
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Title = reader["Title"].ToString(),
                            Description = reader["Description"].ToString(),
                            FilePath = reader["FilePath"].ToString(),
                            UploadDate = reader["UploadDate"].ToString(),
                            SubjectID = Convert.ToInt32(reader["SubjectID"]),
                            LecturerID = Convert.ToInt32(reader["LecturerID"])
                        });
                    }
                }

                conn.Close();
            }

            return list;
        }

        // ================= GET BY SUBJECT =================
        public List<StudyMaterial> GetMaterialsBySubject(int subjectId)
        {
            List<StudyMaterial> list = new List<StudyMaterial>();

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM StudyMaterials WHERE SubjectID = @subjectId";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@subjectId", subjectId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new StudyMaterial
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Title = reader["Title"].ToString(),
                                Description = reader["Description"].ToString(),
                                FilePath = reader["FilePath"].ToString(),
                                UploadDate = reader["UploadDate"].ToString(),
                                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                LecturerID = Convert.ToInt32(reader["LecturerID"])
                            });
                        }
                    }
                }

                conn.Close();
            }

            return list;
        }

        // ================= DELETE MATERIAL (Optional) =================
        public void DeleteMaterial(int id)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM StudyMaterials WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }
    }
}

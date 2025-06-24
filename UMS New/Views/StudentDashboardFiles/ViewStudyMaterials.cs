using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMS_New.Controller;
using UMS_New.Model;
using UMS_New.Session;

namespace UMS_New.Views.StudentDashboardFiles
{
    public partial class ViewStudyMaterials : UserControl
    {
        public ViewStudyMaterials()
        {
            InitializeComponent();
        }

        // Load all materials when the form is loaded
        private void ViewStudyMaterials_Load(object sender, EventArgs e)
        {
          
        }

        private void dgvStudyMaterials_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        //// Display all study materials in the DataGridView
        //private void DisplayStudyMaterials()
        //{
        //    StudyMaterialController controller = new StudyMaterialController();
        //    List<StudyMaterial> materials = controller.GetAllMaterials();  // Fetch all materials

        //    // Bind the materials list to the DataGridView
        //    dgvStudyMaterials.DataSource = materials;

        //    // Make sure the column names are set up correctly
        //    dgvStudyMaterials.Columns["Id"].Visible = false;  // Hide the 'Id' column if you don't want to display it
        //    dgvStudyMaterials.Columns["Title"].HeaderText = "Material Title";
        //    dgvStudyMaterials.Columns["Description"].HeaderText = "Description";
        //    dgvStudyMaterials.Columns["FilePath"].HeaderText = "File Path";
        //    dgvStudyMaterials.Columns["UploadDate"].HeaderText = "Upload Date";

        //    // Add a download button column if it doesn't exist already
        //    if (!dgvStudyMaterials.Columns.Contains("Download"))
        //    {
        //        DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn
        //        {
        //            HeaderText = "Download",
        //            Text = "Download",
        //            UseColumnTextForButtonValue = true
        //        };
        //        dgvStudyMaterials.Columns.Add(btnColumn);
        //    }
        //}


        //private void dgvStudyMaterials_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    // Ensure the click is on the Download column (check the button column)
        //    if (e.ColumnIndex == dgvStudyMaterials.Columns["Download"].Index)
        //    {
        //        // Ensure that the row index is valid
        //        if (e.RowIndex >= 0 && e.RowIndex < dgvStudyMaterials.Rows.Count)
        //        {
        //            // Check if the "FilePath" column exists
        //            if (dgvStudyMaterials.Columns.Contains("FilePath"))
        //            {
        //                var filePathCell = dgvStudyMaterials.Rows[e.RowIndex].Cells["FilePath"];

        //                // Ensure that the filePathCell is not null and contains a value
        //                if (filePathCell != null && filePathCell.Value != DBNull.Value && filePathCell.Value != null)
        //                {
        //                    string filePath = filePathCell.Value.ToString();

        //                    // Check if the file exists and open it
        //                    if (System.IO.File.Exists(filePath))
        //                    {
        //                        System.Diagnostics.Process.Start(filePath); // Opens the file in the default application
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("File not found.");
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("File path is missing.");
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("FilePath column does not exist.");
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Invalid row index.");
        //        }
        //    }
        //}


    }
}

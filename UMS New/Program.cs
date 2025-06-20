using System;
using System.Windows.Forms;
using UMS_New.Data;
using UMS_New.Views;

namespace UMS_New
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            DatabaseInitializer.CreateTables(); // create admin user if needed

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new Form1()); // Run main form first
            Application.Run(new StudentDashboard()); // Run main form first

        }
    }
}

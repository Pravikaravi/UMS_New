using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS_New.Model
{
    internal class Staff
    {
        public int Id { get; set; }
        public string StaffName { get; set; }
        public string Phone_Number { get; set; }
        public string Email { get; set; }

        public int UserID { get; set; }
    }
}

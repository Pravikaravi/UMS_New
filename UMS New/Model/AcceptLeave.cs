using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS_New.Model
{
    internal class AcceptLeave
    {
        public int Id { get; set; }
       
        //public int UserID { get; set; }
        public string UT_Number { get; set; }
        public string Start_Date { get; set; }

        public string End_Date { get; set; }

        public string Reason { get; set; }
    }
}


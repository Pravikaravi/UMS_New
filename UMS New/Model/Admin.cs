﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS_New.Model
{
    public class Admin
    {
        public int Id { get; set; }
        public string AdminName { get; set; }
        public string Phone_Number { get; set; }
        public string Email { get; set; }

        public int UserID { get; set; }
    }
}
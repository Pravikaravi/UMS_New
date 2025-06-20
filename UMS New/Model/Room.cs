using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS_New.Model
{
    internal class Room
    {
        public int Id { get; set; }             // Matches 'Id' in your table
        public string RoomName { get; set; }   // Room name, e.g. "A101"
        public int Capacity { get; set; }      // Number of seats
                                               // Use bool for easier handling in code
        public bool IsAvailable
        {
            get => isAvailable == "Yes";
            set => isAvailable = value ? "Yes" : "No";
        }
        private string isAvailable = "Yes";
    }
}

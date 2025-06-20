using System;
using System.Data;
using System.Data.SQLite;
using UMS_New.Model;

namespace UMS_New.Controller
{
    internal class roomController
    {
        public void CreateRoom(Room room, SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
        INSERT INTO Room (RoomName, Capacity, IsAvailable) 
        VALUES (@roomName, @capacity, @isAvailable)";
            cmd.Parameters.AddWithValue("@roomName", room.RoomName);
            cmd.Parameters.AddWithValue("@capacity", room.Capacity);
            cmd.Parameters.AddWithValue("@isAvailable", room.IsAvailable ? "Yes" : "No");
            cmd.ExecuteNonQuery();
        }


        public DataTable GetAllRooms(SQLiteConnection conn)
        {
            DataTable dt = new DataTable();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Room";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public void UpdateRoom(Room room, SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                UPDATE Room 
                SET RoomName = @roomName, Capacity = @capacity, IsAvailable = @isAvailable 
                WHERE Id = @id";
            cmd.Parameters.AddWithValue("@roomName", room.RoomName);
            cmd.Parameters.AddWithValue("@capacity", room.Capacity);
            cmd.Parameters.AddWithValue("@isAvailable", room.IsAvailable ? "Yes" : "No");
            cmd.Parameters.AddWithValue("@id", room.Id);
            cmd.ExecuteNonQuery();
        }

        public DataTable GetAvailableRooms(SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Room WHERE IsAvailable = 'Yes'";
            var adapter = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }


        public void DeleteRoom(int id, SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Room WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}

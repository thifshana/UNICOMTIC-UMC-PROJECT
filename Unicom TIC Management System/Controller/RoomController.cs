using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Unicom_TIC_Management_System.Database;
using Unicom_TIC_Management_System.Models;
using Unicom_TIC_Management_System.Controller;



namespace Unicom_TIC_Management_System.Controller
{
    internal class RoomController
    {
        // Create a new Room
        public void Create(Room room)
        {
            using (var conn = DbConfig.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Room (RoomName, RoomType) VALUES (@name, @type)";
                cmd.Parameters.AddWithValue("@name", room.RoomName);
                cmd.Parameters.AddWithValue("@type", room.RoomType);
                cmd.ExecuteNonQuery();
            }
        }

        // Get all Rooms
        public List<Room> GetAll()
        {
            var rooms = new List<Room>();

            using (var conn = DbConfig.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT RoomID, RoomName, RoomType FROM Room";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rooms.Add(new Room
                        {
                            RoomID = Convert.ToInt32(reader["RoomID"]),
                            RoomName = reader["RoomName"].ToString(),
                            RoomType = reader["RoomType"].ToString()
                        });
                    }
                }
            }

            return rooms;
        }

        // Get Room by ID
        public Room GetById(int id)
        {
            Room room = null;

            using (var conn = DbConfig.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT RoomID, RoomName, RoomType FROM Room WHERE RoomID = @id";
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        room = new Room
                        {
                            RoomID = Convert.ToInt32(reader["RoomID"]),
                            RoomName = reader["RoomName"].ToString(),
                            RoomType = reader["RoomType"].ToString()
                        };
                    }
                }
            }

            return room;
        }

        // Update Room
        public void Update(Room room)
        {
            using (var conn = DbConfig.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "UPDATE Room SET RoomName = @name, RoomType = @type WHERE RoomID = @id";
                cmd.Parameters.AddWithValue("@name", room.RoomName);
                cmd.Parameters.AddWithValue("@type", room.RoomType);
                cmd.Parameters.AddWithValue("@id", room.RoomID);
                cmd.ExecuteNonQuery();
            }
        }

        // Delete Room
        public void Delete(int id)
        {
            using (var conn = DbConfig.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Room WHERE RoomID = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

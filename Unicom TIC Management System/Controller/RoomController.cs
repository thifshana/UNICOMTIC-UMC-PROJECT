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
            using (var connect = DbConfig.GetConnection())
            using (var command = connect.CreateCommand())
            {
                command.CommandText = "INSERT INTO Room (RoomName, RoomType) VALUES (@name, @type)";
                command.Parameters.AddWithValue("@name", room.RoomName);
                command.Parameters.AddWithValue("@type", room.RoomType);
                command.ExecuteNonQuery();
            }
        }

        // Get all Rooms
        public List<Room> GetAll()
        {
            var rooms = new List<Room>();

            using (var connect = DbConfig.GetConnection())
            using (var command = connect.CreateCommand())
            {
                command.CommandText = "SELECT RoomID, RoomName, RoomType FROM Room";

                using (var reader = command.ExecuteReader())
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

            using (var connect = DbConfig.GetConnection())
            using (var command = connect.CreateCommand())
            {
                command.CommandText = "SELECT RoomID, RoomName, RoomType FROM Room WHERE RoomID = @id";
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
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
            using (var connect = DbConfig.GetConnection())
            using (var command = connect.CreateCommand())
            {
                command.CommandText = "UPDATE Room SET RoomName = @name, RoomType = @type WHERE RoomID = @id";
                command.Parameters.AddWithValue("@name", room.RoomName);
                command.Parameters.AddWithValue("@type", room.RoomType);
                command.Parameters.AddWithValue("@id", room.RoomID);
                command.ExecuteNonQuery();
            }
        }

        // Delete Room
        public void Delete(int id)
        {
            using (var connect = DbConfig.GetConnection())
            using (var command = connect.CreateCommand())
            {
                command.CommandText = "DELETE FROM Room WHERE RoomID = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System.Database;
using Unicom_TIC_Management_System.Models;

namespace Unicom_TIC_Management_System.Controller
{
    internal class TimetableController
    {
        // ✅ CREATE Timetable
        public void Create(Timetable timetable)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    INSERT INTO Timetable (SubjectID, TimeSlot, RoomID)
                    VALUES (@subjectID, @timeSlot, @roomID)";

                cmd.Parameters.AddWithValue("@subjectID", timetable.SubjectID);
                cmd.Parameters.AddWithValue("@timeSlot", timetable.TimeSlot);
                cmd.Parameters.AddWithValue("@roomID", timetable.RoomID);

                cmd.ExecuteNonQuery();
            }
        }

        // ✅ READ All Timetables
        public List<Timetable> GetAll()
        {
            var list = new List<Timetable>();

            using (var conn = DbConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Timetable";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Timetable
                        {
                            TimetableID = Convert.ToInt32(reader["TimetableID"]),
                            SubjectID = Convert.ToInt32(reader["SubjectID"]),
                            TimeSlot = reader["TimeSlot"].ToString(),
                            RoomID = Convert.ToInt32(reader["RoomID"])
                        });
                    }
                }
            }

            return list;
        }

        // ✅ UPDATE Timetable
        public void Update(Timetable timetable)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE Timetable 
                    SET SubjectID = @subjectID,
                        TimeSlot = @timeSlot,
                        RoomID = @roomID
                    WHERE TimetableID = @timetableID";

                cmd.Parameters.AddWithValue("@subjectID", timetable.SubjectID);
                cmd.Parameters.AddWithValue("@timeSlot", timetable.TimeSlot);
                cmd.Parameters.AddWithValue("@roomID", timetable.RoomID);
                cmd.Parameters.AddWithValue("@timetableID", timetable.TimetableID);

                cmd.ExecuteNonQuery();
            }
        }

        // ✅ DELETE Timetable
        public void Delete(int timetableID)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Timetable WHERE TimetableID = @id";
                cmd.Parameters.AddWithValue("@id", timetableID);

                cmd.ExecuteNonQuery();
            }
        }

        // ✅ GET Timetable by ID
        public Timetable GetById(int id)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Timetable WHERE TimetableID = @id";
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Timetable
                        {
                            TimetableID = Convert.ToInt32(reader["TimetableID"]),
                            SubjectID = Convert.ToInt32(reader["SubjectID"]),
                            TimeSlot = reader["TimeSlot"].ToString(),
                            RoomID = Convert.ToInt32(reader["RoomID"])
                        };
                    }
                }
            }

            return null;
        }
    }
}


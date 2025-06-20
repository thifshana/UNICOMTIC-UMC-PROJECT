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
            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = @"
                    INSERT INTO Timetable (SubjectID, TimeSlot, RoomID)
                    VALUES (@subjectID, @timeSlot, @roomID)";

                command.Parameters.AddWithValue("@subjectID", timetable.SubjectID);
                command.Parameters.AddWithValue("@timeSlot", timetable.TimeSlot);
                command.Parameters.AddWithValue("@roomID", timetable.RoomID);

                command.ExecuteNonQuery();
            }
        }

        // ✅ READ All Timetables
        public List<Timetable> GetAll()
        {
            var list = new List<Timetable>();

            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = "SELECT * FROM Timetable";

                using (var read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        list.Add(new Timetable
                        {
                            TimetableID = Convert.ToInt32(read["TimetableID"]),
                            SubjectID = Convert.ToInt32(read["SubjectID"]),
                            TimeSlot = read["TimeSlot"].ToString(),
                            RoomID = Convert.ToInt32(read["RoomID"])
                        });
                    }
                }
            }

            return list;
        }

        // ✅ UPDATE Timetable
        public void Update(Timetable timetable)
        {
            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = @"
                    UPDATE Timetable 
                    SET SubjectID = @subjectID,
                        TimeSlot = @timeSlot,
                        RoomID = @roomID
                    WHERE TimetableID = @timetableID";

                command.Parameters.AddWithValue("@subjectID", timetable.SubjectID);
                command.Parameters.AddWithValue("@timeSlot", timetable.TimeSlot);
                command.Parameters.AddWithValue("@roomID", timetable.RoomID);
                command.Parameters.AddWithValue("@timetableID", timetable.TimetableID);

                command.ExecuteNonQuery();
            }
        }

        // ✅ DELETE Timetable
        public void Delete(int timetableID)
        {
            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = "DELETE FROM Timetable WHERE TimetableID = @id";
                command.Parameters.AddWithValue("@id", timetableID);

                command.ExecuteNonQuery();
            }
        }

        // ✅ GET Timetable by ID
        public Timetable GetById(int id)
        {
            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = "SELECT * FROM Timetable WHERE TimetableID = @id";
                command.Parameters.AddWithValue("@id", id);

                using (var read = command.ExecuteReader())
                {
                    if (read.Read())
                    {
                        return new Timetable
                        {
                            TimetableID = Convert.ToInt32(read["TimetableID"]),
                            SubjectID = Convert.ToInt32(read["SubjectID"]),
                            TimeSlot = read["TimeSlot"].ToString(),
                            RoomID = Convert.ToInt32(read["RoomID"])
                        };
                    }
                }
            }

            return null;
        }
    }
}


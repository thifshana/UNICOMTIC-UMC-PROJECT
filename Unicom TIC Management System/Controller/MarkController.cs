using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System.Database;
using Unicom_TIC_Management_System.Models;

namespace Unicom_TIC_Management_System.Controller
{
    internal class MarkController
    {
        public void AddMark(Mark mark)
        {
            using (var connect = DbConfig.GetConnection())
            {
                string query = "INSERT INTO Mark (StudentID, ExamID, Score) VALUES (@StudentID, @ExamID, @Score)";
                using (var command = new SQLiteCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@StudentID", mark.StudentID);
                    command.Parameters.AddWithValue("@ExamID", mark.ExamID);
                    command.Parameters.AddWithValue("@Score", mark.Score);
                    command.ExecuteNonQuery();
                }
            }
        }

        // READ - Get all marks
        public List<Mark> GetAllMarks()
        {
            List<Mark> marks = new List<Mark>();

            using (var connect = DbConfig.GetConnection())
            {
                string query = "SELECT * FROM Mark";
                using (var command = new SQLiteCommand(query, connect))
                using (var read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        marks.Add(new Mark
                        {
                            MarkID = Convert.ToInt32(read["MarkID"]),
                            StudentID = Convert.ToInt32(read["StudentID"]),
                            ExamID = Convert.ToInt32(read["ExamID"]),
                            Score = Convert.ToInt32(read["Score"])
                        });
                    }
                }
            }

            return marks;
        }

        // READ - Get mark by ID
        public Mark GetMarkById(int id)
        {
            using (var connect = DbConfig.GetConnection())
            {
                string query = "SELECT * FROM Mark WHERE MarkID = @MarkID";
                using (var command = new SQLiteCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@MarkID", id);
                    using (var read = command.ExecuteReader())
                    {
                        if (read.Read())
                        {
                            return new Mark
                            {
                                MarkID = Convert.ToInt32(read["MarkID"]),
                                StudentID = Convert.ToInt32(read["StudentID"]),
                                ExamID = Convert.ToInt32(read["ExamID"]),
                                Score = Convert.ToInt32(read["Score"])
                            };
                        }
                    }
                }
            }

            return null;
        }

        // UPDATE
        public void UpdateMark(Mark mark)
        {
            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = "UPDATE Mark SET StudentID = @StudentID, ExamID = @ExamID, Score = @Score WHERE MarkID = @MarkID";

                command.Parameters.AddWithValue("@StudentID", mark.StudentID);
                command.Parameters.AddWithValue("@ExamID", mark.ExamID);
                command.Parameters.AddWithValue("@Score", mark.Score);
                command.Parameters.AddWithValue("@MarkID", mark.MarkID);

                command.ExecuteNonQuery();
            }
        }

        // DELETE
        public void DeleteMark(int id)
        {
            using (var connect = DbConfig.GetConnection())
            {
                string query = "DELETE FROM Mark WHERE MarkID = @MarkID";
                using (var command = new SQLiteCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@MarkID", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}


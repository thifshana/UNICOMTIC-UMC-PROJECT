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
            using (var conn = DbConfig.GetConnection())
            {
                string query = "INSERT INTO Mark (StudentID, ExamID, Score) VALUES (@StudentID, @ExamID, @Score)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", mark.StudentID);
                    cmd.Parameters.AddWithValue("@ExamID", mark.ExamID);
                    cmd.Parameters.AddWithValue("@Score", mark.Score);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // READ - Get all marks
        public List<Mark> GetAllMarks()
        {
            List<Mark> marks = new List<Mark>();

            using (var conn = DbConfig.GetConnection())
            {
                string query = "SELECT * FROM Mark";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        marks.Add(new Mark
                        {
                            MarkID = Convert.ToInt32(reader["MarkID"]),
                            StudentID = Convert.ToInt32(reader["StudentID"]),
                            ExamID = Convert.ToInt32(reader["ExamID"]),
                            Score = Convert.ToInt32(reader["Score"])
                        });
                    }
                }
            }

            return marks;
        }

        // READ - Get mark by ID
        public Mark GetMarkById(int id)
        {
            using (var conn = DbConfig.GetConnection())
            {
                string query = "SELECT * FROM Mark WHERE MarkID = @MarkID";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MarkID", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Mark
                            {
                                MarkID = Convert.ToInt32(reader["MarkID"]),
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                ExamID = Convert.ToInt32(reader["ExamID"]),
                                Score = Convert.ToInt32(reader["Score"])
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
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Mark SET StudentID = @StudentID, ExamID = @ExamID, Score = @Score WHERE MarkID = @MarkID";

                cmd.Parameters.AddWithValue("@StudentID", mark.StudentID);
                cmd.Parameters.AddWithValue("@ExamID", mark.ExamID);
                cmd.Parameters.AddWithValue("@Score", mark.Score);
                cmd.Parameters.AddWithValue("@MarkID", mark.MarkID);

                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void DeleteMark(int id)
        {
            using (var conn = DbConfig.GetConnection())
            {
                string query = "DELETE FROM Mark WHERE MarkID = @MarkID";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MarkID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}


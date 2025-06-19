using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Unicom_TIC_Management_System.Database;
using Unicom_TIC_Management_System.Models;

namespace Unicom_TIC_Management_System.Controller
{
    internal class ExamController
    {
        // Create a new Exam
        public void Create(Exam exam)
        {
            using (var conn = DbConfig.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Exam (ExamName, SubjectID) VALUES (@examName, @subjectId)";
                cmd.Parameters.AddWithValue("@examName", exam.ExamName);
                cmd.Parameters.AddWithValue("@subjectId", exam.SubjectID);
                cmd.ExecuteNonQuery();
            }
        }

        // Read: Get all Exams
        public List<Exam> GetAll()
        {
            var exams = new List<Exam>();
            using (var conn = DbConfig.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT ExamID, ExamName, SubjectID FROM Exam";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exams.Add(new Exam
                        {
                            ExamID = Convert.ToInt32(reader["ExamID"]),
                            ExamName = reader["ExamName"].ToString(),
                            SubjectID = Convert.ToInt32(reader["SubjectID"])
                        });
                    }
                }
            }
            return exams;
        }

        // Read: Get Exam by ID
        public Exam GetById(int examId)
        {
            Exam exam = null;
            using (var conn = DbConfig.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT ExamID, ExamName, SubjectID FROM Exam WHERE ExamID = @id";
                cmd.Parameters.AddWithValue("@id", examId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        exam = new Exam
                        {
                            ExamID = Convert.ToInt32(reader["ExamID"]),
                            ExamName = reader["ExamName"].ToString(),
                            SubjectID = Convert.ToInt32(reader["SubjectID"])
                        };
                    }
                }
            }
            return exam;
        }

        // Update existing Exam
        public bool Update(Exam exam)
        {
            using (var conn = DbConfig.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "UPDATE Exam SET ExamName = @examName, SubjectID = @subjectId WHERE ExamID = @id";
                cmd.Parameters.AddWithValue("@examName", exam.ExamName);
                cmd.Parameters.AddWithValue("@subjectId", exam.SubjectID);
                cmd.Parameters.AddWithValue("@id", exam.ExamID);
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        // Delete Exam by ID
        public void Delete(int examId)
        {
            using (var conn = DbConfig.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Exam WHERE ExamID = @id";
                cmd.Parameters.AddWithValue("@id", examId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

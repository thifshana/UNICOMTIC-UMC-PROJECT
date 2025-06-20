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
            using (var connect = DbConfig.GetConnection())
            using (var command = connect.CreateCommand())
            {
                command.CommandText = "INSERT INTO Exam (ExamName, SubjectID) VALUES (@examName, @subjectId)";
                command.Parameters.AddWithValue("@examName", exam.ExamName);
                command.Parameters.AddWithValue("@subjectId", exam.SubjectID);
                command.ExecuteNonQuery();
            }
        }

        // Read: Get all Exams
        public List<Exam> GetAll()
        {
            var exams = new List<Exam>();
            using (var connect = DbConfig.GetConnection())
            using (var command = connect.CreateCommand())
            {
                command.CommandText = "SELECT ExamID, ExamName, SubjectID FROM Exam";
                using (var read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        exams.Add(new Exam
                        {
                            ExamID = Convert.ToInt32(read["ExamID"]),
                            ExamName = read["ExamName"].ToString(),
                            SubjectID = Convert.ToInt32(read["SubjectID"])
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
            using (var connect = DbConfig.GetConnection())
            using (var command = connect.CreateCommand())
            {
                command.CommandText = "SELECT ExamID, ExamName, SubjectID FROM Exam WHERE ExamID = @id";
                command.Parameters.AddWithValue("@id", examId);

                using (var read = command.ExecuteReader())
                {
                    if (read.Read())
                    {
                        exam = new Exam
                        {
                            ExamID = Convert.ToInt32(read["ExamID"]),
                            ExamName = read["ExamName"].ToString(),
                            SubjectID = Convert.ToInt32(read["SubjectID"])
                        };
                    }
                }
            }
            return exam;
        }

        // Update existing Exam
        public bool Update(Exam exam)
        {
            using (var connect = DbConfig.GetConnection())
            using (var command = connect.CreateCommand())
            {
                command.CommandText = "UPDATE Exam SET ExamName = @examName, SubjectID = @subjectId WHERE ExamID = @id";
                command.Parameters.AddWithValue("@examName", exam.ExamName);
                command.Parameters.AddWithValue("@subjectId", exam.SubjectID);
                command.Parameters.AddWithValue("@id", exam.ExamID);
                command.ExecuteNonQuery();
                return true;
            }
        }

        // Delete Exam by ID
        public void Delete(int examId)
        {
            using (var connect = DbConfig.GetConnection())
            using (var command = connect.CreateCommand())
            {
                command.CommandText = "DELETE FROM Exam WHERE ExamID = @id";
                command.Parameters.AddWithValue("@id", examId);
                command.ExecuteNonQuery();
            }
        }
    }
}

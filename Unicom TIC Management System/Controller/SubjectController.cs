using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System.Database;
using Unicom_TIC_Management_System.Models;




namespace Unicom_TIC_Management_System.Controller
{
  
    
        public class SubjectController
        {
        // Create a new Subject
        public void AddSubject(Subject subject)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Subject (SubjectName, CourseID) VALUES (@SubjectName, @CourseID)";
                cmd.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                cmd.Parameters.AddWithValue("@CourseID", subject.CourseID);
                cmd.ExecuteNonQuery();
            }
        }

        // READ - Get All Subjects
        public List<Subject> GetAllSubjects()
        {
            List<Subject> subjects = new List<Subject>();

            using (var conn = DbConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Subject";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        subjects.Add(new Subject
                        {
                            SubjectID = Convert.ToInt32(reader["SubjectID"]),
                            SubjectName = reader["SubjectName"].ToString(),
                            CourseID = Convert.ToInt32(reader["CourseID"])
                        });
                    }
                }
            }

            return subjects;
        }

        // UPDATE
        public void UpdateSubject(Subject subject)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Subject SET SubjectName = @SubjectName, CourseID = @CourseID WHERE SubjectID = @SubjectID";
                cmd.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                cmd.Parameters.AddWithValue("@CourseID", subject.CourseID);
                cmd.Parameters.AddWithValue("@SubjectID", subject.SubjectID);
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void DeleteSubject(int subjectId)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Subject WHERE SubjectID = @SubjectID";
                cmd.Parameters.AddWithValue("@SubjectID", subjectId);
                cmd.ExecuteNonQuery();
            }
        }

        // READ - Get Single Subject By ID
        public Subject GetSubjectById(int subjectId)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Subject WHERE SubjectID = @SubjectID";
                cmd.Parameters.AddWithValue("@SubjectID", subjectId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Subject
                        {
                            SubjectID = Convert.ToInt32(reader["SubjectID"]),
                            SubjectName = reader["SubjectName"].ToString(),
                            CourseID = Convert.ToInt32(reader["CourseID"])
                        };
                    }
                }
            }

            return null;
        }
    }
}


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
            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = "INSERT INTO Subject (SubjectName, CourseID) VALUES (@SubjectName, @CourseID)";
                command.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                command.Parameters.AddWithValue("@CourseID", subject.CourseID);
                command.ExecuteNonQuery();
            }
        }

        // READ - Get All Subjects
        public List<Subject> GetAllSubjects()
        {
            List<Subject> subjects = new List<Subject>();

            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = "SELECT * FROM Subject";
                using (var read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        subjects.Add(new Subject
                        {
                            SubjectID = Convert.ToInt32(read["SubjectID"]),
                            SubjectName = read["SubjectName"].ToString(),
                            CourseID = Convert.ToInt32(read["CourseID"])
                        });
                    }
                }
            }

            return subjects;
        }

        // UPDATE
        public void UpdateSubject(Subject subject)
        {
            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = "UPDATE Subject SET SubjectName = @SubjectName, CourseID = @CourseID WHERE SubjectID = @SubjectID";
                command.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                command.Parameters.AddWithValue("@CourseID", subject.CourseID);
                command.Parameters.AddWithValue("@SubjectID", subject.SubjectID);
                command.ExecuteNonQuery();
            }
        }

        // DELETE
        public void DeleteSubject(int subjectId)
        {
            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = "DELETE FROM Subject WHERE SubjectID = @SubjectID";
                command.Parameters.AddWithValue("@SubjectID", subjectId);
                command.ExecuteNonQuery();
            }
        }

        // READ - Get Single Subject By ID
        public Subject GetSubjectById(int subjectId)
        {
            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = "SELECT * FROM Subject WHERE SubjectID = @SubjectID";
                command.Parameters.AddWithValue("@SubjectID", subjectId);

                using (var read = command.ExecuteReader())
                {
                    if (read.Read())
                    {
                        return new Subject
                        {
                            SubjectID = Convert.ToInt32(read["SubjectID"]),
                            SubjectName = read["SubjectName"].ToString(),
                            CourseID = Convert.ToInt32(read["CourseID"])
                        };
                    }
                }
            }

            return null;
        }
    }
}


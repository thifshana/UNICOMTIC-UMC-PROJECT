using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Unicom_TIC_Management_System.Database;
using Unicom_TIC_Management_System.Models;

namespace Unicom_TIC_Management_System.Controller
{
    public static class StudentController
    {
        // CREATE
        public static void AddStudent(Student student)
        {
            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = "INSERT INTO Student (Name, CourseID) VALUES (@name, @courseId)";
                command.Parameters.AddWithValue("@name", student.Name);
                command.Parameters.AddWithValue("@courseId", student.CourseID);
                command.ExecuteNonQuery();
            }
        }

        // READ ALL
        public static List<Student> GetAllStudents()
        {
            List<Student> allstudents = new List<Student>();

            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = "SELECT StudentID, Name, CourseID FROM Student";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        allstudents.Add(new Student
                        {
                            StudentID = Convert.ToInt32(reader["StudentID"]),
                            Name = reader["Name"].ToString(),
                            CourseID = Convert.ToInt32(reader["CourseID"])
                        });
                    }
                }
            }

            return allstudents;
        }

        // UPDATE
        public static void UpdateStudent(Student student)
        {
            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = "UPDATE Student SET Name = @name, CourseID = @courseId WHERE StudentID = @id";
                command.Parameters.AddWithValue("@name", student.Name);
                command.Parameters.AddWithValue("@courseId", student.CourseID);
                command.Parameters.AddWithValue("@id", student.StudentID);
                command.ExecuteNonQuery();
            }
        }

        // DELETE
        public static void DeleteStudent(int studentId)
        {
            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = "DELETE FROM Student WHERE StudentID = @id";
                command.Parameters.AddWithValue("@id", studentId);
                command.ExecuteNonQuery();
            }
        }
    }
}

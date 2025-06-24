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
                try
                {
                    var command = connect.CreateCommand();
                    command.CommandText = "INSERT INTO Student (Name, CourseID, Dateofbirth, NIC, PhoneNB, Guardian, SpecificEDU) " +
                                          "VALUES (@name, @courseId, @Dateofbirth, @NIC, @PhoneNB, @Guardian, @SpecificEDU)";
                    command.Parameters.AddWithValue("@name", student.Name);
                    command.Parameters.AddWithValue("@courseId", student.CourseID);
                    command.Parameters.AddWithValue("@Dateofbirth", student.Dateofbirth);
                    command.Parameters.AddWithValue("@NIC", student.NIC);
                    command.Parameters.AddWithValue("@PhoneNB", student.PhoneNB);
                    command.Parameters.AddWithValue("@Guardian", student.Guardian);
                    command.Parameters.AddWithValue("@SpecificEDU", student.SpecificEDU);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Adding Student: " + ex.Message);
                    // Optionally log or show message box in UI
                }
            }
        }


        // READ ALL
        public static List<Student> GetAllStudents()
        {
            List<Student> allstudents = new List<Student>();

            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = "SELECT StudentID, Name, CourseID ,Dateofbirth , NIC ,PhoneNB, Guardian, SpecificEDU  FROM Student";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        allstudents.Add(new Student
                        {
                            StudentID = Convert.ToInt32(reader["StudentID"]),
                            Name = reader["Name"].ToString(),
                            CourseID = Convert.ToInt32(reader["CourseID"]),
                            Dateofbirth = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(reader["Dateofbirth"])).DateTime,

                            NIC = Convert.ToInt32(reader["NIC"]),
                            PhoneNB = Convert.ToInt32(reader["PhoneNB"]),
                            Guardian = reader["Guardian"].ToString(),
                            SpecificEDU = reader["SpecificEDU"].ToString()
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
                command.CommandText = "UPDATE Student SET Name = @name, CourseID = @courseId , Dateofbirth = @Dateofbirth , NIC = @NIC , PhoneNB = @PhoneNB ,  Guardian = @Guardian , SpecificEDU = @SpecificEDU  WHERE StudentID = @id";
                command.Parameters.AddWithValue("@name", student.Name);
                command.Parameters.AddWithValue("@courseId", student.CourseID);
                command.Parameters.AddWithValue("@id", student.StudentID);
                command.Parameters.AddWithValue("@Dateofbirth", student.Dateofbirth);
                command.Parameters.AddWithValue("@NIC", student.NIC);
                command.Parameters.AddWithValue("@PhoneNB", student.PhoneNB);
                command.Parameters.AddWithValue("@Guardian", student.Guardian);
                command.Parameters.AddWithValue("@SpecificEDU", student.SpecificEDU);
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

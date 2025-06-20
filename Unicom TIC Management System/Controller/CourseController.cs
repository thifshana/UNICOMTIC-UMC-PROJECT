using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System.Database;
using Unicom_TIC_Management_System.Models;

namespace Unicom_TIC_Management_System.Controller
{
    internal class CourseController
    {
        // Create a new Course
        public void Create(Course course)
        {
            using (var connect = DbConfig.GetConnection())
            using (var command = connect.CreateCommand())
            {
                command.CommandText = "INSERT INTO Course (CourseName) VALUES (@CourseName)";
                command.Parameters.AddWithValue("@CourseName", course.CourseName);
                command.ExecuteNonQuery();
            }
        }

        // Read/Get all Courses
        public List<Course> GetAll()
        {
            var newcourses = new List<Course>();

            using (var connect = DbConfig.GetConnection())
            using (var command = connect.CreateCommand())
            {
                command.CommandText = "SELECT CourseID, CourseName FROM Course";

                using (var read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        newcourses.Add(new Course
                        {
                            CourseID = Convert.ToInt32(read["CourseID"]),
                            CourseName = read["CourseName"].ToString()
                        });
                    }
                }
            }

            return newcourses;
        }

        // Read/Get Course by ID
        public Course GetById(int courseId)
        {
            using (var connect = DbConfig.GetConnection())
            using (var command = connect.CreateCommand())
            {
                command.CommandText = "SELECT CourseID, CourseName FROM Course WHERE CourseID = @CourseID";
                command.Parameters.AddWithValue("@CourseID", courseId);

                using (var read = command.ExecuteReader())
                {
                    if (read.Read())
                    {
                        return new Course
                        {
                            CourseID = Convert.ToInt32(read["CourseID"]),
                            CourseName = read["CourseName"].ToString()
                        };
                    }
                }
            }
            return null; // Not found
        }

        // Update existing Course
        public bool Update(Course course)
        {
            using (var connect = DbConfig.GetConnection())
            using (var command = connect.CreateCommand())
            {
                command.CommandText = "UPDATE Course SET CourseName = @CourseName WHERE CourseID = @CourseID";
                command.Parameters.AddWithValue("@CourseName", course.CourseName);
                command.Parameters.AddWithValue("@CourseID", course.CourseID);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Delete Course by ID
        public bool Delete(int courseId)
        {
            using (var connect = DbConfig.GetConnection())
            using (var command = connect.CreateCommand())
            {
                command.CommandText = "DELETE FROM Course WHERE CourseID = @CourseID";
                command.Parameters.AddWithValue("@CourseID", courseId);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        public List<Course> GetAllCourses()
        {
            List<Course> newcourses = new List<Course>();
            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = "SELECT * FROM Course";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        newcourses.Add(new Course
                        {
                            CourseID = Convert.ToInt32(reader["CourseID"]),
                            CourseName = reader["CourseName"].ToString()
                        });
                    }
                }
            }
            return newcourses;
        }
    }
}

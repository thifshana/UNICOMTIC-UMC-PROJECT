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
            using (var conn = DbConfig.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Course (CourseName) VALUES (@CourseName)";
                cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                cmd.ExecuteNonQuery();
            }
        }

        // Read/Get all Courses
        public List<Course> GetAll()
        {
            var courses = new List<Course>();

            using (var conn = DbConfig.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT CourseID, CourseName FROM Course";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        courses.Add(new Course
                        {
                            CourseID = Convert.ToInt32(reader["CourseID"]),
                            CourseName = reader["CourseName"].ToString()
                        });
                    }
                }
            }

            return courses;
        }

        // Read/Get Course by ID
        public Course GetById(int courseId)
        {
            using (var conn = DbConfig.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT CourseID, CourseName FROM Course WHERE CourseID = @CourseID";
                cmd.Parameters.AddWithValue("@CourseID", courseId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Course
                        {
                            CourseID = Convert.ToInt32(reader["CourseID"]),
                            CourseName = reader["CourseName"].ToString()
                        };
                    }
                }
            }
            return null; // Not found
        }

        // Update existing Course
        public bool Update(Course course)
        {
            using (var conn = DbConfig.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "UPDATE Course SET CourseName = @CourseName WHERE CourseID = @CourseID";
                cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                cmd.Parameters.AddWithValue("@CourseID", course.CourseID);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Delete Course by ID
        public bool Delete(int courseId)
        {
            using (var conn = DbConfig.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Course WHERE CourseID = @CourseID";
                cmd.Parameters.AddWithValue("@CourseID", courseId);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Course";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        courses.Add(new Course
                        {
                            CourseID = Convert.ToInt32(reader["CourseID"]),
                            CourseName = reader["CourseName"].ToString()
                        });
                    }
                }
            }
            return courses;
        }
    }
}

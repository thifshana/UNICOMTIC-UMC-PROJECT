 using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Unicom_TIC_Management_System.Database;
using Unicom_TIC_Management_System.Models;

namespace Unicom_TIC_Management_System.Controllers
{
    public static class UserController
    {
        // CREATE
        public static void AddUser(User user)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO User (Username, Password, Role) VALUES (@Username, @Password, @Role)";
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.ExecuteNonQuery();
            }
        }

        // READ
        public static List<User> GetAllUsers()
        {
            var users = new List<User>();

            using (var conn = DbConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM User";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Role = reader["Role"].ToString()
                        });
                    }
                }
            }

            return users;
        }

        public static User AuthenticateUser(string username, string password, string role)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM User WHERE Username = @Username AND Password = @Password AND Role = @Role";
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Role", role);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Role = reader["Role"].ToString()
                        };
                    }
                }
            }

            return null;
        }


        // UPDATE
        public static void UpdateUser(User user)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE User 
                    SET Username = @Username, Password = @Password, Role = @Role
                    WHERE UserID = @UserID";
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@UserID", user.UserID);
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public static void DeleteUser(int userId)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM User WHERE UserID = @UserID";
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.ExecuteNonQuery();
            }
        }

        // GET BY ID (Optional)
        public static User GetUserById(int userId)
        {
            using (var conn = DbConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM User WHERE UserID = @UserID";
                cmd.Parameters.AddWithValue("@UserID", userId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Role = reader["Role"].ToString()
                        };
                    }
                }
            }

            return null;
        }
    }
}

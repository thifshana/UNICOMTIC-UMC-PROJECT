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
            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = "INSERT INTO User (Username, Password, Role) VALUES (@Username, @Password, @Role)";
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.ExecuteNonQuery();
            }
        }

        // READ
        public static List<User> GetAllUsers()
        {
            var users = new List<User>();

            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = "SELECT * FROM User";

                using (var read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        users.Add(new User
                        {
                            UserID = Convert.ToInt32(read["UserID"]),
                            Username = read["Username"].ToString(),
                            Password = read["Password"].ToString(),
                            Role = read["Role"].ToString()
                        });
                    }
                }
            }

            return users;
        }

        public static User AuthenticateUser(string username, string password, string role)
        {
            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = "SELECT * FROM User WHERE Username = @Username AND Password = @Password AND Role = @Role";
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Role", role);

                using (var read = command.ExecuteReader())
                {
                    if (read.Read())
                    {
                        return new User
                        {
                            UserID = Convert.ToInt32(read["UserID"]),
                            Username = read["Username"].ToString(),
                            Password = read["Password"].ToString(),
                            Role = read["Role"].ToString()
                        };
                    }
                }
            }

            return null;
        }


        // UPDATE
        public static void UpdateUser(User user)
        {
            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = @"
                    UPDATE User 
                    SET Username = @Username, Password = @Password, Role = @Role
                    WHERE UserID = @UserID";
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.Parameters.AddWithValue("@UserID", user.UserID);
                command.ExecuteNonQuery();
            }
        }

        // DELETE
        public static void DeleteUser(int userId)
        {
            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = "DELETE FROM User WHERE UserID = @UserID";
                command.Parameters.AddWithValue("@UserID", userId);
                command.ExecuteNonQuery();
            }
        }

        // GET BY ID (Optional)
        public static User GetUserById(int userId)
        {
            using (var connect = DbConfig.GetConnection())
            {
                var command = connect.CreateCommand();
                command.CommandText = "SELECT * FROM User WHERE UserID = @UserID";
                command.Parameters.AddWithValue("@UserID", userId);

                using (var read = command.ExecuteReader())
                {
                    if (read.Read())
                    {
                        return new User
                        {
                            UserID = Convert.ToInt32(read["UserID"]),
                            Username = read["Username"].ToString(),
                            Password = read["Password"].ToString(),
                            Role = read["Role"].ToString()
                        };
                    }
                }
            }

            return null;
        }
    }
}

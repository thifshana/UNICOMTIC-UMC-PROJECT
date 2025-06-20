using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System.Database;
using Unicom_TIC_Management_System.Models;

namespace Unicom_TIC_Management_System.Controller
{
    internal class LoginController
    {
        public static User AuthenticateUser(string username, string password, string role)

        {
            using (var connect = DbConfig.GetConnection())
            using (var command = connect.CreateCommand())
            {
                command.CommandText = "SELECT * FROM User WHERE Username = @username AND Password = @password AND Role = @Role ";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
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
            return null; // Login failed
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sivoplyasov.FinalProject.Common.Entities;
using Sivoplyasov.FinalProject.DAL.Contracts;

namespace Sivoplyasov.FinalProject.DAL.DB
{
    public class UserDAO : IUserDAO
    {
        public bool Add(User user)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO dbo.Users (Name, Login, Password, Email, Role, Date_Of_Registration) VALUES (@Name, @Login, @Password, @Email, @Role, @Date_Of_Registration)";
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Login", user.Login);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.Parameters.AddWithValue("Date_Of_Registration", user.DateOfRegistration);
                connection.Open();
                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool BanUser(User user)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                var isBanned = 0;
                command.CommandText = $"UPDATE dbo.Users SET Is_Banned = @Is_Banned WHERE Id = {user.Id}";
                if (!user.IsBaned)
                {
                    isBanned = 1;
                }

                command.Parameters.AddWithValue("@Is_Banned", isBanned);
                connection.Open();
                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool EmailIsFree(string email)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT Email FROM dbo.Users WHERE Email = '{email}'";
                connection.Open();
                var result = command.ExecuteScalar() as string;
                if (result == null)
                {
                    return true;
                }
            }

            return false;
        }

        public int GetCountOfPostsByUserId(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT COUNT(*) FROM dbo.Posts WHERE User_Id = {id} ";
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public User GetUserById(int id)
        {
            User user = null;
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT Id, Name, Login, Password, Email, Role, Is_Banned, Date_Of_Registration FROM dbo.Users WHERE Id = {id}";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user = new User
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Login = (string)reader["Login"],
                        Password = (string)reader["Password"],
                        Email = (string)reader["Email"],
                        Role = (string)reader["Role"],
                        DateOfRegistration = (DateTime)reader["Date_Of_Registration"],
                        IsBaned = Convert.ToBoolean((int)reader["Is_Banned"])
                    };
                }
            }

            if (user != null && user.Name == null)
            {
                user.Name = user.Login;
            }

            return user;
        }

        public User GetUserByLogin(string login)
        {
            User user = null;
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT Id, Name, Login, Password, Email, Role, Is_Banned, Date_Of_Registration FROM dbo.Users WHERE Login = '{login}'";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user = new User
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"] as string,
                        Login = (string)reader["Login"],
                        Password = (string)reader["Password"],
                        Email = (string)reader["Email"],
                        Role = (string)reader["Role"],
                        DateOfRegistration = (DateTime)reader["Date_Of_Registration"],
                        IsBaned = Convert.ToBoolean((int)reader["Is_Banned"])
                    };
                }
            }

            if (user != null && user.Name == null)
            {
                user.Name = user.Login;
            }

            return user;
        }

        public bool LoginIsFree(string login)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT Login FROM dbo.Users WHERE Login = '{login}'";
                connection.Open();
                var result = command.ExecuteScalar() as string;
                if (result == null)
                {
                    return true;
                }
            }

            return false;
        }

        public bool SetUserRoleById(string role, int userId)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"UPDATE dbo.Users SET Role = @Role WHERE Id = {userId}";
                command.Parameters.AddWithValue("@Role", role);
                connection.Open();
                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

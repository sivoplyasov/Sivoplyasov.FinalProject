using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sivoplyasov.FinalProject.Common.Entities;
using Sivoplyasov.FinalProject.DAL.Contracts;

namespace Sivoplyasov.FinalProject.DAL.DB
{
    public class TopicDAO : ITopicDAO
    {
        public bool Add(Topic topic)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO dbo.Topics (Name, Category_Id, Author_Id, Date_Of_Creation, Description) VALUES (@Name, @Category_Id, @Author_Id, @Date_Of_Creation, @Description)";
                command.Parameters.AddWithValue("@Name", topic.Name);
                command.Parameters.AddWithValue("@Category_Id", topic.Category_Id);
                command.Parameters.AddWithValue("@Author_Id", topic.Author_Id);
                command.Parameters.AddWithValue("@Date_Of_Creation", topic.DateOfCreation);
                if (string.IsNullOrEmpty(topic.Description))
                {
                    command.Parameters.AddWithValue("@Description", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@Description", topic.Description);
                }

                connection.Open();
                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public IEnumerable<Topic> GetAll()
        {
            var allTopics = new List<Topic>();
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Category_Id, Author_Id, Date_Of_Creation, Description, Is_Closed FROM dbo.Topics";
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    allTopics.Add(new Topic
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Category_Id = (int)reader["Category_Id"],
                        Author_Id = (int)reader["Author_Id"],
                        Description = reader["Description"] as string,
                        DateOfCreation = (DateTime)reader["Date_Of_Creation"],
                        IsClosed = Convert.ToBoolean((int)reader["Is_Closed"])
                    });
                }
            }

            return allTopics;
        }

        public IEnumerable<Topic> GetTopicsByCategoryId(int id)
        {
            var allTopics = new List<Topic>();
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT Id, Name, Category_Id, Author_Id, Date_Of_Creation, Description, Is_Closed FROM dbo.Topics WHERE Category_Id = {id}";
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    allTopics.Add(new Topic
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Category_Id = (int)reader["Category_Id"],
                        Author_Id = (int)reader["Author_Id"],
                        Description = reader["Description"] as string,
                        DateOfCreation = (DateTime)reader["Date_Of_Creation"],
                        IsClosed = Convert.ToBoolean((int)reader["Is_Closed"])
                    });
                }
            }

            return allTopics;
        }

        public int GetCountOfPostsByTopicId(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT COUNT(*) FROM dbo.Posts WHERE Topic_Id = {id} ";
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public Topic GetTopicById(int id)
        {
            Topic topic = null;
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT Id, Name, Category_Id, Author_Id, Date_Of_Creation, Description, Is_Closed FROM dbo.Topics WHERE Id = {id}";
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    topic = new Topic
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Category_Id = (int)reader["Category_Id"],
                        Author_Id = (int)reader["Author_Id"],
                        Description = reader["Description"] as string,
                        DateOfCreation = (DateTime)reader["Date_Of_Creation"],
                        IsClosed = Convert.ToBoolean((int)reader["Is_Closed"])
                    };
                }
            }

            return topic;
        }

        public int GetLastTopicId()
        {
            int id = 0;

            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT MAX(Id) FROM dbo.Topics";
                connection.Open();
                id = (int)command.ExecuteScalar();
            }

            return id;
        }

        public bool RemoveTopicById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM dbo.Topics WHERE Id = {id}";
                connection.Open();
                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool CloseTopic(Topic topic)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                var isClosed = 0;
                command.CommandText = $"UPDATE dbo.Topics SET Is_Closed = @Is_Closed WHERE Id = {topic.Id}";
                if (!topic.IsClosed)
                {
                    isClosed = 1;
                }

                command.Parameters.AddWithValue("@Is_Closed", isClosed);
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

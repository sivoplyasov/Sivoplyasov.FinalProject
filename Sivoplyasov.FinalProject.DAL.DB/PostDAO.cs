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
    public class PostDAO : IPostDAO
    {
        public bool Add(Post post)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO dbo.Posts (Post_Text, Topic_Id, User_Id, Date_Of_Creation, Reply_Id) VALUES (@Post_Text, @Topic_Id, @User_Id, @Date_Of_Creation, @Reply_Id)";
                command.Parameters.AddWithValue("@Post_Text", post.PostText);
                command.Parameters.AddWithValue("@Topic_Id", post.Topic_Id);
                command.Parameters.AddWithValue("@User_Id", post.User_Id);
                command.Parameters.AddWithValue("@Date_Of_Creation", post.DateOfCreation);
                if (post.Reply_Id == null)
                {
                    command.Parameters.AddWithValue("@Reply_Id", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@Reply_Id", post.Reply_Id);
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

        public IEnumerable<Post> GetAll()
        {
            var allPosts = new List<Post>();
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Topic_Id, Post_Text, Date_Of_Creation, User_Id FROM dbo.Posts";
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    allPosts.Add(new Post
                    {
                        Id = (int)reader["Id"],
                        Topic_Id = (int)reader["Topic_Id"],
                        PostText = (string)reader["Post_Text"],
                        DateOfCreation = (DateTime)reader["Date_Of_Creation"],
                        User_Id = (int)reader["User_Id"]
                    });
                }
            }

            return allPosts;
        }

        public IEnumerable<Post> GetPostsByTopicId(int id)
        {
            var posts = new List<Post>();
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT Id, Topic_Id, Post_Text, Date_Of_Creation, User_Id, Reply_Id FROM dbo.Posts WHERE Topic_Id = {id}";
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    posts.Add(new Post
                    {
                        Id = (int)reader["Id"],
                        Topic_Id = (int)reader["Topic_Id"],
                        PostText = (string)reader["Post_Text"],
                        DateOfCreation = (DateTime)reader["Date_Of_Creation"],
                        User_Id = (int)reader["User_Id"],
                        Reply_Id = reader["Reply_Id"] as int?
                    });
                }
            }

            return posts;
        }

        public int GetCountOfPostsByUserId(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT COUNT(*) FROM dbo.Posts WHERE User_Id = {id}";
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public Post GetPostById(int id)
        {
            Post post = null;
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT Id, Topic_Id, Post_Text, Date_Of_Creation, User_Id, Reply_Id FROM dbo.Posts WHERE Id = {id}";
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    post = new Post
                    {
                        Id = (int)reader["Id"],
                        Topic_Id = (int)reader["Topic_Id"],
                        PostText = (string)reader["Post_Text"],
                        DateOfCreation = (DateTime)reader["Date_Of_Creation"],
                        User_Id = (int)reader["User_Id"],
                        Reply_Id = reader["Reply_Id"] as int?
                    };
                }
            }

            return post;
        }

        public int GetCountOfPostsByTopicId(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT COUNT(*) FROM dbo.Posts WHERE Topic_Id = {id}";
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public Post GetLastPostByTopicId(int id)
        {
            Post post = null;
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT Id, Topic_Id, Post_Text, Date_Of_Creation, User_Id, Reply_Id FROM dbo.Posts WHERE Topic_Id = {id} AND Date_Of_Creation = (SELECT MAX(Date_Of_Creation) FROM dbo.Posts WHERE Topic_Id = {id})";
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    post = new Post
                    {
                        Id = (int)reader["Id"],
                        Topic_Id = (int)reader["Topic_Id"],
                        PostText = (string)reader["Post_Text"],
                        DateOfCreation = (DateTime)reader["Date_Of_Creation"],
                        User_Id = (int)reader["User_Id"],
                        Reply_Id = reader["Reply_Id"] as int?
                    };
                }
            }

            return post;
        }

        public Post GetLastPostByCategoryId(int id)
        {
            Post post = null;
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT Posts.Id, Posts.Topic_Id, Posts.Post_Text, Posts.Date_Of_Creation, Posts.User_Id, Posts.Reply_Id, Topics.Id FROM dbo.Posts AS Posts, dbo.Topics AS Topics WHERE Posts.Topic_Id = Topics.Id AND Topics.Category_Id = {id} AND Posts.Date_Of_Creation = (SELECT MAX(Posts.Date_Of_Creation) FROM dbo.Posts WHERE Topic_Id = Posts.Topic_Id)";
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    post = new Post
                    {
                        Id = (int)reader["Id"],
                        Topic_Id = (int)reader["Topic_Id"],
                        PostText = (string)reader["Post_Text"],
                        DateOfCreation = (DateTime)reader["Date_Of_Creation"],
                        User_Id = (int)reader["User_Id"],
                        Reply_Id = reader["Reply_Id"] as int?
                    };
                }
            }

            return post;
        }

        public bool RemovePostById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM dbo.Posts WHERE Id = {id}";
                connection.Open();
                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool EditPost(Post post)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"UPDATE dbo.Posts SET Post_Text = @Post_Text WHERE Id = {post.Id}";
                command.Parameters.AddWithValue("@Post_Text", post.PostText);
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

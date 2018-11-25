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
    public class CategoryDAO : ICategoryDAO
    {
        public bool Add(Category category)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO dbo.Categories (Name, Section_Id, Description) VALUES (@Name, @Section_Id, @Description)";
                command.Parameters.AddWithValue("@Name", category.Name);
                command.Parameters.AddWithValue("@Section_Id", category.SectionId);
                if (category.Description == null)
                {
                    command.Parameters.AddWithValue("@Description", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@Description", category.Description);
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

        public IEnumerable<Category> GetAll()
        {
            var allSections = new List<Category>();
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Description, Section_Id FROM dbo.Categories";
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    allSections.Add(new Category { Id = (int)reader["Id"], Name = (string)reader["Name"], Description = (string)reader["Description"], SectionId = (int)reader["Section_Id"] });
                }
            }

            return allSections;
        }

        public IEnumerable<Category> GetCategoriesBySectionId(int sectionId)
        {
            var allSections = new List<Category>();
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT Id, Name, Description, Section_Id FROM dbo.Categories WHERE Section_id = {sectionId}";
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    allSections.Add(new Category { Id = (int)reader["Id"], Name = (string)reader["Name"], Description = (string)reader["Description"], SectionId = (int)reader["Section_Id"] });
                }
            }

            return allSections;
        }

        public Category GetCategoryById(int id)
        {
            Category category = null;
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT Id, Name, Section_Id, Description FROM dbo.Categories WHERE Id = {id}";
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    category = new Category { Id = (int)reader["Id"], Name = (string)reader["Name"], SectionId = (int)reader["Section_Id"], Description = (string)reader["Description"] };
                }
            }

            return category;
        }

        public int GetCountOfPostsByCategoryId(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT COUNT(*) FROM dbo.Topics as Topics, dbo.Posts as Posts WHERE Topics.Category_Id = {id} AND Posts.Topic_Id = Topics.Id";
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public int GetCountOfTopicsByCategoryId(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT COUNT(*) FROM dbo.Topics WHERE Category_Id = {id}";
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public bool RemoveCategoryById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM dbo.Categories WHERE Id = {id}";
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

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
    public class SectionDAO : ISectionDAO
    {
        public bool Add(Section section)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO dbo.Sections (Name) VALUES (@Name)";
                command.Parameters.AddWithValue("@Name", section.Name);
                connection.Open();
                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public IEnumerable<Section> GetAll()
        {
            var allSections = new List<Section>();
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name FROM dbo.Sections";
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    allSections.Add(new Section { Id = (int)reader["Id"], Name = (string)reader["Name"] });
                }
            }

            return allSections;
        }

        public Section GetSectionById(int id)
        {
            Section section = null;
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT Id, Name FROM dbo.Sections WHERE Id = {id}";
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    section = new Section { Id = (int)reader["Id"], Name = (string)reader["Name"] };
                }
            }

            return section;
        }

        public bool RemoveSectionById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM dbo.Sections WHERE Id = {id}";
                connection.Open();
                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public int GetCountOfCategoriesBySectionId(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT COUNT(*) FROM dbo.Categories WHERE Section_Id = {id}";
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }
    }
}

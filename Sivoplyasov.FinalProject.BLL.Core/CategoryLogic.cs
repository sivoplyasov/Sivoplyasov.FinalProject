using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sivoplyasov.FinalProject.BLL.Contracts;
using Sivoplyasov.FinalProject.Common.Entities;

namespace Sivoplyasov.FinalProject.BLL.Core
{
    public class CategoryLogic : ICategoryLogic
    {
        public bool Add(Category category)
        {
            if (category.Name.Length > 50 || category.Description.Length > 50)
            {
                throw new ArgumentException();
            }

            return Daos.CategoryDAO.Add(category);
        }

        public IEnumerable<Category> GetAll()
        {
            var categories = Daos.CategoryDAO.GetAll().ToList();
            for (int i = 0; i < categories.Count; i++)
            {
                categories[i].CountOfPosts = Daos.CategoryDAO.GetCountOfPostsByCategoryId(categories[i].Id);
                categories[i].CountOfTopics = Daos.CategoryDAO.GetCountOfTopicsByCategoryId(categories[i].Id);
                categories[i].LastPost = Daos.PostDAO.GetLastPostByCategoryId(categories[i].Id);
            }

            return categories;
        }

        public IEnumerable<Category> GetCategoriesBySectionId(int sectionId)
        {
            var categories = Daos.CategoryDAO.GetCategoriesBySectionId(sectionId).ToList();
            for (int i = 0; i < categories.Count; i++)
            {
                categories[i].CountOfPosts = Daos.CategoryDAO.GetCountOfPostsByCategoryId(categories[i].Id);
                categories[i].CountOfTopics = Daos.CategoryDAO.GetCountOfTopicsByCategoryId(categories[i].Id);
                categories[i].LastPost = Daos.PostDAO.GetLastPostByCategoryId(categories[i].Id);
            }

            return categories;
        }

        public Category GetCategoryById(int id)
        {
            var category = Daos.CategoryDAO.GetCategoryById(id);
            if (category != null)
            {
                category.CountOfPosts = Daos.CategoryDAO.GetCountOfPostsByCategoryId(category.Id);
                category.CountOfTopics = Daos.CategoryDAO.GetCountOfTopicsByCategoryId(category.Id);
                category.LastPost = Daos.PostDAO.GetLastPostByCategoryId(category.Id);
            }

            return category;
        }

        public int GetCountOfPostsByCategoryId(int id)
        {
            return Daos.CategoryDAO.GetCountOfPostsByCategoryId(id);
        }

        public int GetCountOfTopicsByCategoryId(int id)
        {
            return Daos.CategoryDAO.GetCountOfTopicsByCategoryId(id);
        }

        public bool RemoveCategoryById(int id)
        {
            return Daos.CategoryDAO.RemoveCategoryById(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sivoplyasov.FinalProject.Common.Entities;

namespace Sivoplyasov.FinalProject.BLL.Contracts
{
    public interface ICategoryLogic
    {
        bool Add(Category category);

        bool RemoveCategoryById(int id);

        Category GetCategoryById(int id);

        IEnumerable<Category> GetAll();

        IEnumerable<Category> GetCategoriesBySectionId(int sectionId);

        int GetCountOfPostsByCategoryId(int id);

        int GetCountOfTopicsByCategoryId(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sivoplyasov.FinalProject.Common.Entities;

namespace Sivoplyasov.FinalProject.BLL.Contracts
{
    public interface ISectionLogic
    {
        bool Add(Section section);

        bool RemoveSecitonById(int id);

        IEnumerable<Section> GetAll();

        Section GetSectionById(int id);

        int GetCountOfCategoriesBySectionId(int id);
    }
}

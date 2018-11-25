using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sivoplyasov.FinalProject.Common.Entities;

namespace Sivoplyasov.FinalProject.DAL.Contracts
{
    public interface ISectionDAO
    {
        bool Add(Section section);

        bool RemoveSectionById(int id);

        Section GetSectionById(int id);

        IEnumerable<Section> GetAll();

        int GetCountOfCategoriesBySectionId(int id);
    }
}

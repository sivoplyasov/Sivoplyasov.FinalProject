using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sivoplyasov.FinalProject.BLL.Contracts;
using Sivoplyasov.FinalProject.Common.Entities;

namespace Sivoplyasov.FinalProject.BLL.Core
{
    public class SectonLogic : ISectionLogic
    {
        public bool Add(Section section)
        {
            if (section.Name.Length > 30)
            {
                throw new ArgumentException();
            }

            return Daos.SectionDAO.Add(section);
        }

        public IEnumerable<Section> GetAll()
        {
            var sections = Daos.SectionDAO.GetAll().ToList();
            for (int i = 0; i < sections.Count; i++)
            {
                sections[i].CountOfCategories = Daos.SectionDAO.GetCountOfCategoriesBySectionId(sections[i].Id);
            }

            return sections;
        }

        public int GetCountOfCategoriesBySectionId(int id)
        {
            return Daos.SectionDAO.GetCountOfCategoriesBySectionId(id);
        }

        public Section GetSectionById(int id)
        {
            var section = Daos.SectionDAO.GetSectionById(id);
            if (section != null)
            {
                section.CountOfCategories = Daos.SectionDAO.GetCountOfCategoriesBySectionId(section.Id);
            }

            return section;
        }

        public bool RemoveSecitonById(int id)
        {
            return Daos.SectionDAO.RemoveSectionById(id);
        }
    }
}

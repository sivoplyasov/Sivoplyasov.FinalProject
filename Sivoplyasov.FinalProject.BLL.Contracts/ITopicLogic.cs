using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sivoplyasov.FinalProject.Common.Entities;

namespace Sivoplyasov.FinalProject.BLL.Contracts
{
    public interface ITopicLogic
    {
        bool Add(Topic topic);

        bool RemoveTopicById(int id);

        IEnumerable<Topic> GetAll();

        IEnumerable<Topic> GetTopicsByCategoryId(int id);

        Topic GetTopicById(int id);

        int GetCountOfPostsByTopicId(int id);

        int GetLastTopicId();

        bool CloseTopic(Topic topic);
    }
}

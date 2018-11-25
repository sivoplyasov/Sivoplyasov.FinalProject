using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sivoplyasov.FinalProject.DAL.Contracts;
using Sivoplyasov.FinalProject.DAL.DB;

namespace Sivoplyasov.FinalProject.BLL.Core
{
    public static class Daos
    {
        public static ISectionDAO SectionDAO => new SectionDAO();

        public static ICategoryDAO CategoryDAO => new CategoryDAO();

        public static ITopicDAO TopicDAO => new TopicDAO();

        public static IUserDAO UserDAO => new UserDAO();

        public static IPostDAO PostDAO => new PostDAO();

    }
}

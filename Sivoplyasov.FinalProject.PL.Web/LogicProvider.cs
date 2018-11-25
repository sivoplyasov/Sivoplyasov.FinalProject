using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sivoplyasov.FinalProject.BLL.Contracts;
using Sivoplyasov.FinalProject.BLL.Core;

namespace Sivoplyasov.FinalProject.PL.Web
{
    public static class LogicProvider
    {
        public static ISectionLogic SectionLogic => new SectonLogic();

        public static ICategoryLogic CategoryLogic => new CategoryLogic();

        public static ITopicLogic TopicLogic => new TopicLogic();

        public static IUserLogic UserLogic => new UserLogic();

        public static IPostLogic PostLogic => new PostLogic();
    }
}
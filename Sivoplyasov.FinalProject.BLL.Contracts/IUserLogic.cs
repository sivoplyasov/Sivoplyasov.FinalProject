using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sivoplyasov.FinalProject.Common.Entities;

namespace Sivoplyasov.FinalProject.BLL.Contracts
{
    public interface IUserLogic
    {
        bool Add(User user);

        bool LoginIsFree(string login);

        bool BanUser(User user);

        bool SetUserRoleById(string role, int userId);

        User GetUserById(int id);

        User GetUserByLogin(string login);

        int GetCountOfPostsByUserId(int id);
    }
}

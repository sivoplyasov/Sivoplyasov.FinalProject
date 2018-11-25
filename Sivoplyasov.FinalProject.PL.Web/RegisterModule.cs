using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sivoplyasov.FinalProject.PL.Web
{
    public class RegisterModule
    {
        public static bool CanRegister(string login, string password)
        {
            if (LogicProvider.UserLogic.LoginIsFree(login))
            {
                return true;
            }

            return false;
        }
    }
}
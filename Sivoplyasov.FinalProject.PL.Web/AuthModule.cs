using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Sivoplyasov.FinalProject.PL.Web
{
    public class AuthModule
    {
        public static bool CanLogin(string login, string password)
        {
            if (!LogicProvider.UserLogic.LoginIsFree(login))
            {
                var user = LogicProvider.UserLogic.GetUserByLogin(login);

                if (user.IsBaned)
                {
                    return false;
                }

                if (user.Password == HashPassword(password))
                {
                    return true;
                }
            }

            return false;
        }

        private static string HashPassword(string password)
        {
            byte[] data = Encoding.Default.GetBytes(password);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] result = sha.ComputeHash(data);
            password = Convert.ToBase64String(result);
            return password;
        }
    }
}
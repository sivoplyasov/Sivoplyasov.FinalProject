using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Sivoplyasov.FinalProject.BLL.Contracts;
using Sivoplyasov.FinalProject.Common.Entities;

namespace Sivoplyasov.FinalProject.BLL.Core
{
    public class UserLogic : IUserLogic
    {
        public bool Add(User user)
        {
            if (user.Name.Length > 50 || user.Login.Length > 20 || user.Password.Length > 30 || user.Email.Length > 30 || user.Role.Length > 30)
            {
                throw new ArgumentException();
            }

            user.Password = this.HashPassword(user.Password);
            user.DateOfRegistration = DateTime.Now;
            return Daos.UserDAO.Add(user);
        }

        public bool BanUser(User user)
        {
            return Daos.UserDAO.BanUser(user);
        }

        public int GetCountOfPostsByUserId(int id)
        {
            return Daos.UserDAO.GetCountOfPostsByUserId(id);
        }

        public User GetUserById(int id)
        {
            var user = Daos.UserDAO.GetUserById(id);
            if (user != null)
            {
                user.CountOfPosts = Daos.UserDAO.GetCountOfPostsByUserId(user.Id);
            }

            return user;
        }

        public User GetUserByLogin(string login)
        {
            var user = Daos.UserDAO.GetUserByLogin(login);
            if (user != null)
            {
                user.CountOfPosts = Daos.UserDAO.GetCountOfPostsByUserId(user.Id);
            }

            return user;
        }

        public bool LoginIsFree(string login)
        {
            return Daos.UserDAO.LoginIsFree(login);
        }

        public bool SetUserRoleById(string role, int userId)
        {
            return Daos.UserDAO.SetUserRoleById(role, userId);
        }

        private string HashPassword(string password)
        {
            byte[] data = Encoding.Default.GetBytes(password);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] result = sha.ComputeHash(data);
            password = Convert.ToBase64String(result);
            return password;
        }
    }
}

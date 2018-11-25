using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Sivoplyasov.FinalProject.PL.Web
{
    public class ForumRoleProvider : RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            var user = LogicProvider.UserLogic.GetUserByLogin(username);
            return user.Role == roleName;
        }

        public override string[] GetRolesForUser(string username)
        {
            var user = LogicProvider.UserLogic.GetUserByLogin(username);
            return new[] { user.Role };
        }

        #region NotImplemented
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
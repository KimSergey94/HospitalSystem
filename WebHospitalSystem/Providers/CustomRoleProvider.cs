using DAL.EF;
using DAL.Entities;
using System.Linq;
using System.Web.Security;

namespace WebHospitalSystem.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new System.NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetRolesForUser(string login)
        {
            string[] roles = new string[] { };
            using (HospitalSystemContext db = new HospitalSystemContext("DefaultConnection"))
            {
                User user = db.User.FirstOrDefault(u => u.Login == login);
                if (user != null)
                {
                    Role userRole = db.Role.Find(user.RoleId);
                    if (userRole != null) { roles = new string[] { userRole.Name }; }
                }
            }
            return roles;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsUserInRole(string login, string roleName)
        {
            bool outputResult = false;
            using (HospitalSystemContext db = new HospitalSystemContext("DefaultConnection"))
            {
                User user = db.User.FirstOrDefault(u => u.Login == login);
                if (user != null)
                {
                    Role userRole = db.Role.Find(user.RoleId);
                    if (userRole != null && userRole.Name == roleName)
                    {
                        outputResult = true;
                    }
                }
            }
            return outputResult;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new System.NotImplementedException();
        }
    }
}

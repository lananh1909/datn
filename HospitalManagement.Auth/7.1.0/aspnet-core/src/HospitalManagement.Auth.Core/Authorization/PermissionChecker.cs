using Abp.Authorization;
using HospitalManagement.Auth.Authorization.Roles;
using HospitalManagement.Auth.Authorization.Users;

namespace HospitalManagement.Auth.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

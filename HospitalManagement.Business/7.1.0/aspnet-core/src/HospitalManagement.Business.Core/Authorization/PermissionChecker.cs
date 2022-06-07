using Abp.Authorization;
using HospitalManagement.Business.Authorization.Roles;
using HospitalManagement.Business.Authorization.Users;

namespace HospitalManagement.Business.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

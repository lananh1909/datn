using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace HospitalManagement.Auth.Controllers
{
    public abstract class AuthControllerBase: AbpController
    {
        protected AuthControllerBase()
        {
            LocalizationSourceName = AuthConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace HospitalManagement.Business.Controllers
{
    public abstract class BusinessControllerBase: AbpController
    {
        protected BusinessControllerBase()
        {
            LocalizationSourceName = BusinessConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

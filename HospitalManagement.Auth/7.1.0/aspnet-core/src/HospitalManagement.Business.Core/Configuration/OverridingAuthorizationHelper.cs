using Abp.Application.Features;
using Abp.Authorization;
using Abp.Configuration.Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HospitalManagement.Business.Configuration
{
    public class OverridingAuthorizationHelper : AuthorizationHelper
    {
        private readonly IAuthorizationConfiguration _authConfiguration;
        public OverridingAuthorizationHelper(IFeatureChecker featureChecker, IAuthorizationConfiguration authConfiguration)
            : base(featureChecker, authConfiguration)
        {
            _authConfiguration = authConfiguration;
        }

        public override async Task AuthorizeAsync(IEnumerable<IAbpAuthorizeAttribute> authorizeAttributes)
        {
            if(!_authConfiguration.IsEnabled)
            {
                return;
            }
            foreach (var authorizeAttribute in authorizeAttributes)
            {
                await PermissionChecker.AuthorizeAsync(authorizeAttribute.RequireAllPermissions, authorizeAttribute.Permissions);
            }
        }
    }
}

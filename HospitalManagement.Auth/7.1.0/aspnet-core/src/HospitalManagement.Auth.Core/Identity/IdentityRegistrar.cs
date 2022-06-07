using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using HospitalManagement.Auth.Authorization;
using HospitalManagement.Auth.Authorization.Roles;
using HospitalManagement.Auth.Authorization.Users;
using HospitalManagement.Auth.Editions;
using HospitalManagement.Auth.MultiTenancy;

namespace HospitalManagement.Auth.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddAbpIdentity<Tenant, User, Role>()
                .AddAbpTenantManager<TenantManager>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpEditionManager<EditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpLogInManager<LogInManager>()
                .AddAbpSignInManager<SignInManager>()
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddPermissionChecker<PermissionChecker>()
                .AddDefaultTokenProviders();
        }
    }
}

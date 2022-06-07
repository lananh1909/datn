using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using HospitalManagement.Auth.Authorization.Roles;
using HospitalManagement.Auth.Authorization.Users;
using HospitalManagement.Auth.Configuration;
using HospitalManagement.Auth.Localization;
using HospitalManagement.Auth.MultiTenancy;
using HospitalManagement.Auth.Timing;

namespace HospitalManagement.Auth
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class AuthCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            AuthLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = AuthConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
            
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flags us"));
            
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = AuthConsts.DefaultPassPhrase;
            SimpleStringCipher.DefaultPassPhrase = AuthConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AuthCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}

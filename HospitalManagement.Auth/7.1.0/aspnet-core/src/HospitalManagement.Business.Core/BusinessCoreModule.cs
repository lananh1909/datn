using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using HospitalManagement.Business.Configuration;
using HospitalManagement.Business.Localization;
using HospitalManagement.Business.Timing;

namespace HospitalManagement.Business
{
    //[DependsOn(typeof(AbpZeroCoreModule))]
    public class BusinessCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;
            
            BusinessLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = BusinessConsts.MultiTenancyEnabled;

            Configuration.Settings.Providers.Add<AppSettingProvider>();
            
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flags us"));
            
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = BusinessConsts.DefaultPassPhrase;
            SimpleStringCipher.DefaultPassPhrase = BusinessConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BusinessCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}

using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HospitalManagement.Auth.Authorization;

namespace HospitalManagement.Auth
{
    [DependsOn(
        typeof(AuthCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AuthApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AuthAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AuthApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}

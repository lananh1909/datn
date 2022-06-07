using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HospitalManagement.Auth.Configuration;

namespace HospitalManagement.Auth.Web.Host.Startup
{
    [DependsOn(
       typeof(AuthWebCoreModule))]
    public class AuthWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AuthWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AuthWebHostModule).GetAssembly());
        }
    }
}

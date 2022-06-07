using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HospitalManagement.Business.Configuration;

namespace HospitalManagement.Business.Web.Host.Startup
{
    [DependsOn(
       typeof(BusinessWebCoreModule))]
    public class BusinessWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BusinessWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BusinessWebHostModule).GetAssembly());
        }
    }
}

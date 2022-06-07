using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HospitalManagement.Auth.EntityFrameworkCore;
using HospitalManagement.Auth.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace HospitalManagement.Auth.Web.Tests
{
    [DependsOn(
        typeof(AuthWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class AuthWebTestModule : AbpModule
    {
        public AuthWebTestModule(AuthEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AuthWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(AuthWebMvcModule).Assembly);
        }
    }
}
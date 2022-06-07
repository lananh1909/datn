using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HospitalManagement.Business.EntityFrameworkCore;
using HospitalManagement.Business.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace HospitalManagement.Business.Web.Tests
{
    [DependsOn(
        typeof(BusinessWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class BusinessWebTestModule : AbpModule
    {
        public BusinessWebTestModule(BusinessEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BusinessWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BusinessWebMvcModule).Assembly);
        }
    }
}
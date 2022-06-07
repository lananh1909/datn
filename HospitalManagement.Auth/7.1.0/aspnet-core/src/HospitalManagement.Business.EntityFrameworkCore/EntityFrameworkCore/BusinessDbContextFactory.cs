using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using HospitalManagement.Business.Configuration;
using HospitalManagement.Business.Web;

namespace HospitalManagement.Business.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class BusinessDbContextFactory : IDesignTimeDbContextFactory<BusinessDbContext>
    {
        public BusinessDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BusinessDbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            BusinessDbContextConfigurer.Configure(builder, configuration.GetConnectionString(BusinessConsts.ConnectionStringName));

            return new BusinessDbContext(builder.Options);
        }
    }
}

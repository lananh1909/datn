using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using HospitalManagement.Business.Authorization.Roles;
using HospitalManagement.Business.Authorization.Users;
using HospitalManagement.Business.MultiTenancy;

namespace HospitalManagement.Business.EntityFrameworkCore
{
    public class BusinessDbContext : AbpZeroDbContext<Tenant, Role, User, BusinessDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public BusinessDbContext(DbContextOptions<BusinessDbContext> options)
            : base(options)
        {
        }
    }
}

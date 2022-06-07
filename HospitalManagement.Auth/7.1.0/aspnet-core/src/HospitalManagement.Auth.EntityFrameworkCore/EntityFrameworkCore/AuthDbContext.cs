using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using HospitalManagement.Auth.Authorization.Roles;
using HospitalManagement.Auth.Authorization.Users;
using HospitalManagement.Auth.MultiTenancy;

namespace HospitalManagement.Auth.EntityFrameworkCore
{
    public class AuthDbContext : AbpZeroDbContext<Tenant, Role, User, AuthDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }
    }
}

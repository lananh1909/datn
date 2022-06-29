using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using HospitalManagement.Auth.Authorization.Roles;
using HospitalManagement.Auth.Authorization.Users;
using HospitalManagement.Auth.MultiTenancy;
using Abp.IdentityServer4;

namespace HospitalManagement.Auth.EntityFrameworkCore
{
    public class AuthDbContext : AbpZeroDbContext<Tenant, Role, User, AuthDbContext>, IAbpPersistedGrantDbContext
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<PersistedGrantEntity> PersistedGrants { get; set; }

        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigurePersistedGrantEntity();
        }
    }
}

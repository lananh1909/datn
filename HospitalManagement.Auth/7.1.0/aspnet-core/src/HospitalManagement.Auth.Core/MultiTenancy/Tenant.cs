using Abp.MultiTenancy;
using HospitalManagement.Auth.Authorization.Users;

namespace HospitalManagement.Auth.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}

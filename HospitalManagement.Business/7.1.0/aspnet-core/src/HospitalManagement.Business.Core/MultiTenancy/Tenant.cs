using Abp.MultiTenancy;
using HospitalManagement.Business.Authorization.Users;

namespace HospitalManagement.Business.MultiTenancy
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

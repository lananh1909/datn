using Abp.Authorization.Users;
using Abp.MultiTenancy;

namespace HospitalManagement.Business.MultiTenancy
{
    public class Tenant : AbpTenant<AbpUserBase>
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

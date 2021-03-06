using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using HospitalManagement.Auth.MultiTenancy;

namespace HospitalManagement.Auth.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}

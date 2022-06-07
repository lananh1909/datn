using Abp.Application.Services;
using HospitalManagement.Auth.MultiTenancy.Dto;

namespace HospitalManagement.Auth.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


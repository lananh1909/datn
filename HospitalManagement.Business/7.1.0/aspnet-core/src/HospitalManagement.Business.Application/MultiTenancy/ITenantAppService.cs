using Abp.Application.Services;
using HospitalManagement.Business.MultiTenancy.Dto;

namespace HospitalManagement.Business.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


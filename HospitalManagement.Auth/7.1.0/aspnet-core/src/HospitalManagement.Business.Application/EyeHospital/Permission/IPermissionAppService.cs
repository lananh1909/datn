using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    public interface IPermissionAppService : IAsyncCrudAppService<PermissionDto, Guid, PermissionPagedAndSortDto, PermissionAddAndUpdateDto>
    {
        Task UpdateRolePermission(UpdateRolePermissionDto input);
        Task<List<PermissionDto>> GetByRole(string role);
    }
}

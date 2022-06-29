using Abp.Application.Services;
using HospitalManagement.Business.Entities;
using HospitalManagement.Business.Repositories;
using HospitalManagement.Business.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    [Authorize]
    public class PermissionAppService : AsyncCrudAppService<AppPermission, PermissionDto, Guid, PermissionPagedAndSortDto, PermissionAddAndUpdateDto>, IPermissionAppService
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IUserInfo _userInfo;
        public PermissionAppService(IPermissionRepository permissionRepository, IUserInfo userInfo) : base(permissionRepository)
        {
            _permissionRepository = permissionRepository;
            _userInfo = userInfo;
        }

        public async Task UpdateRolePermission(UpdateRolePermissionDto input)
        {
            var oldPermissions = await _permissionRepository.GetAll().Where(p => p.Role == input.Role).ToListAsync();

            foreach (var item in oldPermissions)    
            {
                var dto = ObjectMapper.Map<PermissionDto>(item);
                await DeleteAsync(dto);
            }
            foreach (var item in input.Permissions) 
            {
                await CreateAsync(new PermissionAddAndUpdateDto()
                {
                    Name = item,
                    Role = input.Role
                });
            }
        }

        public async Task<List<PermissionDto>> GetByRole(string role)
        {
            var permissions = await _permissionRepository.GetAll().Where(p => p.Role == role).ToListAsync();
            return ObjectMapper.Map<List<PermissionDto>>(permissions);
        }
    }
}

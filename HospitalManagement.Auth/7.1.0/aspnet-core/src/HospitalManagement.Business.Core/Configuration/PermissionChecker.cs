using Abp;
using Abp.Authorization;
using Abp.Dependency;
using HospitalManagement.Business.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.Configuration
{
    public class PermissionChecker : IPermissionChecker, ITransientDependency
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPermissionRepository _permissionRepository;

        public PermissionChecker(IHttpContextAccessor httpContextAccessor, IPermissionRepository permissionRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _permissionRepository = permissionRepository;
        }

        public bool IsGranted(string permissionName)
        {
            throw new NotImplementedException();
        }

        public bool IsGranted(UserIdentifier user, string permissionName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsGrantedAsync(string permissionName)
        {
            // Get user
            var user = _httpContextAccessor.HttpContext.User;

            // Get claims of type "role"
            var roleClaims = user.Claims.Where(claim => claim.Type == ClaimTypes.Role);

            // Check for applicable permission based on role permissions
            // ...
            var isValid = false;
            foreach (var role in roleClaims)
            {
                isValid = await _permissionRepository.CheckRolePermission(role.Value, permissionName);
                if (isValid) { break; }
            }
            return isValid;
        }

        public async Task<bool> IsGrantedAsync(UserIdentifier user, string permissionName)
        {
            return await IsGrantedAsync(permissionName);
        }
    }
}

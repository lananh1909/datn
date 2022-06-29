using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using HospitalManagement.Business.Entities;
using HospitalManagement.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EntityFrameworkCore.Repositories
{
    public class PermissionRepository : BusinessRepositoryBase<AppPermission, Guid>, IPermissionRepository
    {
        public PermissionRepository(IDbContextProvider<BusinessDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        [UnitOfWork]
        public async Task<bool> CheckRolePermission(string role, string permission)
        {
            return this.GetAll().Where(p => p.Role == role && p.Name == permission).Any();
        }
    }
}

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
    public class EmployeeRepository : BusinessRepositoryBase<Employee, Guid>, IEmployeeRepository
    {
        public EmployeeRepository(IDbContextProvider<BusinessDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<string> GetNewEmployeeCode()
        {
            var maxCode = GetQueryable().Max(e => Convert.ToInt32(e.EmployeeCode.Substring(3, e.EmployeeCode.Length - 3)));
            var newCode = maxCode + 1;
            return string.Concat(Constants.EMPLOYEE_CODE_PREFIX, newCode);
        }

        private int ExtractCode(string code)
        {
            return Convert.ToInt32(code.Substring(4, code.Length - 3));
        }
    }
}

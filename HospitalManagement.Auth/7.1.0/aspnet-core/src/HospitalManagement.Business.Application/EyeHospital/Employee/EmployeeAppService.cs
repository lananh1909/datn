using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;
using HospitalManagement.Business.Entities;
using HospitalManagement.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    public class EmployeeAppService : AsyncCrudAppService<Employee, EmployeeDto, Guid, EmployeePagedAndSortDto, EmployeeAddAndUpdateDto>, IEmployeeAppService
    {
        public EmployeeAppService(IEmployeeRepository employeeRepository) :base(employeeRepository)
        {

        }

        public async Task DeleteManyAsync(List<Guid> ids)
        {
            foreach (var id in ids)
            {
                var employee = await this.GetAsync(new EntityDto<Guid>(id));
                await this.DeleteAsync(employee);
            }
        }

        protected override IQueryable<Employee> CreateFilteredQuery(EmployeePagedAndSortDto input)
        {
            return Repository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword), x => x.PhoneNumber.Contains(input.Keyword) || x.Name.Contains(input.Keyword) || x.EmployeeCode.Contains(input.Keyword)).WhereIf(input.JobTitle != 0, x => ((int)x.JobTitle == input.JobTitle));
        }

        protected override IQueryable<Employee> ApplySorting(IQueryable<Employee> query, EmployeePagedAndSortDto input)
        {
            var sortBy = "EmployeeCode";
            if (!string.IsNullOrEmpty(input.SortBy))
            {
                sortBy = input.SortBy + " " + input.SortType;
            }
            input.Sorting = sortBy;
            return base.ApplySorting(query, input);
        }
    }
}

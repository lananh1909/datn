using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using HospitalManagement.Business.Entities;
using HospitalManagement.Business.Repositories;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital.HospitalTracking
{
    [Authorize]
    public class ServiceAppService : AsyncCrudAppService<Service, ServiceDto, Guid, ServicePagedAndSortDto>, IServiceAppService
    {
        public ServiceAppService(IServiceRepository repository) : base(repository)
        {
        }

        public async Task DeleteManyAsync(List<Guid> ids)
        {
            foreach (var id in ids)
            {
                var service = await this.GetAsync(new EntityDto<Guid>(id));
                await this.DeleteAsync(service);
            }
        }

        protected override IQueryable<Service> CreateFilteredQuery(ServicePagedAndSortDto input)
        {
            return Repository.GetAll().Where(p => p.IsDeleted == false)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword), x => x.Name.Contains(input.Keyword));
        }

        protected override IQueryable<Service> ApplySorting(IQueryable<Service> query, ServicePagedAndSortDto input)
        {
            var sortBy = "Name";
            if (!string.IsNullOrEmpty(input.SortBy))
            {
                sortBy = input.SortBy + " " + input.SortType;
            }
            input.Sorting = sortBy;
            return base.ApplySorting(query, input);
        }
    }
}

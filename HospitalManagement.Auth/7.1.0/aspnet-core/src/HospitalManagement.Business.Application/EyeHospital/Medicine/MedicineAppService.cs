using Abp.Application.Services;
using Abp.Domain.Repositories;
using HospitalManagement.Business.Entities;
using HospitalManagement.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital.HospitalTracking
{
    public class MedicineAppService : AsyncCrudAppService<Medicine, MedicineDto, Guid, MedicinePagedAndSortDto>
    {
        private readonly IMedicineRepository _medicineRepository;
        public MedicineAppService(IMedicineRepository repository) : base(repository)
        {
            _medicineRepository = repository;
        }
        protected override IQueryable<Medicine> CreateFilteredQuery(MedicinePagedAndSortDto input)
        {
            return _medicineRepository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword), x => x.Name.Contains(input.Keyword)).Where(x => x.IsDeleted == false);
        }
    }
}

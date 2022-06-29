using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using HospitalManagement.Business.Entities;
using HospitalManagement.Business.Repositories;
using HospitalManagement.Business.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital.HospitalTracking
{
    public class HospitalizationTrackingAppService : AsyncCrudAppService<HospitalizationTracking, HospitalizationTrackingDto, Guid, PagedAndSortedResultRequestDto, HospitalizationTrackingAddAndUpdateDto>
    {
        private readonly IHospitalizationTrackingRepository _repository;
        private readonly IUserInfo _userInfo;
        private readonly IEmployeeAppService _employeeAppService;
        public HospitalizationTrackingAppService(IHospitalizationTrackingRepository repository, IUserInfo userInfo, IEmployeeAppService employeeAppService) : base(repository)
        {
            _repository = repository;
            _userInfo = userInfo;
            _employeeAppService = employeeAppService;
        }

        protected override IQueryable<HospitalizationTracking> ApplySorting(IQueryable<HospitalizationTracking> query, PagedAndSortedResultRequestDto input)
        {
            input.Sorting = "Time DESC";
            return base.ApplySorting(query, input);
        }

        protected override IQueryable<HospitalizationTracking> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return _repository.GetAllIncluding(p => p.Doctor).Where(p => p.IsDeleted == false);
        }

        public override async Task<HospitalizationTrackingDto> CreateAsync(HospitalizationTrackingAddAndUpdateDto input)
        {
            var doctor = await _employeeAppService.GetByUserId(_userInfo.UserId);
            if(doctor == null)
            {
                throw new UnauthorizedAccessException();
            }
            input.DoctorId = doctor.Id;
            input.Time = DateTime.UtcNow;
            return await base.CreateAsync(input);
        }
        public override Task<HospitalizationTrackingDto> UpdateAsync(HospitalizationTrackingAddAndUpdateDto input)
        {
            return base.UpdateAsync(input);
        }
    }
}

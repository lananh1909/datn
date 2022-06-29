using Abp.Application.Services;
using Abp.Application.Services.Dto;
using HospitalManagement.Business.Entities;
using HospitalManagement.Business.Repositories;
using HospitalManagement.Business.User;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    [Authorize]
    public class PatientAppService : AsyncCrudAppService<Patient, PatientDto, Guid, PatientPagedAndSortDto, PatientAddAndUpdateDto>, IPatientAppService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUserInfo _userInfo;
        public PatientAppService(IPatientRepository patientRepository, IUserInfo userInfo) : base(patientRepository)
        {
            _patientRepository = patientRepository;
            _userInfo = userInfo;
        }

        public async Task<PatientDto> GetExistPatient()
        {
            var userId = _userInfo.UserId;
            var patient = await _patientRepository.FirstOrDefaultAsync(p => p.UserId == userId && p.IsSelf && p.IsDeleted == false);
            return ObjectMapper.Map<PatientDto>(patient);
        }

        protected override IQueryable<Patient> CreateFilteredQuery(PatientPagedAndSortDto input)
        {
            return Repository.GetAll().Where(p => p.IsDeleted == false)
                .WhereIf(!string.IsNullOrWhiteSpace(input.KeyWord), x => x.PhoneNumber.Contains(input.KeyWord) || x.Name.Contains(input.KeyWord) || x.PatientCode.Contains(input.KeyWord));
        }

        protected override IQueryable<Patient> ApplySorting(IQueryable<Patient> query, PatientPagedAndSortDto input)
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

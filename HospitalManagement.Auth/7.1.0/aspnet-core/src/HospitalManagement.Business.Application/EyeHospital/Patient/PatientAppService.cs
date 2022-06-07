using Abp.Application.Services;
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
            var patient = await _patientRepository.FirstOrDefaultAsync(p => p.UserId == userId && p.IsSelf);
            return ObjectMapper.Map<PatientDto>(patient);
        }
    }
}

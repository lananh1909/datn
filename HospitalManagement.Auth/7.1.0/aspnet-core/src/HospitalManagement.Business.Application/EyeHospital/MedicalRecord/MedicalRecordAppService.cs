using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;
using HospitalManagement.Business.Entities;
using HospitalManagement.Business.Repositories;
using HospitalManagement.Business.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    public class MedicalRecordAppService : AsyncCrudAppService<MedicalRecord, MedicalRecordDto, Guid, MedicalRecordPagedAndSortDto, MedicalRecordAddAndUpdateDto>
    {
        private readonly IUserInfo _userInfo;
        private readonly IMedicalRecordRepository _medicalRecordRepository;
        public MedicalRecordAppService(IMedicalRecordRepository medicalRecordRepository, IUserInfo userInfo) : base(medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
            _userInfo = userInfo;
        }

        public async Task<PagedResultDto<MedicalRecordDto>> GetUserRecord(MedicalRecordPagedAndSortDto input)
        {
            try
            {
                var records = await _medicalRecordRepository.GetAllIncluding(p => p.Patient).Where(p => p.Patient.UserId == _userInfo.UserId).WhereIf(input.FromDate != null && input.ToDate != null, p => p.StartDate.CompareTo(input.FromDate.Value) >= 0 && p.StartDate.CompareTo(input.ToDate.Value) < 0).OrderBy(p => p.StartDate).PageBy(input).ToListAsync();
                return new PagedResultDto<MedicalRecordDto>()
                {
                    Items = ObjectMapper.Map<List<MedicalRecordDto>>(records),
                    TotalCount = records.Count()
                };
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

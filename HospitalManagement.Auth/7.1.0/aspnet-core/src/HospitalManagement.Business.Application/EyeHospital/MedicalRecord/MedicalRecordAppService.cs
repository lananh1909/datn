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
using Volo.Abp;

namespace HospitalManagement.Business.EyeHospital
{
    public class MedicalRecordAppService : AsyncCrudAppService<MedicalRecord, MedicalRecordDto, Guid, MedicalRecordPagedAndSortDto, MedicalRecordAddAndUpdateDto>
    {
        private readonly IUserInfo _userInfo;
        private readonly IMedicalRecordRepository _medicalRecordRepository;
        private readonly IEmployeeRepository _employeeRespository;
        private readonly IAppointmentRepository _appointmentRepository;
        public MedicalRecordAppService(IMedicalRecordRepository medicalRecordRepository, IUserInfo userInfo, IEmployeeRepository employeeRespository, IAppointmentRepository appointmentRepository) : base(medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
            _userInfo = userInfo;
            _employeeRespository = employeeRespository;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<PagedResultDto<MedicalRecordDto>> GetUserRecord(MedicalRecordPagedAndSortDto input)
        {
            try
            {
                if(input.FromDate != null && input.ToDate != null)
                {
                    var records = _medicalRecordRepository.GetAllIncluding(p => p.Patient).Where(p => p.IsDeleted == false).Where(p => p.Patient.UserId == _userInfo.UserId).Where(p => p.StartDate.CompareTo(input.FromDate.Value) >= 0 && p.StartDate.CompareTo(input.ToDate.Value) < 0).OrderBy(p => p.StartDate);
                    return new PagedResultDto<MedicalRecordDto>()
                    {
                        Items = ObjectMapper.Map<List<MedicalRecordDto>>(records.PageBy(input).ToListAsync()),
                        TotalCount = records.Count()
                    };
                } else
                {
                    var records = _medicalRecordRepository.GetAllIncluding(p => p.Patient).Where(p => p.IsDeleted == false).Where(p => p.Patient.UserId == _userInfo.UserId).OrderBy(p => p.StartDate);
                    return new PagedResultDto<MedicalRecordDto>()
                    {
                        Items = ObjectMapper.Map<List<MedicalRecordDto>>(records.PageBy(input).ToListAsync()),
                        TotalCount = records.Count()
                    };
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MedicalRecordDto> GetAppointmentMedicalRecord(Guid appointmentId)
        {
            var medicalRecord = _medicalRecordRepository.GetAll().Where(p => p.IsDeleted == false).Where(p => p.AppointmentId.Equals(appointmentId)).FirstOrDefault();
            return ObjectMapper.Map<MedicalRecordDto>(medicalRecord);
        }

        public async Task<MedicalRecordDto> CreateOrUpdateMedicalRecord(MedicalRecordAddAndUpdateDto input)
        {
            if(input.Id.Equals(Guid.Empty))
            {
                //Thêm mới
                input.StartDate = DateTime.Now;
                var doctor = _employeeRespository.GetAll().Where(p => p.UserId == _userInfo.UserId).FirstOrDefault();
                input.CreatedBy = doctor.Id;
                var result = await _medicalRecordRepository.InsertAsync(MapToEntity(input));
                return ObjectMapper.Map<MedicalRecordDto>(result);
            } else
            {
                //Cập nhập
                var result = await _medicalRecordRepository.UpdateAsync(MapToEntity(input));
                return ObjectMapper.Map<MedicalRecordDto>(result);
            }
        }

        public async Task<MedicalRecordDto> UpdateHospitalize(UpdateHospitalizeDto input)
        {
            var medicalRecord = await _medicalRecordRepository.GetAsync(input.Id);
            if(medicalRecord == null)
            {
                throw new BusinessException(ErrorConstants.BadRequestErrorCode, ErrorConstants.BadRequestErrorMessage);
            }
            medicalRecord.IsHospitalize = input.IsHospitalize;
            medicalRecord.FromDateHospitalize = input.FromDateHospitalize;
            medicalRecord.ToDateHospitalize = input.ToDateHospitalize;
            return await this.UpdateAsync(ObjectMapper.Map<MedicalRecordAddAndUpdateDto>(medicalRecord));
        } 
        public async Task<PagedResultDto<MedicalRecordDto>> GetMedicalHistory(MedicalRecordPagedAndSortDto input)
        {
            var records = _medicalRecordRepository.GetAllIncluding(p => p.Patient, p => p.Employee, p => p.Appointment, p => p.Appointment.Service).Where(p => p.PatientId == input.PatientId).Where(p => p.IsDeleted == false).Where(p => p.EndDate < DateTime.Now);
            return new PagedResultDto<MedicalRecordDto>()
            {
                Items = ObjectMapper.Map<List<MedicalRecordDto>>(records.PageBy(input).ToList()),
                TotalCount = records.Count(),
            };
        }

        public async Task<bool> UpdateDoneMedical(Guid id)
        {
            var medicalRecord = await _medicalRecordRepository.GetAsync(id);
            if(medicalRecord == null)
            {
                throw new BusinessException(ErrorConstants.BadRequestErrorCode, ErrorConstants.BadRequestErrorMessage);
            }
            medicalRecord.EndDate = DateTime.UtcNow;
            await _appointmentRepository.UpdateAppointmentStatus(medicalRecord.AppointmentId.Value, 3);
            await _medicalRecordRepository.UpdateAsync(medicalRecord);
            return true;
        }
    }
}

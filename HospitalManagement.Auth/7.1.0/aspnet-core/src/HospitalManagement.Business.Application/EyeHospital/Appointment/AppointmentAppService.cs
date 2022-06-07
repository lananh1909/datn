﻿using Abp.Application.Services;
using HospitalManagement.Business.Entities;
using HospitalManagement.Business.Enums;
using HospitalManagement.Business.Repositories;
using HospitalManagement.Business.User;
using HospitalManagement.Business.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    [Authorize]
    public class AppointmentAppService : AsyncCrudAppService<Appointment, AppointmentDto, Guid, AppointmentPagedAndSortDto, AppointmentAddAndUpdateDto>
    {
        private readonly IPatientAppService _patientAppService;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUserInfo _userInfo;
        public AppointmentAppService(IAppointmentRepository appointmentRepository, IPatientAppService patientAppService, IUserInfo userInfo) : base(appointmentRepository)
        {
            _patientAppService = patientAppService;
            _userInfo = userInfo;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<AppointmentDto> PatientBookAppointment(PatientAppointmentDto input)
        {
            if(input.BookFor == Constants.BOOK_FOR_ME)
            {
                var existPatient = await _patientAppService.GetExistPatient();
                if(existPatient == null)
                {
                    var patientCode = CommonHelper.GennerateCode(Constants.PATIENT_CODE_PREFIX);
                    existPatient = await _patientAppService.CreateAsync(new PatientAddAndUpdateDto()
                    {
                        Address = input.Address,
                        Birthday = input.Birthday,
                        Name = input.Name,
                        PhoneNumber = input.PhoneNumber,
                        Sex = input.Gender,
                        PatientCode = patientCode,
                        UserId = _userInfo.UserId,
                        IsSelf = true
                    });
                } else
                {
                    existPatient.Sex = input.Gender;
                    existPatient.PhoneNumber = input.PhoneNumber;
                    existPatient.Name = input.Name;
                    existPatient.Birthday = input.Birthday;
                    existPatient.Address = input.Address;
                    await _patientAppService.UpdateAsync(ObjectMapper.Map<PatientAddAndUpdateDto>(existPatient));
                }
                return await this.CreateAsync(new AppointmentAddAndUpdateDto()
                {
                    DescribeSymptom = input.DescribeSymptom,
                    DoctorId = input.DoctorId,
                    PatientId = existPatient.Id,
                    ServiceId = input.ServiceId,
                    Status = (int)AppointmentStatus.NEW,
                    Time = input.Time,
                    Date = input.Date
                });
            } else
            {
                var patientCode = CommonHelper.GennerateCode(Constants.PATIENT_CODE_PREFIX);
                var newPatient = await _patientAppService.CreateAsync(new PatientAddAndUpdateDto()
                {
                    Address = input.Address,
                    Birthday = input.Birthday,
                    Name = input.Name,
                    PhoneNumber = input.PhoneNumber,
                    Sex = input.Gender,
                    PatientCode = patientCode,
                    UserId = _userInfo.UserId,
                    IsSelf = false
                });
                return await this.CreateAsync(new AppointmentAddAndUpdateDto()
                {
                    DescribeSymptom = input.DescribeSymptom,
                    DoctorId = input.DoctorId,
                    PatientId = newPatient.Id,
                    ServiceId = input.ServiceId,
                    Status = (int)AppointmentStatus.NEW,
                    Time = input.Time,
                    Date = input.Date
                });
            }
        }

        public async Task<List<AppointmentDto>> GetUserAppointment()
        {
            var appointments = await _appointmentRepository.GetAllIncluding(p => p.Patient, p => p.Doctor, p => p.Service).Where(p => p.Patient.UserId == _userInfo.UserId).ToListAsync();
            return ObjectMapper.Map<List<AppointmentDto>>(appointments);
        }
    }
}

using Abp.AutoMapper;
using HospitalManagement.Business.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    [AutoMap(typeof(Surgery))]
    public class SurgeryAddAndUpdateDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public Guid SurgeryTypeId { get; set; }
        public Guid MedicalRecordId { get; set; }
        public int Status { get; set; }
        public List<DoctorSurgeryDto> Doctors { get; set; }
    }
    //[AutoMap(typeof(Surgery))]
    public class SurgeryUpdateDto
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public Guid SurgeryTypeId { get; set; }
        public int Status { get; set; }
        public List<string> SurgeryDoctors { get; set; }
        public IFormFile AttackFile { get; set; }
    }


    public class DoctorSurgeryDto
    {
        /// <summary>
        /// Id bác sĩ
        /// </summary>
        public Guid DoctorId { get; set; }
        /// <summary>
        /// Vai trò
        /// </summary>
        public string Role { get; set; }
    }
}

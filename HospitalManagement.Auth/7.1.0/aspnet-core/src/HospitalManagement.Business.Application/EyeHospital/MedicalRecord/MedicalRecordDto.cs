using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using HospitalManagement.Business.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    [AutoMap(typeof(MedicalRecord))]
    public class MedicalRecordDto : FullAuditedEntityDto<Guid>
    {
        public string Diagnosis { get; set; }
        public string Symptom { get; set; }
        public string StreatmentMethod { get; set; }
        public string Reason { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Employee Employee { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        /// <summary>
        /// Có phải điều trị nội trú hay không
        /// </summary>
        public bool IsHospitalize { get; set; } = false;
        /// <summary>
        /// ĐIều trị nội trú từ ngày
        /// </summary>
        public DateTime? FromDateHospitalize { get; set; }
        /// <summary>
        /// Đến ngày
        /// </summary>
        public DateTime? ToDateHospitalize { get; set; }
    }
}

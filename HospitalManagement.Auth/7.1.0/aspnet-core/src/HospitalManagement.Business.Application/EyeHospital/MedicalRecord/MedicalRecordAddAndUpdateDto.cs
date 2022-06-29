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
    public class MedicalRecordAddAndUpdateDto : EntityDto<Guid>
    {
        public string Diagnosis { get; set; }
        public string Symptom { get; set; }
        public string StreatmentMethod { get; set; }
        public string Reason { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid PatientId { get; set; }
        public Guid AppointmentId { get; set; }
    }
}

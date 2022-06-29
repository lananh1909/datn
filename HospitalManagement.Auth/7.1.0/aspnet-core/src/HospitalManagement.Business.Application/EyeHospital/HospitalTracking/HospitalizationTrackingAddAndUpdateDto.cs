using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using HospitalManagement.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    [AutoMap(typeof(HospitalizationTracking))]
    public class HospitalizationTrackingAddAndUpdateDto : EntityDto<Guid>
    {
        public Guid MedicalRecordId { get; set; }
        public string Content { get; set; }
        public string Command { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime Time { get; set; }
    }
}

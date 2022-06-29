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
    [AutoMap(typeof(Surgery))]
    public class SurgeryDto : FullAuditedEntityDto<Guid>
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public Guid SurgeryTypeId { get; set; }
        public SurgeryType SurgeryType { get; set; }
        public Guid MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public int Status { get; set; }
        public string AttackUrl { get; set; }
        public IList<SurgeryDoctor> SurgeryDoctors { get; set; }
    }
}

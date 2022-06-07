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
    [AutoMap(typeof(Test))]
    public class TestDto : FullAuditedEntityDto<Guid>
    {
        public string Result { get; set; }
        public string FileUrl { get; set; }
        public Guid PerformedBy { get; set; }
        public Guid TestTypeId { get; set; }
        public Guid MedicalRecordId { get; set; }
    }
}

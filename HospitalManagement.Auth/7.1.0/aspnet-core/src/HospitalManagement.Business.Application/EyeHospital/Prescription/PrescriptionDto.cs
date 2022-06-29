using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using HospitalManagement.Business.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    [AutoMap(typeof(Prescription))]
    public class PrescriptionDto : FullAuditedEntityDto<Guid>
    {
        public Guid CreatedBy { get; set; }
        public Employee Employee { get; set; }
        public Guid MedicalRecordId { get; set; }
        public IList<PrescriptionMedicine> PrescriptionMedicines { get; set; }

    }
}

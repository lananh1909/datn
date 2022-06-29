using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    public class PrescriptionAddAndUpdateDto : EntityDto<Guid>
    {
        public Guid MedicalRecordId { get; set; }
        public List<PrescriptionMedicineAddDto> PrescriptionMedicines { get; set; }
    }
    public class PrescriptionMedicineAddDto
    {
        public Guid MedicineId { get; set; }
        public int Quantity { get; set; }
        public string Instruction { get; set; }
    }
}

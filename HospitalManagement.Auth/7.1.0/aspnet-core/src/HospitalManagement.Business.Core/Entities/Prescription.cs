using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.Entities
{
    /// <summary>
    /// Đơn thuốc
    /// </summary>
    [Table("prescription")]
    public class Prescription: FullAuditedEntity<Guid>
    {
        public Guid CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public Employee Employee { get; set; }
        public Guid MedicalRecordId { get; set; }
        [ForeignKey("MedicalRecordId")]
        public MedicalRecord MedicalRecord { get; set; }
        public IList<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }
}

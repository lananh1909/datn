using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HospitalManagement.Business.Entities
{
    [Table("prescription_medicine")]
    public class PrescriptionMedicine : FullAuditedEntity<Guid>
    {
        public Guid MedicineId { get; set; }
        [ForeignKey("MedicineId")]
        public Medicine Medicine { get; set; }
        public Guid PrescriptionId { get; set; }
        [ForeignKey("PrescriptionId")]
        [JsonIgnore]
        [IgnoreDataMember]
        public Prescription Prescription { get; set; }
        public int Quantity { get; set; }
        public string Instruction { get; set; }
    }
}

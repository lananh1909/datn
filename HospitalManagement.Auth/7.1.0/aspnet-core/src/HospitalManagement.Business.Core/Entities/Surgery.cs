using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.Entities
{
    [Table("surgery")]
    public class Surgery: FullAuditedEntity<Guid>
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public Guid SurgeryTypeId { get; set; }
        [ForeignKey("SurgeryTypeId")]
        public SurgeryType SurgeryType { get; set; }
        public Guid MedicalRecordId { get; set; }
        [ForeignKey("MedicalRecordId")]
        public MedicalRecord MedicalRecord { get; set; }
        public int Status { get; set; }
        public string AttackUrl { get; set; }
        public IList<SurgeryDoctor> SurgeryDoctors { get; set; }
    }
}

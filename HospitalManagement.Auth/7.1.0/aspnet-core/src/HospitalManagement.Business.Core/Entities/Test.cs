using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.Entities
{
    [Table("test")]
    public class Test: FullAuditedEntity<Guid>
    {
        public string Result { get; set; }
        public string FileUrl { get; set; }
        public Guid PerformedBy { get; set; }
        [ForeignKey("PerformedBy")]
        public Employee Employee { get; set; }
        public Guid TestTypeId { get; set; }
        [ForeignKey("TestTypeId")]
        public TestType TestType { get; set; }
        public Guid MedicalRecordId { get; set; }
        [ForeignKey("MedicalRecordId")]
        public MedicalRecord MedicalRecord { get; set; }
    }
}

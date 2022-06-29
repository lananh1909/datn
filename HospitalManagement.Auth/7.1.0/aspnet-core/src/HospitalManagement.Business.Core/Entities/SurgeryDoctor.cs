using Abp.Domain.Entities;
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
    [Table("surgery_doctor")]
    public class SurgeryDoctor : FullAuditedEntity<Guid>
    {
        public Guid DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Employee Doctor { get; set; }
        public Guid SurgeryId { get; set; }
        [ForeignKey("SurgeryId")]
        [JsonIgnore]
        [IgnoreDataMember]
        public Surgery Surgery { get; set; }
        public string Role { get; set; }
        public bool IsDeleted { get ; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? CreatorUserId { get; set; }
        public long? LastModifierUserId { get; set; }
    }
}

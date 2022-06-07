using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
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
        public Surgery Surgery { get; set; }
        public string Role { get; set; }
    }
}

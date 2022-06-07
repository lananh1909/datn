using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.Entities
{
    [Table("hospitalization_tracking")]
    public class HospitalizationTracking : FullAuditedEntity<Guid>
    {
        public string Content { get; set; }
        public DateTime Time { get; set; }
        /// <summary>
        /// Y lệnh
        /// </summary>
        public string Command { get; set; }
        public Guid MedicalRecordId { get; set; }
        [ForeignKey("MedicalRecordId")]
        public MedicalRecord MedicalRecord { get; set; }
        public Guid DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Employee Doctor { get; set; }
    }
}

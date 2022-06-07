using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.Entities
{
    /// <summary>
    /// Thuốc
    /// </summary>
    [Table("medicine")]
    public class Medicine: FullAuditedEntity<Guid>
    {
        [Required]
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Nguồn gốc
        /// </summary>
        public string Origin { get; set; }
        public long Price { get; set; }
    }
}

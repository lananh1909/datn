using Abp.Domain.Entities.Auditing;
using HospitalManagement.Business.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.Entities
{
    [Table("employee")]
    public class Employee: FullAuditedEntity<Guid>
    {
        [Required]
        public string EmployeeCode { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }
        public EmployeeJobTitle JobTitle { get; set; }
        public string Specialized { get; set; }

    }
}

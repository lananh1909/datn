﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.Entities
{
    [Table("test_type")]
    public class TestType : FullAuditedEntity<Guid>
    {
        [Required]
        public string Name { get; set; }
        public long Cost { get; set; }
    }
}

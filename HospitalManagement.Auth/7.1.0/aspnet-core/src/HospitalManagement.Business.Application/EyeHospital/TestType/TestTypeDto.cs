using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using HospitalManagement.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    [AutoMap(typeof(TestType))]
    public class TestTypeDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public long Cost { get; set; }
    }
}

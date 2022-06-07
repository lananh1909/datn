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
    [AutoMap(typeof(Medicine))]
    public class MedicineDto : FullAuditedEntityDto<Guid>
    {
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

﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    public class MedicinePagedAndSortDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

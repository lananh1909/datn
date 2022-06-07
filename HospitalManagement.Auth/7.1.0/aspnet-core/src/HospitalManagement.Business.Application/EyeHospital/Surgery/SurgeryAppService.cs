﻿using Abp.Application.Services;
using Abp.Domain.Repositories;
using HospitalManagement.Business.Entities;
using HospitalManagement.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital.HospitalTracking
{
    public class SurgeryAppService : AsyncCrudAppService<Surgery, SurgeryDto, Guid>
    {
        public SurgeryAppService(ISurgeryRepository repository) : base(repository)
        {
        }
    }
}

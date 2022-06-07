using Abp.Application.Services;
using Abp.Domain.Repositories;
using HospitalManagement.Business.Entities;
using HospitalManagement.Business.Repositories;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital.HospitalTracking
{
    [Authorize]
    public class ServiceAppService : AsyncCrudAppService<Service, ServiceDto, Guid>
    {
        public ServiceAppService(IServiceRepository repository) : base(repository)
        {
        }
    }
}

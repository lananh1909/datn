using Abp.Application.Services;
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
    public class PrescriptionAppService : AsyncCrudAppService<Prescription, PrescriptionDto, Guid>
    {
        public PrescriptionAppService(IPrescriptionRepository repository) : base(repository)
        {
        }
    }
}

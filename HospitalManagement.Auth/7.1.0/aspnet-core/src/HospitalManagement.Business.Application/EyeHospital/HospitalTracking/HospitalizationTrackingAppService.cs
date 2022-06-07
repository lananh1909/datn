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
    public class HospitalizationTrackingAppService : AsyncCrudAppService<HospitalizationTracking, HospitalizationTrackingDto, Guid>
    {
        public HospitalizationTrackingAppService(IHospitalizationTrackingRepository repository) : base(repository)
        {
        }
    }
}

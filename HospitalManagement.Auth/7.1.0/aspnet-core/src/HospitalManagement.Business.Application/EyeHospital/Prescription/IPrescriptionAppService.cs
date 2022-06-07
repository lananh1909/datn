using Abp.Application.Services;
using HospitalManagement.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    public interface IPrescriptionAppService : IAsyncCrudAppService<PrescriptionDto, Guid>
    {
    }
}

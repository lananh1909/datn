using Abp.Domain.Repositories;
using HospitalManagement.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.Repositories
{
    public interface ISurgeryTypeRepository : IRepository<SurgeryType, Guid>
    {
    }
}

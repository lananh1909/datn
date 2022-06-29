using Abp.Domain.Repositories;
using HospitalManagement.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.Repositories
{
    public interface IPrescriptionMedicineRepository : IRepository<PrescriptionMedicine, Guid>
    {
        Task DeleteByPrescriptionId(Guid id);
    }
}

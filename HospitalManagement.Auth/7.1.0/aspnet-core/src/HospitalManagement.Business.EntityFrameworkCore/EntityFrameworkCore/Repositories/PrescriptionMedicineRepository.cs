using Abp.EntityFrameworkCore;
using HospitalManagement.Business.Entities;
using HospitalManagement.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EntityFrameworkCore.Repositories
{
    public class PrescriptionMedicineRepository : BusinessRepositoryBase<PrescriptionMedicine, Guid>, IPrescriptionMedicineRepository
    {
        public PrescriptionMedicineRepository(IDbContextProvider<BusinessDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task DeleteByPrescriptionId(Guid id)
        {
            var medicines = base.GetAll().Where(p => p.PrescriptionId == id).ToList();
            foreach (var medicine in medicines)
            {
                await base.DeleteAsync(medicine.Id);
            }
        }
    }
}

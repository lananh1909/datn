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
    public class PatientRepository : BusinessRepositoryBase<Patient, Guid>, IPatientRepository
    {
        public PatientRepository(IDbContextProvider<BusinessDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}

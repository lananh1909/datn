﻿using Abp.EntityFrameworkCore;
using HospitalManagement.Business.Entities;
using HospitalManagement.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EntityFrameworkCore.Repositories
{
    public class HospitalizationTrackingRepository : BusinessRepositoryBase<HospitalizationTracking, Guid>, IHospitalizationTrackingRepository
    {
        public HospitalizationTrackingRepository(IDbContextProvider<BusinessDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}

using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    public interface IPatientAppService : IAsyncCrudAppService<PatientDto, Guid, PatientPagedAndSortDto, PatientAddAndUpdateDto>
    {
        /// <summary>
        /// Lấy thông tin bệnh nhân của người dùng
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<PatientDto> GetExistPatient();
    }
}

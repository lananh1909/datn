using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    public interface IAppointmentAppService : IAsyncCrudAppService<AppointmentDto, Guid, AppointmentPagedAndSortDto, AppointmentAddAndUpdateDto>
    {
    }
}

using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    public class AppointmentPagedAndSortDto : PagedAndSortedResultRequestDto
    {
        public bool IsAll { get; set; }
        public int Status { get; set; }
    }
}

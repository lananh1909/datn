using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    public class PatientPagedAndSortDto : PagedAndSortedResultRequestDto
    {
        public string KeyWord { get; set; }
        public string SortBy { get; set; }
        public string SortType { get; set; }
    }
}

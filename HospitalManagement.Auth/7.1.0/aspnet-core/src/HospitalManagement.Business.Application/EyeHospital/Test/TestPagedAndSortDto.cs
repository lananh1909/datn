using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    public class TestPagedAndSortDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
        public Guid? TestTypeId { get; set; }
        public int? Status { get; set; }
        public string SortBy { get; set; }
        public string SortType { get; set; }
    }
}

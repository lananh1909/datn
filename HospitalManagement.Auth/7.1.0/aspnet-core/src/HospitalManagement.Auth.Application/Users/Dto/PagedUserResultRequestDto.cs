using Abp.Application.Services.Dto;
using System;

namespace HospitalManagement.Auth.Users.Dto
{
    //custom PagedResultRequestDto
    public class PagedUserResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }

        public string SortBy { get; set; }
        public string SortType { get; set; }
        public int Role { get; set; }
    }
}

using Abp.Application.Services.Dto;

namespace HospitalManagement.Auth.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
        public string SortBy { get; set; }
        public string SortType { get; set; }
    }
}


using System.Threading.Tasks;
using Abp.Application.Services;
using HospitalManagement.Auth.Sessions.Dto;

namespace HospitalManagement.Auth.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

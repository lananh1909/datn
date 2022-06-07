using System.Threading.Tasks;
using Abp.Application.Services;
using HospitalManagement.Business.Sessions.Dto;

namespace HospitalManagement.Business.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

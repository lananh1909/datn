using System.Threading.Tasks;
using Abp.Application.Services;
using HospitalManagement.Auth.Authorization.Accounts.Dto;

namespace HospitalManagement.Auth.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

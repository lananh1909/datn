using System.Threading.Tasks;
using Abp.Application.Services;
using HospitalManagement.Business.Authorization.Accounts.Dto;

namespace HospitalManagement.Business.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

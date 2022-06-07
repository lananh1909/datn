using System.Threading.Tasks;
using HospitalManagement.Auth.Configuration.Dto;

namespace HospitalManagement.Auth.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

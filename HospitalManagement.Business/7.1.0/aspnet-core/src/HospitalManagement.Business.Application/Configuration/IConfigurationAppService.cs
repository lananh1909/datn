using System.Threading.Tasks;
using HospitalManagement.Business.Configuration.Dto;

namespace HospitalManagement.Business.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

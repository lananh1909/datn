using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using HospitalManagement.Auth.Configuration.Dto;

namespace HospitalManagement.Auth.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AuthAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

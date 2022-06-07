using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using HospitalManagement.Business.Configuration.Dto;

namespace HospitalManagement.Business.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BusinessAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

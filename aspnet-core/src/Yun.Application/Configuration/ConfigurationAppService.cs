using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Yun.Configuration.Dto;

namespace Yun.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : YunAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

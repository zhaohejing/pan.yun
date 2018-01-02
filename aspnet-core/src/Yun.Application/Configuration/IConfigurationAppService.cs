using System.Threading.Tasks;
using Yun.Configuration.Dto;

namespace Yun.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

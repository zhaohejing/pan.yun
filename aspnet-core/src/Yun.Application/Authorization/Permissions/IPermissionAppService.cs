using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Yun.Authorization.Permissions.Dto;

namespace Yun.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}

using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Yun.Roles.Dto;
using Yun.Users.Dto;

namespace Yun.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}

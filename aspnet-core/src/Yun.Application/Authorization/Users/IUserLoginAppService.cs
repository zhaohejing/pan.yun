using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Yun.Authorization.Users.Dto;

namespace Yun.Authorization.Users
{
    public interface IUserLoginAppService : IApplicationService
    {
        Task<ListResultDto<UserLoginAttemptDto>> GetRecentUserLoginAttempts();
    }
}

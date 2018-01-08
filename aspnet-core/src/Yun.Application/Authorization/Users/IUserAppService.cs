using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Yun.Authorization.Users.Dto;
using Yun.Dto;

namespace Yun.Authorization.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task<PagedResultDto<UserListDto>> GetUsers(GetUsersInput input);

  

        Task<GetUserForEditOutput> GetUserForEdit(NullableIdDto<long> input);

        Task<GetUserPermissionsForEditOutput> GetUserPermissionsForEdit(EntityDto<long> input);

        Task ResetUserSpecificPermissions(EntityDto<long> input);

        Task UpdateUserPermissions(UpdateUserPermissionsInput input);

        Task CreateOrUpdateUser(CreateOrUpdateUserInput input);

        Task DeleteUser(EntityDto<long> input);

    }
}
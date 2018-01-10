using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Yun.Dto;
using Yun.Friendships.Dto;

namespace Yun.Friendships
{
    public interface IFriendshipAppService : IApplicationService
    {
        /// <summary>
        /// 添加好友
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<FriendDto> CreateFriendshipRequest(CreateFriendshipRequestInput input);
        /// <summary>
        /// 添加还有通过姓名
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<FriendDto> CreateFriendshipRequestByUserName(CreateFriendshipRequestByUserNameInput input);
        /// <summary>
        /// 不同意
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task BlockUser(BlockUserInput input);
        /// <summary>
        /// 同意
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UnblockUser(UnblockUserInput input);
        /// <summary>
        /// 接受好友请求
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task AcceptFriendshipRequest(AcceptFriendshipRequestInput input);

        /// <summary>
        /// 获取好友列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<FriendDto>> GetUserFriends(PagedAndSortedInputDto input);
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.MultiTenancy;
using Abp.RealTime;
using Abp.Runtime.Session;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using Yun.Authorization.Users;
using Yun.Dto;
using Yun.Friendships.Dto;

namespace Yun.Friendships
{
    [AbpAuthorize]
    public class FriendshipAppService : YunAppServiceBase, IFriendshipAppService
    {
        private readonly IFriendshipManager _friendshipManager;
        private readonly IOnlineClientManager _onlineClientManager;
        private readonly IRepository<Friendship,long> _friendRepository;

        public FriendshipAppService(
            IFriendshipManager friendshipManager,
            IOnlineClientManager onlineClientManager, IRepository<Friendship, long> friendRepository)
        {
            _friendshipManager = friendshipManager;
            _onlineClientManager = onlineClientManager;
            _friendRepository = friendRepository;
        }

        public async Task<FriendDto> CreateFriendshipRequest(CreateFriendshipRequestInput input)
        {
            var userIdentifier = AbpSession.ToUserIdentifier();
            var probableFriend = new UserIdentifier(AbpSession.TenantId, input.UserId);


            if (await _friendshipManager.GetFriendshipOrNullAsync(userIdentifier, probableFriend) != null)
            {
                throw new UserFriendlyException(L("YouAlreadySentAFriendshipRequestToThisUser"));
            }
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            User 
            probableFriendUser = await UserManager.FindByIdAsync(input.UserId.ToString());

            var sourceFriendship = new Friendship(userIdentifier, probableFriend,
                probableFriendUser.UserName, probableFriendUser.HeadImage, FriendshipState.Accepted);
            await _friendshipManager.CreateFriendshipAsync(sourceFriendship);
            var targetFriendship = new Friendship(probableFriend, userIdentifier, user.UserName,
                user.HeadImage, FriendshipState.Accepted);
            await _friendshipManager.CreateFriendshipAsync(targetFriendship);
            var sourceFriendshipRequest = ObjectMapper.Map<FriendDto>(sourceFriendship);
            sourceFriendshipRequest.IsOnline = _onlineClientManager.GetAllByUserId(probableFriend).Any();
            return sourceFriendshipRequest;
        }
        /// <summary>
        /// 获取好友列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<FriendDto>> GetUserFriends(PagedAndSortedInputDto input)
        {
            var user = AbpSession.GetUserId();
            var query =  _friendRepository.GetAll().Where(c=>c.UserId==user);
            var userCount = await query.CountAsync();

            var friends = await query
                .OrderByDescending(c=>c.CreationTime)
                .PageBy(input)
                .ToListAsync();
            var dtos = ObjectMapper.Map<List<FriendDto>>(friends);
            return new PagedResultDto<FriendDto>(userCount, dtos);
        }

        public async Task<FriendDto> CreateFriendshipRequestByUserName(CreateFriendshipRequestByUserNameInput input)
        {
            var probableFriend = await GetUserIdentifier(input.UserName);
            return await CreateFriendshipRequest(new CreateFriendshipRequestInput
            {
                UserId = probableFriend.UserId
            });
        }

        public async Task BlockUser(BlockUserInput input)
        {
            var userIdentifier = AbpSession.ToUserIdentifier();
            var friendIdentifier = new UserIdentifier(input.TenantId, input.UserId);
            await _friendshipManager.BanFriendAsync(userIdentifier, friendIdentifier);
        }

        public async Task UnblockUser(UnblockUserInput input)
        {
            var userIdentifier = AbpSession.ToUserIdentifier();
            var friendIdentifier = new UserIdentifier(input.TenantId, input.UserId);
            await _friendshipManager.AcceptFriendshipRequestAsync(userIdentifier, friendIdentifier);
        }

        public async Task AcceptFriendshipRequest(AcceptFriendshipRequestInput input)
        {
            var userIdentifier = AbpSession.ToUserIdentifier();
            var friendIdentifier = new UserIdentifier(input.TenantId, input.UserId);
            await _friendshipManager.AcceptFriendshipRequestAsync(userIdentifier, friendIdentifier);
        }

        private async Task<UserIdentifier> GetUserIdentifier( string userName)
        {
            using (CurrentUnitOfWork.SetTenantId(1))
            {
                var user = await UserManager.FindByNameOrEmailAsync(userName);
                if (user == null)
                {
                    throw new UserFriendlyException("There is no such user !");
                }

                return user.ToUserIdentifier();
            }
        }
    }
}
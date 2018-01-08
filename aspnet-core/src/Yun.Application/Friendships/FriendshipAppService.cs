using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.Authorization;
using Abp.MultiTenancy;
using Abp.RealTime;
using Abp.Runtime.Session;
using Abp.UI;
using Yun.Authorization.Users;
using Yun.Friendships.Dto;

namespace Yun.Friendships
{
    [AbpAuthorize]
    public class FriendshipAppService : YunAppServiceBase, IFriendshipAppService
    {
        private readonly IFriendshipManager _friendshipManager;
        private readonly IOnlineClientManager _onlineClientManager;
        private readonly ITenantCache _tenantCache;

        public FriendshipAppService(
            IFriendshipManager friendshipManager,
            IOnlineClientManager onlineClientManager,
            ITenantCache tenantCache)
        {
            _friendshipManager = friendshipManager;
            _onlineClientManager = onlineClientManager;
            _tenantCache = tenantCache;
        }

        public async Task<FriendDto> CreateFriendshipRequest(CreateFriendshipRequestInput input)
        {
            var userIdentifier = AbpSession.ToUserIdentifier();
            var probableFriend = new UserIdentifier(input.TenantId, input.UserId);


            if (await _friendshipManager.GetFriendshipOrNullAsync(userIdentifier, probableFriend) != null)
            {
                throw new UserFriendlyException(L("YouAlreadySentAFriendshipRequestToThisUser"));
            }

            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());

            User probableFriendUser;
            using (CurrentUnitOfWork.SetTenantId(input.TenantId))
            {
                probableFriendUser = await UserManager.FindByIdAsync(input.UserId.ToString());
            }

            var friendTenancyName = probableFriend.TenantId.HasValue ? _tenantCache.Get(probableFriend.TenantId.Value).TenancyName : null;
            var sourceFriendship = new Friendship(userIdentifier, probableFriend, friendTenancyName,
                probableFriendUser.UserName, probableFriendUser.HeadImage, FriendshipState.Accepted);
            await _friendshipManager.CreateFriendshipAsync(sourceFriendship);

            var userTenancyName = user.TenantId.HasValue ? _tenantCache.Get(user.TenantId.Value).TenancyName : null;
            var targetFriendship = new Friendship(probableFriend, userIdentifier, userTenancyName, user.UserName,
                user.HeadImage, FriendshipState.Accepted);
            await _friendshipManager.CreateFriendshipAsync(targetFriendship);

            var clients = _onlineClientManager.GetAllByUserId(probableFriend);
            if (clients.Any())
            {
                var isFriendOnline = _onlineClientManager.IsOnline(sourceFriendship.ToUserIdentifier());
            }

            var senderClients = _onlineClientManager.GetAllByUserId(userIdentifier);
            if (senderClients.Any())
            {
                var isFriendOnline = _onlineClientManager.IsOnline(targetFriendship.ToUserIdentifier());
            }

            var sourceFriendshipRequest = ObjectMapper.Map<FriendDto>(sourceFriendship);
            sourceFriendshipRequest.IsOnline = _onlineClientManager.GetAllByUserId(probableFriend).Any();

            return sourceFriendshipRequest;
        }

        public async Task<FriendDto> CreateFriendshipRequestByUserName(CreateFriendshipRequestByUserNameInput input)
        {
            var probableFriend = await GetUserIdentifier(input.TenancyName, input.UserName);
            return await CreateFriendshipRequest(new CreateFriendshipRequestInput
            {
                TenantId = probableFriend.TenantId,
                UserId = probableFriend.UserId
            });
        }

        public async Task BlockUser(BlockUserInput input)
        {
            var userIdentifier = AbpSession.ToUserIdentifier();
            var friendIdentifier = new UserIdentifier(input.TenantId, input.UserId);
            await _friendshipManager.BanFriendAsync(userIdentifier, friendIdentifier);

            var clients = _onlineClientManager.GetAllByUserId(userIdentifier);
            if (clients.Any())
            {
            }
        }

        public async Task UnblockUser(UnblockUserInput input)
        {
            var userIdentifier = AbpSession.ToUserIdentifier();
            var friendIdentifier = new UserIdentifier(input.TenantId, input.UserId);
            await _friendshipManager.AcceptFriendshipRequestAsync(userIdentifier, friendIdentifier);

            var clients = _onlineClientManager.GetAllByUserId(userIdentifier);
            if (clients.Any())
            {
            }
        }

        public async Task AcceptFriendshipRequest(AcceptFriendshipRequestInput input)
        {
            var userIdentifier = AbpSession.ToUserIdentifier();
            var friendIdentifier = new UserIdentifier(input.TenantId, input.UserId);
            await _friendshipManager.AcceptFriendshipRequestAsync(userIdentifier, friendIdentifier);

            var clients = _onlineClientManager.GetAllByUserId(userIdentifier);
            if (clients.Any())
            {
            }
        }

        private async Task<UserIdentifier> GetUserIdentifier(string tenancyName, string userName)
        {
            int? tenantId = null;
            if (!tenancyName.Equals("."))
            {
                using (CurrentUnitOfWork.SetTenantId(null))
                {
                    var tenant = await TenantManager.FindByTenancyNameAsync(tenancyName);
                    if (tenant == null)
                    {
                        throw new UserFriendlyException("There is no such tenant !");
                    }

                    tenantId = tenant.Id;
                }
            }

            using (CurrentUnitOfWork.SetTenantId(tenantId))
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
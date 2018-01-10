using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.UI;

namespace Yun.Friendships
{
    public class FriendshipManager : YunDomainServiceBase, IFriendshipManager
    {
        private readonly IRepository<Friendship, long> _friendshipRepository;

        public FriendshipManager(IRepository<Friendship, long> friendshipRepository)
        {
            _friendshipRepository = friendshipRepository;
        }

        [UnitOfWork]
        public async Task CreateFriendshipAsync(Friendship friendship)
        {
            if (
                friendship.UserId == friendship.FriendUserId)
            {
                throw new UserFriendlyException(L("YouCannotBeFriendWithYourself"));
            }
        
                _friendshipRepository.Insert(friendship);
               await CurrentUnitOfWork.SaveChangesAsync();
        }



        [UnitOfWork]
        public async Task UpdateFriendshipAsync(Friendship friendship)
        {
         
                _friendshipRepository.Update(friendship);
                await CurrentUnitOfWork.SaveChangesAsync();
        }

        [UnitOfWork]
        public async Task<Friendship> GetFriendshipOrNullAsync(UserIdentifier user, UserIdentifier probableFriend)
        {
            using (CurrentUnitOfWork.SetTenantId(user.TenantId))
            {
                return await _friendshipRepository.FirstOrDefaultAsync(friendship =>
                                    friendship.UserId == user.UserId &&
                                    friendship.FriendUserId == probableFriend.UserId );
            }
        }

        [UnitOfWork]
        public async Task BanFriendAsync(UserIdentifier userIdentifier, UserIdentifier probableFriend)
        {
            var friendship = (await GetFriendshipOrNullAsync(userIdentifier, probableFriend));
            if (friendship == null)
            {
                throw new Exception("Friendship does not exist between " + userIdentifier + " and " + probableFriend);
            }

            friendship.State = FriendshipState.Blocked;
            await UpdateFriendshipAsync(friendship);
        }

        [UnitOfWork]
        public async Task AcceptFriendshipRequestAsync(UserIdentifier userIdentifier, UserIdentifier probableFriend)
        {
            var friendship = (await GetFriendshipOrNullAsync(userIdentifier, probableFriend));
            if (friendship == null)
            {
                throw new Exception("Friendship does not exist between " + userIdentifier + " and " + probableFriend);
            }

            friendship.State = FriendshipState.Accepted;
            await UpdateFriendshipAsync(friendship);
        }
    }
}
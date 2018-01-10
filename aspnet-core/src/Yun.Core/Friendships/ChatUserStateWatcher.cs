using System.Linq;
using Abp;
using Abp.Dependency;
using Abp.RealTime;
using Yun.Friendships.Cache;

namespace Yun.Friendships
{
    public class ChatUserStateWatcher : ISingletonDependency
    {
        private readonly IUserFriendsCache _userFriendsCache;
        private readonly IOnlineClientManager _onlineClientManager;

        public ChatUserStateWatcher(
            IUserFriendsCache userFriendsCache,
            IOnlineClientManager onlineClientManager)
        {
            _userFriendsCache = userFriendsCache;
            _onlineClientManager = onlineClientManager;
        }

        public void Initialize()
        {
            _onlineClientManager.UserConnected += OnlineClientManager_UserConnected;
            _onlineClientManager.UserDisconnected += OnlineClientManager_UserDisconnected;
        }

        private void OnlineClientManager_UserConnected(object sender, OnlineUserEventArgs e)
        {
            NotifyUserConnectionStateChange(e.User, true);
        }

        private void OnlineClientManager_UserDisconnected(object sender, OnlineUserEventArgs e)
        {
            NotifyUserConnectionStateChange(e.User, false);
        }

        private void NotifyUserConnectionStateChange(UserIdentifier user, bool isConnected)
        {
            var cacheItem = _userFriendsCache.GetCacheItem(user);
           
            foreach (var friend in cacheItem.Friends)
            {
                var friendUserClients = _onlineClientManager.GetAllByUserId(new UserIdentifier(1, friend.FriendUserId));
                if (!friendUserClients.Any())
                {
                    continue;
                }
            }
        }
    }
}
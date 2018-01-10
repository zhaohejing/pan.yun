using System.Collections.Generic;
using System.Linq;

namespace Yun.Friendships.Cache
{
    public static class FriendCacheItemExtensions
    {
        public static bool ContainsFriend(this List<FriendCacheItem> items, FriendCacheItem item)
        {
            return items.Any(f => f.FriendUserId == item.FriendUserId);
        }
    }
}

using System;

namespace Yun.Friendships.Dto
{
    public class FriendDto
    {
        public long UserId { get; set; }
        public long FriendUserId { get; set; }

        public string FriendUserName { get; set; }
        public string HeadImage { get; set; }

        public FriendshipState State { get; set; }

        public DateTime CreationTime { get; set; }
        public bool IsOnline { get; set; }
    }
}

using System;

namespace Yun.Friendships.Dto
{
    public class FriendDto
    {
        public long FriendUserId { get; set; }

        public string FriendUserName { get; set; }

        public Guid? FriendProfilePictureId { get; set; }
        public int UnreadMessageCount { get; set; }
        public bool IsOnline { get; set; }
        public FriendshipState State { get; set; }
    }
}

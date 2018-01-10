using System;
using Abp.AutoMapper;
using AutoMapper;

namespace Yun.Friendships.Dto
{
    [AutoMap(typeof(Friendship))]
    public class FriendDto
    {
        public long UserId { get; set; }
        public long FriendUserId { get; set; }

        public string FriendUserName { get; set; }
        public string HeadImage { get; set; }

        public FriendshipState State { get; set; }

        public DateTime CreationTime { get; set; }
        [IgnoreMap]
        public bool IsOnline { get; set; }
    }
}

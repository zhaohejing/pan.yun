using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp;
using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace Yun.Friendships
{
    [Table("Friendships")]
    public class Friendship : Entity<long>, IHasCreationTime, IMayHaveTenant
    {
        public long UserId { get; set; }

        public int? TenantId { get; set; }

        public long FriendUserId { get; set; }

        public int? FriendTenantId { get; set; }

        [Required]
        [MaxLength(AbpUserBase.MaxUserNameLength)]
        public string FriendUserName { get; set; }

        public string FriendTenancyName { get; set; }

        public string HeadImage { get; set; }

        public FriendshipState State { get; set; }

        public DateTime CreationTime { get; set; }

        public Friendship(UserIdentifier user, UserIdentifier probableFriend, 
            string probableFriendTenancyName,
            string probableFriendUserName,
            string headImage, FriendshipState state)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (probableFriend == null)
            {
                throw new ArgumentNullException(nameof(probableFriend));
            }

            if (!Enum.IsDefined(typeof(FriendshipState), state))
            {
                throw new Exception("Invalid FriendshipState value: " + state);
            }

            UserId = user.UserId;
            TenantId = user.TenantId;
            FriendUserId = probableFriend.UserId;
            FriendTenantId = probableFriend.TenantId;
            FriendTenancyName = probableFriendTenancyName;
            FriendUserName = probableFriendUserName;
            State = state;
            HeadImage = headImage;

            CreationTime = Clock.Now;
        }

        protected Friendship()
        {

        }
    }
    /// <summary>
    /// 好友状态
    /// </summary>
    public enum FriendshipState
    {
        Accepted = 1,
        Blocked = 2
    }
}

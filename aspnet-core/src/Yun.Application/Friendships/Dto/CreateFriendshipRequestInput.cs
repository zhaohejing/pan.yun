using System.ComponentModel.DataAnnotations;

namespace Yun.Friendships.Dto
{
    public class CreateFriendshipRequestInput
    {
        [Range(1, long.MaxValue)]
        public long UserId { get; set; }

    }
}
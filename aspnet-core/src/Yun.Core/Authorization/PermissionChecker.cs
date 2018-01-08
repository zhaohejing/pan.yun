using Abp.Authorization;
using Yun.Authorization.Roles;
using Yun.Authorization.Users;

namespace Yun.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}

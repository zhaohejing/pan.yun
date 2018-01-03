using System;
using Abp.Authorization.Users;
using Abp.Extensions;

namespace Yun.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "1234567";
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadImage { get; set; }
        private new string Surname { get; set; }

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress
            };

            user.SetNormalizedNames();

            return user;
        }
    }
}

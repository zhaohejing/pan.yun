using System;
using Abp;
using Abp.Authorization;
using Abp.Dependency;
using Abp.UI;

namespace Yun.Authorization
{
    public class AbpLoginResultTypeHelper : AbpServiceBase, ITransientDependency
    {
        public AbpLoginResultTypeHelper()
        {
            LocalizationSourceName = YunConsts.LocalizationSourceName;
        }

        public Exception CreateExceptionForFailedLoginAttempt(AbpLoginResultType result, string usernameOrEmailAddress, string tenancyName)
        {
            switch (result)
            {
                case AbpLoginResultType.Success:
                    return new Exception("Don't call this method with a success result!");

                case AbpLoginResultType.InvalidUserNameOrEmailAddress:
                case AbpLoginResultType.InvalidPassword:
                    return new UserFriendlyException("登陆失败", "用户名或密码错误");

                case AbpLoginResultType.InvalidTenancyName:
                    return new UserFriendlyException("登陆失败", $"租户不存在{tenancyName}");

                case AbpLoginResultType.TenantIsNotActive:
                    return new UserFriendlyException("登陆失败", "租户被禁用");

                case AbpLoginResultType.UserIsNotActive:
                    return new UserFriendlyException("登陆失败", "用户被禁用");

                case AbpLoginResultType.UserEmailIsNotConfirmed:
                    return new UserFriendlyException("登陆失败", "用户邮箱尚未验证");

                case AbpLoginResultType.LockedOut:
                    return new UserFriendlyException("登陆失败", "用户被锁定");

                default: // Can not fall to default actually. But other result types can be added in the future and we may forget to handle it
                    Logger.Warn("Unhandled login fail reason: " + result);
                    return new UserFriendlyException("登陆失败");
            }
        }

        public string CreateLocalizedMessageForFailedLoginAttempt(AbpLoginResultType result, string usernameOrEmailAddress, string tenancyName)
        {
            switch (result)
            {
                case AbpLoginResultType.Success:
                    throw new Exception("Don't call this method with a success result!");
                case AbpLoginResultType.InvalidUserNameOrEmailAddress:
                case AbpLoginResultType.InvalidPassword:
                    return L("InvalidUserNameOrPassword");

                case AbpLoginResultType.InvalidTenancyName:
                    return L("ThereIsNoTenantDefinedWithName{0}", tenancyName);

                case AbpLoginResultType.TenantIsNotActive:
                    return L("TenantIsNotActive", tenancyName);

                case AbpLoginResultType.UserIsNotActive:
                    return L("UserIsNotActiveAndCanNotLogin", usernameOrEmailAddress);

                case AbpLoginResultType.UserEmailIsNotConfirmed:
                    return L("UserEmailIsNotConfirmedAndCanNotLogin");

                default: // Can not fall to default actually. But other result types can be added in the future and we may forget to handle it
                    Logger.Warn("Unhandled login fail reason: " + result);
                    return "登陆失败";
            }
        }
    }
}
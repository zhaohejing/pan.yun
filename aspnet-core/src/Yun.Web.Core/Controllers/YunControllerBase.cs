using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Yun.Controllers
{
    public abstract class YunControllerBase: AbpController
    {
        protected YunControllerBase()
        {
            LocalizationSourceName = YunConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

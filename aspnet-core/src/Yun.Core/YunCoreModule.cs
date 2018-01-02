using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using Yun.Authorization.Roles;
using Yun.Authorization.Users;
using Yun.Configuration;
using Yun.Localization;
using Yun.MultiTenancy;
using Yun.Timing;

namespace Yun
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class YunCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // 声明角色用户和租户类型
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            YunLocalizationConfigurer.Configure(Configuration.Localization);

            // 是否启用多租户系统
            Configuration.MultiTenancy.IsEnabled = YunConsts.MultiTenancyEnabled;

            // 配置角色管理
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(YunCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}

using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Yun.Authorization;

namespace Yun
{
    [DependsOn(
        typeof(YunCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class YunApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<YunAuthorizationProvider>();
            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(YunApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}

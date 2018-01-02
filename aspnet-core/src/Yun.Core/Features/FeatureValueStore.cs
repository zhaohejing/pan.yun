using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.MultiTenancy;
using Abp.Runtime.Caching;
using Yun.Authorization.Users;
using Yun.MultiTenancy;

namespace Yun.Features
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, User>
    {
        public FeatureValueStore(
            ICacheManager cacheManager, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            IRepository<Tenant> tenantRepository, 
            IRepository<EditionFeatureSetting, long> editionFeatureRepository, 
            IFeatureManager featureManager, 
            IUnitOfWorkManager unitOfWorkManager) 
            : base(
                  cacheManager, 
                  tenantFeatureRepository, 
                  tenantRepository, 
                  editionFeatureRepository, 
                  featureManager, 
                  unitOfWorkManager)
        {
        }
    }
    /// <summary>
    /// �����ļ�������Ϣ
    /// </summary>
    public class ApplicationConfiguration
    {
        #region ���Գ�Ա
        public string ServerRootAddress { get; set; }
        public string ClientRootAddress { get; set; }
        public string CorsOrigins { get; set; }
        #endregion
    }
}

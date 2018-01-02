using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Yun.MultiTenancy.Dto;

namespace Yun.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

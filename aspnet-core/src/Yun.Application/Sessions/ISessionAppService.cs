using System.Threading.Tasks;
using Abp.Application.Services;
using Yun.Sessions.Dto;

namespace Yun.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

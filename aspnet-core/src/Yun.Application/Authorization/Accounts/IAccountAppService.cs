using System.Threading.Tasks;
using Abp.Application.Services;
using Yun.Authorization.Accounts.Dto;

namespace Yun.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);


        Task<ResetPasswordOutput> ResetPassword(ResetPasswordInput input);


        Task ActivateEmail(ActivateEmailInput input);

        Task<ImpersonateOutput> Impersonate(ImpersonateInput input);

        Task<ImpersonateOutput> BackToImpersonator();

        Task<SwitchToLinkedAccountOutput> SwitchToLinkedAccount(SwitchToLinkedAccountInput input);
    }
}

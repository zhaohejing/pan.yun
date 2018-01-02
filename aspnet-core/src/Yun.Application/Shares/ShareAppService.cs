using Abp.Authorization;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yun.Authorization;

namespace Yun.Shares
{
    /// <summary>
    /// 分享service
    /// </summary>
    [AbpAuthorize(PermissionNames.Pages_Shares)]
    public class ShareAppService : YunAppServiceBase, IShareAppService
    {
        private readonly IRepository<Share> _shareRepository;
        public ShareAppService(IRepository<Share> shareRepository)
        {
            _shareRepository = shareRepository;
        }
       
    }
}

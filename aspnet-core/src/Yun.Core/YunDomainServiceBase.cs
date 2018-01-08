using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Services;

namespace Yun
{
  
    public abstract class YunDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected YunDomainServiceBase()
        {
            LocalizationSourceName = YunConsts.LocalizationSourceName;
        }
    }
}

using Microsoft.AspNetCore.Antiforgery;
using Yun.Controllers;

namespace Yun.Web.Host.Controllers
{
    public class AntiForgeryController : YunControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}

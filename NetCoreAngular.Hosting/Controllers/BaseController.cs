using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreAngular.Hosting.Controllers
{
    [Route("api/[controller]")]
    public abstract class BaseController : Controller
    {
        CookieOptions cookieOptions;
        public BaseController()
        {

        }
        public void CookieAppend(string key, string value, DateTimeOffset? expiresDate)
        {
            cookieOptions = new CookieOptions();
            cookieOptions.Expires = expiresDate;
            Response.Cookies.Append(key, value, cookieOptions);
        }
    }
}
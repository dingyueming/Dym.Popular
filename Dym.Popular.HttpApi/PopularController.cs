using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Dym.Popular.HttpApi.Controllers
{
    /* Inherit your controllers from this class.
     */
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public abstract class PopularController : AbpController
    {
        protected PopularController()
        {
        }
    }
}
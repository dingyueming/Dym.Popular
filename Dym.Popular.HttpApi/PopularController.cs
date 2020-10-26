using Dym.Popular.Application.Contracts.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Identity;

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

        protected UserInfo LoginUser
        {
            get
            {
                var user = new UserInfo();
                user.SysteDate = DateTime.Now;
                var authResult = HttpContext.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme).Result;
                if (authResult.Succeeded)
                {
                    user.Id = int.Parse(authResult.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                    user.Name = authResult.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
                    user.Role = authResult.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
                }
                return user;
            }
        }
    }
}
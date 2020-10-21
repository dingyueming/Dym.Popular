using Dym.Popular.Application.Contracts.Interface.Authorize;
using Dym.Popular.Application.Contracts.Models;
using Dym.Popular.Domain.Shared.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Dym.Popular.Domain.Shared.Blogs.BlogDbConsts;

namespace Dym.Popular.HttpApi.Controllers.Authorize
{
    //[AllowAnonymous]
    [ApiExplorerSettings(GroupName = BlogGrouping.GroupName_Common)]
    public class UserInfoController : PopularController
    {
        private readonly IAuthorizeService _authorizeService;

        public UserInfoController(IAuthorizeService authorizeService)
        {
            _authorizeService = authorizeService;
        }

        [HttpGet]
        public async Task<PopularResult<UserInfo>> Get(string token)
        {
            return await _authorizeService.GetUserInfoAsync(token);
        }
    }
}

using Dym.Popular.Application.Contracts.Interface.Authorize;
using Dym.Popular.Domain.Shared.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using static Dym.Popular.Domain.Shared.Blogs.BlogDbConsts;

namespace Dym.Popular.HttpApi.Controllers.Authorize
{
    [AllowAnonymous]
    [ApiExplorerSettings(GroupName = BlogGrouping.GroupName_Common)]
    public class TokenController : PopularController
    {
        private readonly IAuthorizeService _authorizeService;

        public TokenController(IAuthorizeService authorizeService)
        {
            _authorizeService = authorizeService;
        }

        [HttpGet]
        public async Task<PopularResult<string>> GetAsync([Required] string username, [Required] string password)
        {
            return await _authorizeService.GenerateTokenAsync(username, password);
        }
        [HttpPost]
        public async Task<PopularResult<string>> PostAsync()
        {
            var result = new PopularResult<string>();
            result.Success();
            return await Task.FromResult(result);
        }
    }
}

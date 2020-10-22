using Dym.Popular.Application.Contracts.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dym.Popular.Domain.Shared;

namespace Dym.Popular.HttpApi.Controllers
{
    [ApiExplorerSettings(GroupName = ApiGrouping.GroupName_Common)]
    [AllowAnonymous]
    public class WelcomeController : PopularController
    {
        [HttpGet]
        public async Task<string> GetAsync()
        {
            return await Task.FromResult("Hello");
        }
    }
}

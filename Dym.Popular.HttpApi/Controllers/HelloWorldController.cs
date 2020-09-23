using Dym.Popular.Application.Contracts.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Dym.Popular.Domain.Shared.Blogs.BlogDbConsts;

namespace Dym.Popular.HttpApi.Controllers
{
    [ApiExplorerSettings(GroupName = BlogGrouping.GroupName_Other)]
    public class HelloWorldController : PopularController
    {
        private readonly IHelloWorldService _helloWorldService;

        public HelloWorldController(IHelloWorldService helloWorldService)
        {
            _helloWorldService = helloWorldService;
        }

        [HttpGet]
        public string HelloWorld()
        {
            return _helloWorldService.HelloWorld();
        }
    }
}

﻿using Dym.Popular.Application.Contracts.Interface.Authorize;
using Dym.Popular.Domain.Shared.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using static Dym.Popular.Domain.Shared.Blogs.BlogDbConsts;

namespace Dym.Popular.HttpApi.Controllers.Authorize
{

    [ApiExplorerSettings(GroupName = BlogGrouping.GroupName_Common)]
    public class TokenController : PopularController
    {
        private readonly IAuthorizeService _authorizeService;

        public TokenController(IAuthorizeService authorizeService)
        {
            _authorizeService = authorizeService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<PopularResult<string>> Get([Required] string username, [Required] string password)
        {
            return await _authorizeService.GenerateTokenAsync(username, password);
        }
    }
}

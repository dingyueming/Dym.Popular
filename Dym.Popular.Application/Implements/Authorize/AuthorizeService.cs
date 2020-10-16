using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Application.Contracts.Interface.Authorize;
using Dym.Popular.Application.Contracts.Models;
using Dym.Popular.Domain;
using Dym.Popular.Domain.Entities.PopularSys;
using Dym.Popular.Domain.Shared.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace Dym.Popular.Application.Implements.Authorize
{
    public class AuthorizeService : PopularAppService, IAuthorizeService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthorizeService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<PopularResult<string>> GenerateTokenAsync(string uid, string pwd)
        {
            var result = new PopularResult<string>();

            if (string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(pwd))
            {
                result.Failed("用户名或密码为空");
                return result;
            }

            var claims = new[] {
                    new Claim(ClaimTypes.NameIdentifier, "admin"),
                    new Claim(ClaimTypes.PrimarySid,"1"),
                    new Claim(JwtRegisteredClaimNames.Exp, $"{new DateTimeOffset(DateTime.Now.AddMinutes(AppSettings.JWT.Expires)).ToUnixTimeSeconds()}"),
                    new Claim(JwtRegisteredClaimNames.Nbf, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}")
                };

            var key = new SymmetricSecurityKey(AppSettings.JWT.SecurityKey.GetBytes());
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                issuer: AppSettings.JWT.Domain,
                audience: AppSettings.JWT.Domain,
                claims: claims,
                expires: DateTime.Now.AddMinutes(AppSettings.JWT.Expires),
                signingCredentials: creds);

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            result.Success(token);
            return await Task.FromResult(result);
        }

        public async Task<PopularResult<UserInfo>> GetUserInfoAsync(string token)
        {
            var result = new PopularResult<UserInfo>();
            //token转化
            var securityToken = new JwtSecurityTokenHandler().ReadToken(token).As<JwtSecurityToken>();
            //获取token中的用户ID
            var id = securityToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid);

            //根据name获取用户详细信息，以及权限等

            //假数据
            var userInfo = new UserInfo()
            {
                Name = "admin",
                Avatar = "https://wpimg.wallstcn.com/f778738c-e4f8-4870-b634-56703b4acafe.gif"
            };
            result.Success(userInfo);
            return await Task.FromResult(result);
        }
    }
}

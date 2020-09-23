using Dym.Popular.Application.Contracts.Interface.Authorize;
using Dym.Popular.Domain;
using Dym.Popular.Domain.Shared.Result;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dym.Popular.Application.Implements.Authorize
{
    public class AuthorizeService : IAuthorizeService
    {
        public async Task<PopularResult<string>> GenerateTokenAsync(string uid, string pwd)
        {
            var result = new PopularResult<string>();

            if (string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(pwd))
            {
                result.Failed("用户名或密码为空");
                return result;
            }

            var claims = new[] {
                    new Claim(ClaimTypes.NameIdentifier, "123"),
                    new Claim(ClaimTypes.UserData,"12345"),
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
    }
}

using Dym.Popular.Application.Contracts.Models;
using Dym.Popular.Domain.Shared.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dym.Popular.Application.Contracts.Interface.Authorize
{
    public interface IAuthorizeService
    {
        #region auth登陆，后面有时间接微信
        /// <summary>
        /// 获取登录地址(GitHub)
        /// </summary>
        /// <returns></returns>
        //Task<PopularResult<string>> GetLoginAddressAsync();

        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        //Task<PopularResult<string>> GetAccessTokenAsync(string code);

        /// <summary>
        /// 生成Token
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        //Task<PopularResult<string>> GenerateTokenAsync(string access_token);
        #endregion

        /// <summary>
        /// 生成Token
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        Task<PopularResult<string>> GenerateTokenAsync(string uid, string pwd);

        /// <summary>
        /// 获取用户详细信息
        /// </summary>
        /// <returns></returns>
        Task<PopularResult<UserInfo>> GetUserInfoAsync(string token);
    }
}

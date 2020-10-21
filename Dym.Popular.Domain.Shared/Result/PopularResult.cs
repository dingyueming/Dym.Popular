using System;
using System.Collections.Generic;
using System.Text;

namespace Dym.Popular.Domain.Shared.Result
{
    /// <summary>
    /// 服务层响应实体
    /// </summary>
    public class PopularResult
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public PopularResultCodeEnum Code { get; set; }

        /// <summary>
        /// 响应信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 时间戳(毫秒)
        /// </summary>
        public long Timestamp => DateTimeOffset.Now.ToUnixTimeMilliseconds();

        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public void Success(string message = "")
        {
            Message = message;
            Code = PopularResultCodeEnum.Succeed;
        }

        /// <summary>
        /// 响应失败
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public void Failed(string message = "")
        {
            Message = message;
            Code = PopularResultCodeEnum.Failed;
        }

        /// <summary>
        /// 响应失败
        /// </summary>
        /// <param name="exexception></param>
        public void Failed(Exception exception)
        {
            Message = exception.InnerException?.StackTrace;
            Code = PopularResultCodeEnum.Failed;
        }
    }
}

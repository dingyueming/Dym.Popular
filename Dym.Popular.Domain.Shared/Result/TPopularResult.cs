using System;
using System.Collections.Generic;
using System.Text;

namespace Dym.Popular.Domain.Shared.Result
{
    /// <summary>
    /// 服务层响应实体(泛型)
    /// </summary>
    public class PopularResult<T> : PopularResult where T : class
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        public void Success(T result = null, string message = "")
        {
            Message = message;
            Code = PopularResultCodeEnum.Succeed;
            Data = result;
        }
    }
}

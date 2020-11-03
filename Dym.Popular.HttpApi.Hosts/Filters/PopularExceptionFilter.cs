using Dym.Popular.Domain.Shared.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dym.Popular.HttpApi.Hosts.Extensions
{
    public class PopularExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public void OnException(ExceptionContext context)
        {
            // 错误日志记录
            var result = new PopularResult()
            {
                Code = PopularResultCodeEnum.Failed,
                Message = context.Exception.InnerException == null ? context.Exception.Message : context.Exception.InnerException.Message
            };
            context.Result = new JsonResult(result);
        }
    }
}

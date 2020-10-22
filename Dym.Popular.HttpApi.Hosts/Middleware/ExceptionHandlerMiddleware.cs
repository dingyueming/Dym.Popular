using Dym.Popular.Domain.Shared.Result;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Dym.Popular.HttpApi.Hosts.Middleware
{
    /// <summary>
    /// 异常处理中间件
    /// </summary>
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await ExceptionHandlerAsync(context, ex.Message);
            }
            finally
            {
                var statusCode = context.Response.StatusCode;
                if (statusCode == StatusCodes.Status401Unauthorized)
                {
                    context.Response.StatusCode = StatusCodes.Status200OK;
                    Enum.TryParse(typeof(HttpStatusCode), statusCode.ToString(), out object message);
                    await ExceptionHandlerAsync(context, message.ToString());
                }
            }
        }

        /// <summary>
        /// 异常处理，返回JSON
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private async Task ExceptionHandlerAsync(HttpContext context, string message)
        {
            context.Response.ContentType = "application/json;charset=utf-8";

            var result = new PopularResult();
            result.Failed(message);

            var setting = new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };
            var json = JsonConvert.SerializeObject(result, Formatting.None, setting);

            await context.Response.WriteAsync(json);
        }
    }
}

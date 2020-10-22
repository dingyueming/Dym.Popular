using Dym.Popular.Domain.Entities.Blogs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Collections.Generic;
using System.Linq;
using Dym.Popular.Domain.Shared;

namespace Dym.Popular.Swagger
{
    public static class PopularSwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                ApiInfos.ForEach(x =>
                {
                    options.SwaggerDoc(x.UrlPrefix, x.OpenApiInfo);
                });
                var security = new OpenApiSecurityScheme
                {
                    Description = "JWT模式授权，请输入 Bearer {Token} 进行身份验证",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                };
                options.AddSecurityDefinition("oauth2", security);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement { { security, new List<string>() } });
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                options.OperationFilter<SecurityRequirementsOperationFilter>();
                options.ResolveConflictingActions(x => x.First());
            });
        }

        public static void UseSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(options =>
            {
                ApiInfos.ForEach(x =>
                {
                    options.SwaggerEndpoint($"/swagger/{x.UrlPrefix}/swagger.json", x.Name);
                });
                // 模型的默认扩展深度，设置为 -1 完全隐藏模型
                options.DefaultModelsExpandDepth(-1);
                // API文档仅展开标记
                options.DocExpansion(DocExpansion.List);
                // API前缀设置为空
                options.RoutePrefix = string.Empty;
                // API页面Title
                options.DocumentTitle = "接口文档";
            });

        }

        /// <summary>
        /// Swagger分组信息，将进行遍历使用
        /// </summary>
        private static List<SwaggerApiInfo> ApiInfos
        {
            get
            {
                var version = "1.0.0";
                var description = "";
                var listApiInfo = new List<SwaggerApiInfo>()
                {
                    new SwaggerApiInfo
                    {
                        UrlPrefix = ApiGrouping.GroupName_Common,
                        Name = "通用公共接口",
                        OpenApiInfo = new OpenApiInfo
                        {
                            Version = version,
                            Title = "通用公共接口",
                            Description = description
                        }
                    },
                    new SwaggerApiInfo
                    {
                        UrlPrefix = ApiGrouping.GroupName_Mis,
                        Name = "押运车辆车务综合信息管理系统接口",
                        OpenApiInfo = new OpenApiInfo
                        {
                            Version = version,
                            Title = "押运车辆车务综合信息管理系统接口",
                            Description = description
                        }
                    }
                };
                return listApiInfo;
            }
        }
    }
    internal class SwaggerApiInfo
    {
        /// <summary>
        /// URL前缀
        /// </summary>
        public string UrlPrefix { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// <see cref="Microsoft.OpenApi.Models.OpenApiInfo"/>
        /// </summary>
        public OpenApiInfo OpenApiInfo { get; set; }
    }
}

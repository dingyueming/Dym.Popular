using Dym.Popular.Application;
using Dym.Popular.Domain;
using Dym.Popular.EntityFrameworkCore.DbMigrations;
using Dym.Popular.HttpApi.Hosts.Extensions;
using Dym.Popular.Job;
using Dym.Popular.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Dym.Popular.HttpApi.Hosts
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        typeof(PopularApplicationModule),
        typeof(PopularHttpApiModule),
        typeof(PopularSwaggerModule),
        typeof(PopularEntityFrameworkCoreDbMigrationsModule),
        typeof(PopularJobModule)
        )]
    public class PopularHttpApiHostsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<MvcOptions>(options =>
            {
                var filterMetadata = options.Filters.FirstOrDefault(x => x is ServiceFilterAttribute attribute && attribute.ServiceType.Equals(typeof(AbpExceptionFilter)));

                // 移除 AbpExceptionFilter
                options.Filters.Remove(filterMetadata);

                // 添加自己实现的ExceptionFilter
                options.Filters.Add(typeof(PopularExceptionFilter));
            });

            // 跨域配置
            context.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            // 身份验证
            context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = true,//是否验证Issuer
                           ValidateAudience = true,//是否验证Audience
                           ValidateLifetime = true,//是否验证失效时间
                           ValidateIssuerSigningKey = true,//是否验证SecurityKey
                           ValidAudience = AppSettings.JWT.Domain,//Audience
                           ValidIssuer = AppSettings.JWT.Domain,//Issuer
                           ClockSkew = TimeSpan.Zero,//校验时间是否过期时，设置的时钟偏移量
                           IssuerSigningKey = new SymmetricSecurityKey(AppSettings.JWT.SecurityKey.GetBytes()),//拿到SecurityKey
                       };
                   });

            // 认证授权
            context.Services.AddAuthorization();

            // Http请求
            context.Services.AddHttpClient();

            base.ConfigureServices(context);
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            // 环境变量，开发环境
            if (env.IsDevelopment())
            {
                // 生成异常页面
                app.UseDeveloperExceptionPage();
            }

            // 路由
            app.UseRouting();

            // 身份验证
            app.UseAuthentication();

            // 认证授权
            app.UseAuthorization();

            // 跨域
            app.UseCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            // 路由映射
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}


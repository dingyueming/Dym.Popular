using Dym.Popular.Application.Contracts;
using Dym.Popular.Application.Contracts.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Dym.Popular.Application
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(AbpIdentityApplicationModule),
        typeof(PopularApplicationContractsModule)
    )]
    public class PopularApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<PopularApplicationModule>(validate: true);
                options.AddProfile<PopularAutoMapperProfile>(validate: true);
            });
        }
    }
}

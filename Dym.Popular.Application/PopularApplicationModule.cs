using Dym.Popular.Application.Contracts;
using Dym.Popular.Application.Contracts.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Dym.Popular.Application
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule),
        typeof(PopularApplicationContractsModule)
    )]
    public class PopularApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}

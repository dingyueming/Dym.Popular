using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Dym.Popular.Application.Contracts
{
    [DependsOn(
        typeof(AbpIdentityApplicationContractsModule)
    )]
    public class PopularApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);
        }
    }
}

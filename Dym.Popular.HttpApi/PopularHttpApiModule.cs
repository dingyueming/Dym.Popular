using Dym.Popular.Application.Contracts;
using System;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Dym.Popular.HttpApi
{
    [DependsOn(
        typeof(AbpIdentityHttpApiModule),
        typeof(PopularApplicationContractsModule)
    )]
    public class PopularHttpApiModule : AbpModule
    {

    }
}

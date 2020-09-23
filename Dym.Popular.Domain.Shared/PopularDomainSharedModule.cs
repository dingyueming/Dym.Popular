using System;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Dym.Popular.Domain.Shared
{
    [DependsOn(typeof(AbpIdentityDomainSharedModule))]
    public class PopularDomainSharedModule : AbpModule
    {
    }
}

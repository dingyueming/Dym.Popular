using System;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Dym.Popular.Domain
{
    [DependsOn(typeof(AbpIdentityDomainModule))]
    public class PopularDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);
        }
    }
}

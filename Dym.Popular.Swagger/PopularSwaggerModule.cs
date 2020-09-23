using Dym.Popular.Domain;
using Microsoft.AspNetCore.Builder;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Dym.Popular.Swagger
{
    [DependsOn(typeof(PopularDomainModule))]
    public class PopularSwaggerModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSwagger();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            context.GetApplicationBuilder().UseSwagger().UseSwaggerUI();
        }
    }
}

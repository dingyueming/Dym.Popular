using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Dym.Popular.EntityFrameworkCore.DbMigrations
{
    [DependsOn(
        typeof(PopularEntityFrameworkCoreModule)
    )]
    public class PopularEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<PopularMigrationsDbContext>();
        }
    }
}

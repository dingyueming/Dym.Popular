using Dym.Popular.Domain.Shared;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.EntityFrameworkCore.Oracle;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Dym.Popular.EntityFrameworkCore
{
    [DependsOn(
        typeof(PopularDomainSharedModule),
        typeof(AbpEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreMySQLModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(AbpEntityFrameworkCorePostgreSqlModule),
        typeof(AbpEntityFrameworkCoreSqliteModule),
        typeof(AbpEntityFrameworkCoreOracleModule)
    )]
    public class PopularEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<PopularDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                /* The main point to change your DBMS.
                 * See also PopularMigrationsDbContextFactory for EF Core tooling. */
                options.UseMySQL();
            });
        }
    }
}

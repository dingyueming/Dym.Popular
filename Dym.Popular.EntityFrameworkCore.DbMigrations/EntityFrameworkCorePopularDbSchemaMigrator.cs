using System;
using System.Threading.Tasks;
using Dym.Popular.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace Dym.Popular.EntityFrameworkCore.DbMigrations
{
    public class EntityFrameworkCorePopularDbSchemaMigrator
        : IPopularDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCorePopularDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the PopularMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<PopularMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Dym.Popular.Domain.Data
{
    /* This is used if database provider does't define
     * IPopularDbSchemaMigrator implementation.
     */
    public class NullPopularDbSchemaMigrator : IPopularDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}
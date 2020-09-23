using System.Threading.Tasks;

namespace Dym.Popular.Domain.Data
{
    public interface IPopularDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}

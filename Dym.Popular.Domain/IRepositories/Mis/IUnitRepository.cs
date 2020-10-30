using Dym.Popular.Domain.Entities.Mis;
using Volo.Abp.Domain.Repositories;

namespace Dym.Popular.Domain.IRepositories.Mis
{
    /// <summary>
    /// IRepository
    /// </summary>
    public interface IUnitRepository : IRepository<UnitEntity, int>
    {
    }
}

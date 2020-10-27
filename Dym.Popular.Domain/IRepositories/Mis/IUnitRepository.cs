using Dym.Popular.Domain.Entities.Mis;
using Volo.Abp.Domain.Repositories;

namespace Dym.Popular.Domain.IRepositories.Mis
{
    /// <summary>
    /// IPostRepository
    /// </summary>
    public interface IUnitRepository : IRepository<UnitEntity, int>
    {
    }
}

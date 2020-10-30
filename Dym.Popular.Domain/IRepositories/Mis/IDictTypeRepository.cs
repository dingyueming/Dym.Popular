using Dym.Popular.Domain.Entities.Mis;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dym.Popular.Domain.IRepositories.Mis
{
    /// <summary>
    /// IRepository
    /// </summary>
    public interface IDictTypeRepository : IRepository<DictTypeEntity, int>
    {
        Task<List<DictTypeEntity>> GetPagedAsync(string name, int skipCount, int maxResultCount);
    }
}

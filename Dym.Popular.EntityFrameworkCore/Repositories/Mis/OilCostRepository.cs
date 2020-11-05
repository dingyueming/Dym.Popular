using Dym.Popular.Domain.Entities.Mis;
using Dym.Popular.Domain.IRepositories.Mis;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dym.Popular.EntityFrameworkCore.Repositories.Mis
{
    /// <summary>
    /// Repository
    /// </summary>
    public class OilCostRepository : EfCoreRepository<PopularDbContext, OilCostEntity, int>, IOilCostRepository
    {
        public OilCostRepository(IDbContextProvider<PopularDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}

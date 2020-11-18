using Dym.Popular.Domain.Entities.Mis;
using Dym.Popular.Domain.IRepositories.Mis;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dym.Popular.EntityFrameworkCore.Repositories.Mis
{
    /// <summary>
    /// Repository
    /// </summary>
    public class ViolationRepository : EfCoreRepository<PopularDbContext, ViolationEntity, int>, IViolationRepository
    {
        public ViolationRepository(IDbContextProvider<PopularDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}

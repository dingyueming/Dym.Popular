using Dym.Popular.Domain.Entities.Mis;
using Dym.Popular.Domain.IRepositories.Mis;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dym.Popular.EntityFrameworkCore.Repositories.Mis
{
    /// <summary>
    /// Repository
    /// </summary>
    public class VehicleRepository : EfCoreRepository<PopularDbContext, VehicleEntity, int>, IVehicleRepository
    {
        public VehicleRepository(IDbContextProvider<PopularDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="vehicleEntities"></param>
        /// <returns></returns>
        public async Task BulkInsertAsync(IEnumerable<VehicleEntity> vehicleEntities)
        {
            await DbContext.Set<VehicleEntity>().AddRangeAsync(vehicleEntities);
            await DbContext.SaveChangesAsync();
        }
    }
}

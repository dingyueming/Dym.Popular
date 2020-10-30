using Dym.Popular.Domain.Entities.Mis;
using Dym.Popular.Domain.IRepositories.Mis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq;

namespace Dym.Popular.EntityFrameworkCore.Repositories.Mis
{
    /// <summary>
    /// Repository
    /// </summary>
    public class DictTypeRepository : EfCoreRepository<PopularDbContext, DictTypeEntity, int>, IDictTypeRepository
    {
        public DictTypeRepository(IDbContextProvider<PopularDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<DictTypeEntity>> GetPagedAsync(string name, int skipCount, int maxResultCount)
        {
            var query = DbContext.Set<DictTypeEntity>().Include(x => x.Dicts)
                .WhereIf(!name.IsNullOrWhiteSpace(), dictType => dictType.Name.Contains(name)).PageBy(skipCount, maxResultCount);

            return await query.ToListAsync();
        }
    }
}

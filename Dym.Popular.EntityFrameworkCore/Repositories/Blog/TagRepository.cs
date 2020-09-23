using Dym.Popular.Domain.Entities.Blogs;
using Dym.Popular.Domain.IRepositories.Blog;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dym.Popular.EntityFrameworkCore.Repositories.Blog
{
    /// <summary>
    /// TagRepository
    /// </summary>
    public class TagRepository : EfCoreRepository<PopularDbContext, Tag, int>, ITagRepository
    {
        public TagRepository(IDbContextProvider<PopularDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public async Task BulkInsertAsync(IEnumerable<Tag> tags)
        {
            await DbContext.Set<Tag>().AddRangeAsync(tags);
            await DbContext.SaveChangesAsync();
        }
    }
}

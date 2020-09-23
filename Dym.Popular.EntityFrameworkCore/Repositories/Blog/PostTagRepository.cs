using Dym.Popular.Domain.Entities.Blogs;
using Dym.Popular.Domain.IRepositories.Blog;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dym.Popular.EntityFrameworkCore.Repositories.Blog
{
    /// <summary>
    /// PostTagRepository
    /// </summary>
    public class PostTagRepository : EfCoreRepository<PopularDbContext, PostTag, int>, IPostTagRepository
    {
        public PostTagRepository(IDbContextProvider<PopularDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="postTags"></param>
        /// <returns></returns>
        public async Task BulkInsertAsync(IEnumerable<PostTag> postTags)
        {
            await DbContext.Set<PostTag>().AddRangeAsync(postTags);
            await DbContext.SaveChangesAsync();
        }
    }
}

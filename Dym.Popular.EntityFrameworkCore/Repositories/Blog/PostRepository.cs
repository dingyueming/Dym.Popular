using Dym.Popular.Domain.Entities.Blogs;
using Dym.Popular.Domain.IRepositories.Blog;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dym.Popular.EntityFrameworkCore.Repositories.Blog
{
    /// <summary>
    /// PostRepository
    /// </summary>
    public class PostRepository : EfCoreRepository<PopularDbContext, Post, int>, IPostRepository
    {
        public PostRepository(IDbContextProvider<PopularDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}

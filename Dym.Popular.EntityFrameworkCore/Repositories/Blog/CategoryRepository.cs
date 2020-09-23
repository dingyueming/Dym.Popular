using Dym.Popular.Domain.Entities.Blogs;
using Dym.Popular.Domain.IRepositories.Blog;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dym.Popular.EntityFrameworkCore.Repositories.Blog
{
    /// <summary>
    /// CategoryRepository
    /// </summary>
    public class CategoryRepository : EfCoreRepository<PopularDbContext, Category, int>, ICategoryRepository
    {
        public CategoryRepository(IDbContextProvider<PopularDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}

using Dym.Popular.Domain.Entities.Blogs;
using Dym.Popular.Domain.IRepositories.Blog;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dym.Popular.EntityFrameworkCore.Repositories.Blog
{
    /// <summary>
    /// PostTagRepository
    /// </summary>
    public class FriendLinkRepository : EfCoreRepository<PopularDbContext, FriendLink, int>, IFriendLinkRepository
    {
        public FriendLinkRepository(IDbContextProvider<PopularDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }

}

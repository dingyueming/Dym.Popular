using Dym.Popular.Domain.Entities.Blogs;
using Volo.Abp.Domain.Repositories;

namespace Dym.Popular.Domain.IRepositories.Blog
{
    /// <summary>
    /// IFriendLinkRepository
    /// </summary>
    public interface IFriendLinkRepository : IRepository<FriendLink, int>
    {
    }
}

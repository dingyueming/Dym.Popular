using Dym.Popular.Domain.Entities.Blogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Dym.Popular.Domain.IRepositories.Blog
{
    /// <summary>
    /// IPostTagRepository
    /// </summary>
    public interface IPostTagRepository : IRepository<PostTag, int>
    {
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="postTags"></param>
        /// <returns></returns>
        Task BulkInsertAsync(IEnumerable<PostTag> postTags);
    }
}

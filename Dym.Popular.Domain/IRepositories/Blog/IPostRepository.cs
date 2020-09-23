using Dym.Popular.Domain.Entities.Blogs;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace Dym.Popular.Domain.IRepositories.Blog
{
    /// <summary>
    /// IPostRepository
    /// </summary>
    public interface IPostRepository : IRepository<Post, int>
    {
    }
}

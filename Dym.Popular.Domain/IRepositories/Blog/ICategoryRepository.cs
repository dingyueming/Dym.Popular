using Dym.Popular.Domain.Entities.Blogs;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace Dym.Popular.Domain.IRepositories.Blog
{
    /// <summary>
    /// ICategoryRepository
    /// </summary>
    public interface ICategoryRepository : IRepository<Category, int>
    {
    }
}

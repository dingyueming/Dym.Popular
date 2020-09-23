using Dym.Popular.Application.Contracts.Dto.Blog;
using Dym.Popular.Application.Contracts.Interface.Blog;
using Dym.Popular.Domain.Shared.Result;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using static Dym.Popular.Domain.Shared.Blogs.BlogDbConsts;

namespace Dym.Popular.HttpApi.Controllers.Blog
{
    [ApiExplorerSettings(GroupName = BlogGrouping.GroupName_UI)]
    public class BlogController : PopularController
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        /// <summary>
        /// 添加博客
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<PopularResult<string>> InsertPostAsync([FromBody] PostDto dto)
        {
            return await _blogService.InsertPostAsync(dto);
        }
        /// <summary>
        /// 删除博客
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<PopularResult> DeletePostAsync([Required] int id)
        {
            return await _blogService.DeletePostAsync(id);
        }

        /// <summary>
        /// 更新博客
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<PopularResult<string>> UpdatePostAsync([Required] int id, [FromBody] PostDto dto)
        {
            return await _blogService.UpdatePostAsync(id, dto);
        }

        /// <summary>
        /// 查询博客
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PopularResult<PostDto>> GetPostAsync([Required] int id)
        {
            return await _blogService.GetPostAsync(id);
        }
    }
}

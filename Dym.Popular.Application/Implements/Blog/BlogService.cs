using Dym.Popular.Application.Contracts.Dto.Blog;
using Dym.Popular.Application.Contracts.Interface.Blog;
using Dym.Popular.Domain.Entities.Blogs;
using Dym.Popular.Domain.IRepositories.Blog;
using Dym.Popular.Domain.Shared.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dym.Popular.Application.Implements.Blog
{
    public class BlogService : PopularAppService, IBlogService
    {
        private readonly IPostRepository _postRepository;

        public BlogService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<PopularResult<string>> InsertPostAsync(PostDto dto)
        {
            var result = new PopularResult<string>();

            var entity = new Post
            {
                Title = dto.Title,
                Author = dto.Author,
                Url = dto.Url,
                Html = dto.Html,
                Markdown = dto.Markdown,
                CategoryId = dto.CategoryId,
                CreationTime = dto.CreationTime
            };

            var post = await _postRepository.InsertAsync(entity);
            if (post == null)
            {
                result.Failed("添加失败");
                return result;
            }

            result.Success("添加成功");
            return result;
        }

        public async Task<PopularResult> DeletePostAsync(int id)
        {
            var result = new PopularResult();

            await _postRepository.DeleteAsync(id);

            return result;
        }

        public async Task<PopularResult<string>> UpdatePostAsync(int id, PostDto dto)
        {
            var result = new PopularResult<string>();

            var post = await _postRepository.GetAsync(id);
            if (post == null)
            {
                result.Failed("文章不存在");
                return result;
            }

            post.Title = dto.Title;
            post.Author = dto.Author;
            post.Url = dto.Url;
            post.Html = dto.Html;
            post.Markdown = dto.Markdown;
            post.CategoryId = dto.CategoryId;
            post.CreationTime = dto.CreationTime;

            await _postRepository.UpdateAsync(post);


            result.Success("更新成功");
            return result;
        }

        public async Task<PopularResult<PostDto>> GetPostAsync(int id)
        {
            var result = new PopularResult<PostDto>();

            var post = await _postRepository.GetAsync(id);
            if (post == null)
            {
                result.Failed("文章不存在");
                return result;
            }

            var dto = new PostDto
            {
                Title = post.Title,
                Author = post.Author,
                Url = post.Url,
                Html = post.Html,
                Markdown = post.Markdown,
                CategoryId = post.CategoryId,
                CreationTime = post.CreationTime
            };

            result.Success(dto);
            return result;
        }
    }
}

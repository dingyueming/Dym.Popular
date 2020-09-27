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
            var entity = ObjectMapper.Map<PostDto, Post>(dto);
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

            post = ObjectMapper.Map<PostDto, Post>(dto);

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
            var dto = ObjectMapper.Map<Post, PostDto>(post);
            result.Success(dto);
            return result;
        }
    }
}

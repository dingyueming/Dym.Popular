using Dym.Popular.Application.Contracts.Dto.Blog;
using Dym.Popular.Domain.Shared.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dym.Popular.Application.Contracts.Interface.Blog
{
    public interface IBlogService : IApplicationService
    {
        //Task<bool> InsertPostAsync(PostDto dto);
        Task<PopularResult<string>> InsertPostAsync(PostDto dto);

        //Task<bool> DeletePostAsync(int id);
        Task<PopularResult> DeletePostAsync(int id);

        //Task<bool> UpdatePostAsync(int id, PostDto dto);
        Task<PopularResult<string>> UpdatePostAsync(int id, PostDto dto);

        //Task<PostDto> GetPostAsync(int id);
        Task<PopularResult<PostDto>> GetPostAsync(int id);
    }
}

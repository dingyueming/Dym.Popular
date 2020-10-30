using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Domain.Shared.Result;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dym.Popular.Application.Contracts.Interface.Mis
{
    public interface IDictService : IApplicationService
    {
        Task<PopularResult<string>> InsertAsync(DictDto dto);

        Task<PopularResult> DeleteAsync(int id);

        Task<PopularResult<string>> UpdateAsync(DictDto dto);

        Task<PopularResult<DictDto>> GetAsync(int id);

        Task<PopularResult<List<DictDto>>> GetAllAsync();

        Task<PopularResult<List<DictDto>>> GetAllAsync(int id);
    }
}

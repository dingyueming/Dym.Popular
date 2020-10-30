using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Domain.Shared.Result;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dym.Popular.Application.Contracts.Interface.Mis
{
    public interface IDictTypeService : IApplicationService
    {
        Task<PopularResult<string>> InsertAsync(DictTypeDto dto);

        Task<PopularResult> DeleteAsync(int id);

        Task<PopularResult<string>> UpdateAsync(DictTypeDto dto);

        Task<PopularResult<DictTypeDto>> GetAsync(int id);

        Task<PopularResult<List<DictTypeDto>>> GetAllAsync();

        Task<PopularResult<PagedResultDto<DictTypeDto>>> GetListAsync(DictTypeQueryDto dto);

    }
}

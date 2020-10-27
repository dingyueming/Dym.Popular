using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Domain.Shared.Result;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dym.Popular.Application.Contracts.Interface.Mis
{
    public interface IUnitService : IApplicationService
    {
        Task<PopularResult<string>> InsertAsync(UnitDto dto);

        Task<PopularResult> DeleteAsync(int id);

        Task<PopularResult<string>> UpdateAsync(UnitDto dto);

        Task<PopularResult<UnitDto>> GetAsync(int id);

        Task<PopularResult<List<UnitDto>>> GetAllAsync();

        Task<PopularResult<PagedResultDto<UnitDto>>> GetListAsync(UnitGetListDto dto);

        Task<PopularResult<byte[]>> GetBytesAsync(UnitGetListDto dto);
    }
}

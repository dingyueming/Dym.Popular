using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Domain.Shared.Result;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dym.Popular.Application.Contracts.Interface.Mis
{
    public interface IOilCostService : IApplicationService
    {
        Task<PopularResult<string>> InsertAsync(OilCostDto dto);

        Task<PopularResult> DeleteAsync(int id);

        Task<PopularResult<string>> UpdateAsync(OilCostDto dto);

        Task<PopularResult<OilCostDto>> GetAsync(int id);

        Task<PopularResult<PagedResultDto<OilCostDto>>> GetListAsync(OilCostQueryDto dto);

        Task<PopularResult<byte[]>> GetBytesAsync(OilCostQueryDto dto);
    }
}

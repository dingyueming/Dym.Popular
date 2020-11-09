using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Domain.Shared.Result;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dym.Popular.Application.Contracts.Interface.Mis
{
    public interface IMaintenanceService : IApplicationService
    {
        Task<PopularResult<string>> InsertAsync(MaintenanceDto dto);

        Task<PopularResult> DeleteAsync(int id);

        Task<PopularResult<string>> UpdateAsync(MaintenanceDto dto);

        Task<PopularResult<MaintenanceDto>> GetAsync(int id);

        Task<PopularResult<PagedResultDto<MaintenanceDto>>> GetListAsync(MaintenanceQueryDto dto);

        Task<PopularResult<byte[]>> GetBytesAsync(MaintenanceQueryDto dto);
    }
}

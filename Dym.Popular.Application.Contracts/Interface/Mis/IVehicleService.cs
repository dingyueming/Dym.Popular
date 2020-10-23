using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Application.Contracts.Models;
using Dym.Popular.Domain.Shared.Result;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dym.Popular.Application.Contracts.Interface.Mis
{
    public interface IVehicleService : IApplicationService
    {
        Task<PopularResult<string>> InsertAsync(VehicleDto dto);

        Task<PopularResult> DeleteAsync(int id);

        Task<PopularResult<string>> UpdateAsync(VehicleDto dto);

        Task<PopularResult<VehicleDto>> GetAsync(int id);

        Task<PopularResult<PagedResultDto<VehicleDto>>> GetListAsync(VehicleGetListDto dto);

        Task<PopularResult<byte[]>> GetBytesAsync(VehicleGetListDto dto);

        Task<PopularResult> BatchInsertAsync(List<VehicleDto> dto);
    }
}

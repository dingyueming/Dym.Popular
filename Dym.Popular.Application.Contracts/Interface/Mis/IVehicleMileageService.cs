using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Domain.Shared.Result;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dym.Popular.Application.Contracts.Interface.Mis
{
    public interface IVehicleMileageService : IApplicationService
    {
        Task<PopularResult<string>> InsertAsync(VehicleMileageDto dto);

        Task<PopularResult> DeleteAsync(int id);

        Task<PopularResult<string>> UpdateAsync(VehicleMileageDto dto);

        Task<PopularResult<VehicleMileageDto>> GetAsync(int id);

        Task<PopularResult<PagedResultDto<VehicleMileageDto>>> GetListAsync(VehicleMileageQueryDto dto);

        Task<PopularResult<byte[]>> GetBytesAsync(VehicleMileageQueryDto dto);
    }
}

using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Domain.Shared.Result;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dym.Popular.Application.Contracts.Interface.Mis
{
    public interface IVehicleService : IApplicationService
    {
        Task<PopularResult<string>> InsertAsync(VehicleDto dto);

        Task<PopularResult> DeleteAsync(int id);

        Task<PopularResult<string>> UpdateAsync(int id, VehicleDto dto);

        Task<PopularResult<VehicleDto>> GetAsync(int id);
    }
}

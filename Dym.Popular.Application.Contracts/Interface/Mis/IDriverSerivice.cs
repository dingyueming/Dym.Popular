using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Domain.Shared.Result;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Dym.Popular.Application.Contracts.Interface.Mis
{
    public interface IDriverSerivice : IApplicationService
    {
        Task<PopularResult<string>> InsertAsync(DriverDto dto);

        Task<PopularResult> DeleteAsync(int id);

        Task<PopularResult<string>> UpdateAsync(int id, DriverDto dto);

        Task<PopularResult<DriverDto>> GetAsync(int id);
    }
}

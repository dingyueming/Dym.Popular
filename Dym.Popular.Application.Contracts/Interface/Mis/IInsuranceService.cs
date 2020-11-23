using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Domain.Shared.Result;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dym.Popular.Application.Contracts.Interface.Mis
{
    public interface IInsuranceService : IApplicationService
    {
        Task<PopularResult<string>> InsertAsync(InsuranceDto dto);

        Task<PopularResult> DeleteAsync(int id);

        Task<PopularResult<string>> UpdateAsync(InsuranceDto dto);

        Task<PopularResult<InsuranceDto>> GetAsync(int id);

        Task<PopularResult<List<InsuranceDto>>> GetAllAsync();

        Task<PopularResult<PagedResultDto<InsuranceDto>>> GetListAsync(InsuranceQueryDto dto);

        Task<PopularResult<byte[]>> GetBytesAsync(InsuranceQueryDto dto);
    }
}

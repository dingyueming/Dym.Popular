using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Domain.Shared.Result;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dym.Popular.Application.Contracts.Interface.Mis
{
    public interface IViolationService : IApplicationService
    {
        Task<PopularResult<string>> InsertAsync(ViolationDto dto);

        Task<PopularResult> DeleteAsync(int id);

        Task<PopularResult<string>> UpdateAsync(ViolationDto dto);

        Task<PopularResult<ViolationDto>> GetAsync(int id);


        Task<PopularResult<PagedResultDto<ViolationDto>>> GetListAsync(ViolationQueryDto dto);

        Task<PopularResult<byte[]>> GetBytesAsync(ViolationQueryDto dto);
    }
}

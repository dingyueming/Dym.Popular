using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Application.Contracts.Interface.Mis;
using Dym.Popular.Domain.Shared.Result;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Dym.Popular.Domain.Shared;
using Volo.Abp.Application.Dtos;

namespace Dym.Popular.HttpApi.Controllers.Mis
{
    [ApiExplorerSettings(GroupName = ApiGrouping.GroupName_Mis)]
    public class ViolationController : PopularController
    {
        private readonly IViolationService _violationService;

        public ViolationController(IViolationService violationService)
        {
            _violationService = violationService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<PopularResult<string>> InsertAsync([FromBody] ViolationDto dto)
        {
            dto.Creator = LoginUser.Id;
            dto.CreateTime = LoginUser.SysteDate;
            return await _violationService.InsertAsync(dto);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<PopularResult> DeleteAsync([Required] int id)
        {
            return await _violationService.DeleteAsync(id);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<PopularResult<string>> UpdateAsync([FromBody] ViolationDto dto)
        {
            return await _violationService.UpdateAsync(dto);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PopularResult<ViolationDto>> GetAsync([Required] int id)
        {
            return await _violationService.GetAsync(id);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="license"></param>
        /// <param name="vin"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Page")]
        public async Task<PopularResult<PagedResultDto<ViolationDto>>> GetPageAsync([FromQuery]ViolationQueryDto dto)
        {
            return await _violationService.GetListAsync(dto);
        }

        /// <summary>
        /// 导出查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="license"></param>
        /// <param name="vin"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Export")]
        public async Task<PopularResult<byte[]>> GetExportAsync(ViolationQueryDto dto)
        {
            return await _violationService.GetBytesAsync(dto);
        }
    }
}

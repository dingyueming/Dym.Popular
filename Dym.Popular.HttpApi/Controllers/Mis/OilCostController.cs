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
    public class OilCostController : PopularController
    {
        private readonly IOilCostService _oilCostService;

        public OilCostController(IOilCostService oilCostService)
        {
            _oilCostService = oilCostService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<PopularResult<string>> InsertAsync([FromBody] OilCostDto dto)
        {
            dto.Creator = LoginUser.Id;
            dto.CreateTime = LoginUser.SysteDate;
            return await _oilCostService.InsertAsync(dto);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<PopularResult> DeleteAsync([Required] int id)
        {
            return await _oilCostService.DeleteAsync(id);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<PopularResult<string>> UpdateAsync([FromBody] OilCostDto dto)
        {
            return await _oilCostService.UpdateAsync(dto);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PopularResult<OilCostDto>> GetAsync([Required] int id)
        {
            return await _oilCostService.GetAsync(id);
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
        public async Task<PopularResult<PagedResultDto<OilCostDto>>> GetPageAsync(int page, int limit, int isDelete, string name, int? unitId)
        {
            return await _oilCostService.GetListAsync(new OilCostQueryDto()
            {
                SkipCount = (page - 1) * limit,
                MaxResultCount = limit,
                IsDelete = isDelete,
                CardNo = name,
                VehicleId = unitId
            });
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
        public async Task<PopularResult<byte[]>> GetExportAsync(int page, int limit, string name, int unitId)
        {
            return await _oilCostService.GetBytesAsync(new OilCostQueryDto()
            {
                SkipCount = (page - 1) * limit,
                MaxResultCount = limit,
                CardNo = name,
                VehicleId = unitId
            });
        }
    }
}

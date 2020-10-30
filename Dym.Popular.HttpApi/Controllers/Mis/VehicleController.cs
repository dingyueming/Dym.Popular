using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Application.Contracts.Interface.Mis;
using Dym.Popular.Domain.Shared.Result;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Dym.Popular.Domain.Shared;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Dym.Popular.HttpApi.Controllers.Mis
{
    [ApiExplorerSettings(GroupName = ApiGrouping.GroupName_Mis)]
    public class VehicleController : PopularController
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<PopularResult<string>> InsertAsync([FromBody] VehicleDto dto)
        {
            dto.Creator = LoginUser.Id;
            dto.CreateTime = LoginUser.SysteDate;
            return await _vehicleService.InsertAsync(dto);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<PopularResult> DeleteAsync([Required] int id)
        {
            return await _vehicleService.DeleteAsync(id);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<PopularResult<string>> UpdateAsync([FromBody] VehicleDto dto)
        {
            return await _vehicleService.UpdateAsync(dto);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PopularResult<VehicleDto>> GetAsync([Required] int id)
        {
            return await _vehicleService.GetAsync(id);
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
        public async Task<PopularResult<PagedResultDto<VehicleDto>>> GetPageAsync(int page, int limit, string license, string vin, int? unitId, int isDelete)
        {
            return await _vehicleService.GetListAsync(new VehicleQueryDto()
            {
                SkipCount = (page - 1) * limit,
                MaxResultCount = limit,
                License = license,
                Vin = vin,
                UnitId = unitId,
                IsDelete = isDelete
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
        public async Task<PopularResult<byte[]>> GetExportAsync(int page, int limit, string license, string vin, int? unitId, int isDelete)
        {
            return await _vehicleService.GetBytesAsync(new VehicleQueryDto()
            {
                SkipCount = (page - 1) * limit,
                MaxResultCount = limit,
                License = license,
                Vin = vin,
                UnitId = unitId,
                IsDelete = isDelete
            });
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="license"></param>
        /// <param name="vin"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Import")]
        public async Task<PopularResult> PostAsync([FromBody] List<VehicleDto> dto)
        {
            return await _vehicleService.BatchInsertAsync(dto);
        }
    }
}

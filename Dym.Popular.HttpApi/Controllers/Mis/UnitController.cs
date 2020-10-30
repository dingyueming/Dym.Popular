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
    public class UnitController : PopularController
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<PopularResult<string>> InsertAsync([FromBody] UnitDto dto)
        {
            dto.Creator = LoginUser.Id;
            dto.CreateTime = LoginUser.SysteDate;
            return await _unitService.InsertAsync(dto);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<PopularResult> DeleteAsync([Required] int id)
        {
            return await _unitService.DeleteAsync(id);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<PopularResult<string>> UpdateAsync([FromBody] UnitDto dto)
        {
            return await _unitService.UpdateAsync(dto);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PopularResult<UnitDto>> GetAsync([Required] int id)
        {
            return await _unitService.GetAsync(id);
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("All")]
        public async Task<PopularResult<List<UnitDto>>> GetAllAsync()
        {
            return await _unitService.GetAllAsync();
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
        public async Task<PopularResult<PagedResultDto<UnitDto>>> GetAsync(int page, int limit, string interiorCode, string name)
        {
            return await _unitService.GetListAsync(new UnitQueryDto()
            {
                SkipCount = (page - 1) * limit,
                MaxResultCount = limit,
                InteriorCode = interiorCode,
                Name = name
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
        public async Task<PopularResult<byte[]>> GetExportAsync(int page, int limit, string interiorCode, string name)
        {
            return await _unitService.GetBytesAsync(new UnitQueryDto()
            {
                SkipCount = (page - 1) * limit,
                MaxResultCount = limit,
                Name = name,
                InteriorCode = interiorCode
            });
        }
    }
}

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
    public class DictController : PopularController
    {
        private readonly IDictService _dictService;

        public DictController(IDictService dictService)
        {
            _dictService = dictService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<PopularResult<string>> InsertAsync([FromBody] DictDto dto)
        {
            return await _dictService.InsertAsync(dto);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<PopularResult> DeleteAsync([Required] int id)
        {
            return await _dictService.DeleteAsync(id);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<PopularResult<string>> UpdateAsync([FromBody] DictDto dto)
        {
            return await _dictService.UpdateAsync(dto);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PopularResult<DictDto>> GetAsync([Required] int id)
        {
            return await _dictService.GetAsync(id);
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("All")]
        public async Task<PopularResult<List<DictDto>>> GetAllAsync()
        {
            return await _dictService.GetAllAsync();
        }
    }
}

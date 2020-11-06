using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Application.Contracts.Interface.Mis;
using Dym.Popular.Domain.Shared;
using Dym.Popular.Domain.Shared.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Dym.Popular.HttpApi.Controllers.Mis
{
    [ApiExplorerSettings(GroupName = ApiGrouping.GroupName_Mis)]
    public class VehicleMileageController : PopularController
    {
        private readonly IVehicleMileageService _vehicleMileageService;
        public readonly IConfiguration _configuration;

        public VehicleMileageController(IVehicleMileageService vehicleMileageService, IConfiguration configuration)
        {
            _configuration = configuration;
            _vehicleMileageService = vehicleMileageService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<PopularResult<string>> InsertAsync([FromBody] VehicleMileageDto dto)
        {
            dto.Creator = LoginUser.Id;
            dto.CreateTime = LoginUser.SysteDate;
            return await _vehicleMileageService.InsertAsync(dto);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<PopularResult> DeleteAsync([Required] int id)
        {
            return await _vehicleMileageService.DeleteAsync(id);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<PopularResult<string>> UpdateAsync([FromBody] VehicleMileageDto dto)
        {
            return await _vehicleMileageService.UpdateAsync(dto);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PopularResult<VehicleMileageDto>> GetAsync([Required] int id)
        {
            return await _vehicleMileageService.GetAsync(id);
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
        public async Task<PopularResult<PagedResultDto<VehicleMileageDto>>> GetPageAsync(int page, int limit, int isDelete, string license)
        {
            return await _vehicleMileageService.GetListAsync(new VehicleMileageQueryDto()
            {
                SkipCount = (page - 1) * limit,
                MaxResultCount = limit,
                IsDelete = isDelete,
                License = license
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
        public async Task<PopularResult<byte[]>> GetExportAsync(int page, int limit, string license)
        {
            return await _vehicleMileageService.GetBytesAsync(new VehicleMileageQueryDto()
            {
                SkipCount = (page - 1) * limit,
                MaxResultCount = limit,
                License = license
            });
        }

        [HttpPost]
        [Route("File")]
        public async Task<PopularResult<string>> FileUploadAsync([FromForm] IFormFile file)
        {
            var result = new PopularResult<string>();
            string filePath = _configuration["ImagePath"];
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            var fullPath = Path.Combine(filePath, DateTimeOffset.Now.ToUnixTimeSeconds().ToString() + Path.GetExtension(file.FileName));
            var imageFile = System.IO.File.Create(fullPath);
            await imageFile.WriteAsync(file.GetAllBytes());
            imageFile.Close();
            result.Success(Path.GetFileName(fullPath));
            return await Task.FromResult(result);
        }
    }
}

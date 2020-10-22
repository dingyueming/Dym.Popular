using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Application.Contracts.Interface.Mis;
using Dym.Popular.Domain.Shared.Result;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Dym.Popular.Domain.Shared;

namespace Dym.Popular.HttpApi.Controllers.Mis
{
    [ApiExplorerSettings(GroupName = ApiGrouping.GroupName_Mis)]
    public class VehiclesExportController : PopularController
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesExportController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="license"></param>
        /// <param name="vin"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PopularResult<byte[]>> GetAsync(int page, int limit, string license, string vin)
        {
            return await _vehicleService.GetBytes(new VehicleGetListDto()
            {
                SkipCount = (page - 1) * limit,
                MaxResultCount = limit,
                License = license,
                Vin = vin
            });
        }
    }
}

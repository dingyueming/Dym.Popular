using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Application.Contracts.Interface.Mis;
using Dym.Popular.Domain.Shared.Result;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using static Dym.Popular.Domain.Shared.Blogs.BlogDbConsts;

namespace Dym.Popular.HttpApi.Controllers.Mis
{
    [ApiExplorerSettings(GroupName = BlogGrouping.GroupName_Mis)]
    public class VehiclesController : PopularController
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
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
        public async Task<PopularResult<PagedResultDto<VehicleDto>>> GetAsync(int page, int limit, string license, string vin)
        {
            return await _vehicleService.GetListAsync(new GetVehicleListDto()
            {
                SkipCount = (page - 1) * limit,
                MaxResultCount = limit,
                License = license,
                Vin = vin
            });
        }
    }
}

using Dym.Popular.Application.Contracts.Dto.Blog;
using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Application.Contracts.Interface.Mis;
using Dym.Popular.Domain.Entities.Blogs;
using Dym.Popular.Domain.Entities.Mis;
using Dym.Popular.Domain.IRepositories.Blog;
using Dym.Popular.Domain.IRepositories.Mis;
using Dym.Popular.Domain.Shared.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dym.Popular.Application.Implements.Mis
{
    public class VehicleService : PopularAppService, IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<PopularResult<string>> InsertAsync(VehicleDto dto)
        {
            var result = new PopularResult<string>();
            var entity = ObjectMapper.Map<VehicleDto, VehicleEntity>(dto);
            var vehicle = await _vehicleRepository.InsertAsync(entity);
            if (vehicle == null)
            {
                result.Failed("添加失败");
                return result;
            }

            result.Success("添加成功");
            return result;
        }

        public async Task<PopularResult> DeleteAsync(int id)
        {
            var result = new PopularResult();

            await _vehicleRepository.DeleteAsync(id);

            return result;
        }

        public async Task<PopularResult<string>> UpdateAsync(int id, VehicleDto dto)
        {
            var result = new PopularResult<string>();

            var vehicle = await _vehicleRepository.GetAsync(id);
            if (vehicle == null)
            {
                result.Failed("数据不存在");
                return result;
            }

            vehicle = ObjectMapper.Map<VehicleDto, VehicleEntity>(dto);

            await _vehicleRepository.UpdateAsync(vehicle);
            result.Success("更新成功");
            return result;
        }

        public async Task<PopularResult<VehicleDto>> GetAsync(int id)
        {
            var result = new PopularResult<VehicleDto>();

            var vehicle = await _vehicleRepository.GetAsync(id);
            if (vehicle == null)
            {
                result.Failed("数据不存在");
                return result;
            }
            var dto = ObjectMapper.Map<VehicleEntity, VehicleDto>(vehicle);
            result.Success(dto);
            return result;
        }
    }
}

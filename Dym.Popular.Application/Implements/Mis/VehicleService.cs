using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Application.Contracts.Interface.Mis;
using Dym.Popular.Domain.Entities.Mis;
using Dym.Popular.Domain.IRepositories.Mis;
using Dym.Popular.Domain.Shared.Result;
using Dym.Popular.Utils.EPPlus;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

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

        public async Task<PopularResult<string>> UpdateAsync(VehicleDto dto)
        {
            var result = new PopularResult<string>();
            var vehicle = ObjectMapper.Map<VehicleDto, VehicleEntity>(dto);
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

        public async Task<PopularResult<PagedResultDto<VehicleDto>>> GetListAsync(VehicleGetListDto dto)
        {
            var result = new PopularResult<PagedResultDto<VehicleDto>>();

            var queryAble = _vehicleRepository
                  .WhereIf(!dto.License.IsNullOrWhiteSpace(), vehicle => vehicle.License.Contains(dto.License))
                  .WhereIf(!dto.Vin.IsNullOrWhiteSpace(), vehicle => vehicle.Vin.Contains(dto.Vin));

            var vehicles = await AsyncExecuter.ToListAsync(queryAble.PageBy(dto.SkipCount, dto.MaxResultCount));

            var totalCount = await AsyncExecuter.CountAsync(queryAble);

            var dtos = ObjectMapper.Map<List<VehicleEntity>, List<VehicleDto>>(vehicles);
            result.Success(new PagedResultDto<VehicleDto>(totalCount, dtos));
            return result;
        }

        public async Task<PopularResult<byte[]>> GetBytesAsync(VehicleGetListDto dto)
        {
            var result = new PopularResult<byte[]>();

            var queryAble = _vehicleRepository
                  .WhereIf(!dto.License.IsNullOrWhiteSpace(), vehicle => vehicle.License.Contains(dto.License))
                  .WhereIf(!dto.Vin.IsNullOrWhiteSpace(), vehicle => vehicle.Vin.Contains(dto.Vin));

            var vehicles = await AsyncExecuter.ToListAsync(queryAble);

            //转换为导出对象
            var dtos = ObjectMapper.Map<List<VehicleEntity>, List<VehicleExportDto>>(vehicles);

            var stream = EPPlusHelper.GetMemoryStream(dtos);

            result.Success(stream.ToArray());

            return result;
        }

        public async Task<PopularResult> BatchInsertAsync(List<VehicleDto> dto)
        {
            var result = new PopularResult();
            var vehicles = ObjectMapper.Map<List<VehicleDto>, List<VehicleEntity>>(dto);
            await _vehicleRepository.BulkInsertAsync(vehicles);
            return result;
        }
    }
}

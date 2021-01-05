using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Application.Contracts.Interface.Mis;
using Dym.Popular.Domain.Entities.Mis;
using Dym.Popular.Domain.IRepositories.Mis;
using Dym.Popular.Domain.Shared.Result;
using Dym.Popular.Utils.EPPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Dym.Popular.Application.Implements.Mis
{
    public class VehicleMileageService : PopularAppService, IVehicleMileageService
    {
        private readonly IVehicleMileageRepository _vehicleMileageRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IDictRepository _dictRepository;

        public VehicleMileageService(IVehicleMileageRepository vehicleMileageRepository, IVehicleRepository vehicleRepository, IDictRepository dictRepository)
        {
            _dictRepository = dictRepository;
            _vehicleMileageRepository = vehicleMileageRepository;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<PopularResult<string>> InsertAsync(VehicleMileageDto dto)
        {
            var result = new PopularResult<string>();
            var entity = ObjectMapper.Map<VehicleMileageDto, VehicleMileageEntity>(dto);
            var vehicleMileage = await _vehicleMileageRepository.InsertAsync(entity);
            if (vehicleMileage == null)
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
            await _vehicleMileageRepository.DeleteAsync(id);
            return result;
        }

        public async Task<PopularResult<string>> UpdateAsync(VehicleMileageDto dto)
        {
            var result = new PopularResult<string>();
            dto.Vehicle = null;
            var vehicleMileage = ObjectMapper.Map<VehicleMileageDto, VehicleMileageEntity>(dto);
            await _vehicleMileageRepository.UpdateAsync(vehicleMileage);
            result.Success("更新成功");
            return result;
        }

        public async Task<PopularResult<VehicleMileageDto>> GetAsync(int id)
        {
            var result = new PopularResult<VehicleMileageDto>();

            var vehicleMileage = await _vehicleMileageRepository.GetAsync(id);
            if (vehicleMileage == null)
            {
                result.Failed("数据不存在");
                return result;
            }
            var dto = ObjectMapper.Map<VehicleMileageEntity, VehicleMileageDto>(vehicleMileage);
            result.Success(dto);
            return result;
        }

        public async Task<PopularResult<PagedResultDto<VehicleMileageDto>>> GetListAsync(VehicleMileageQueryDto dto)
        {
            var result = new PopularResult<PagedResultDto<VehicleMileageDto>>();

            var queryable = _vehicleMileageRepository.Where(x => x.IsDelete == dto.IsDelete)
                .WhereIf(!dto.License.IsNullOrWhiteSpace(), vehicleMileage => vehicleMileage.Vehicle.License.Contains(dto.License));

            var query = from v in queryable.PageBy(dto.SkipCount, dto.MaxResultCount)
                        join
                        u in _vehicleRepository.WhereIf(!dto.License.IsNullOrWhiteSpace(), vehicle => vehicle.License.Contains(dto.License))
                        on v.VehicleId equals u.Id
                        into cls
                        from c in cls.DefaultIfEmpty()
                        select new VehicleMileageEntity(v.Id)
                        {
                            FileName = v.FileName,
                            Mileage = v.Mileage,
                            RecordDate = v.RecordDate,
                            Vehicle = c,
                            VehicleId = v.VehicleId,
                            //IsDelete = v.IsDelete,
                            CreateTime = v.CreateTime,
                            Creator = v.Creator,
                            Remark = v.Remark,
                        };


            var vehicleMileages = await AsyncExecuter.ToListAsync(query.PageBy(dto.SkipCount, dto.MaxResultCount));

            var totalCount = await AsyncExecuter.CountAsync(queryable);

            var dtos = ObjectMapper.Map<List<VehicleMileageEntity>, List<VehicleMileageDto>>(vehicleMileages);
            result.Success(new PagedResultDto<VehicleMileageDto>(totalCount, dtos));
            return result;
        }

        public async Task<PopularResult<byte[]>> GetBytesAsync(VehicleMileageQueryDto dto)
        {
            var result = new PopularResult<byte[]>();

            var queryable = _vehicleMileageRepository.Where(x => x.IsDelete == dto.IsDelete)
               .WhereIf(!dto.License.IsNullOrWhiteSpace(), vehicleMileage => vehicleMileage.Vehicle.License.Contains(dto.License));

            var vehicleMileages = await AsyncExecuter.ToListAsync(queryable);

            //转换为导出对象
            var dtos = ObjectMapper.Map<List<VehicleMileageEntity>, List<VehicleMileageDto>>(vehicleMileages);

            var stream = EPPlusHelper.GetMemoryStream(dtos);

            result.Success(stream.ToArray());

            return result;
        }
    }
}

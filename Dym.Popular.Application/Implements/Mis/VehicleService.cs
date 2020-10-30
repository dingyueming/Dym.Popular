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
        private readonly IUnitRepository _unitRepository;

        public VehicleService(IVehicleRepository vehicleRepository, IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
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
            var vehicle = await _vehicleRepository.GetAsync(id);
            if (vehicle == null)
            {
                result.Failed("数据不存在");
                return result;
            }
            vehicle.License += "-删除";
            vehicle.InteriorCode += "-删除";
            vehicle.IsDelete = 1;
            await _vehicleRepository.UpdateAsync(vehicle);
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

        public async Task<PopularResult<PagedResultDto<VehicleDto>>> GetListAsync(VehicleQueryDto dto)
        {
            var result = new PopularResult<PagedResultDto<VehicleDto>>();

            var queryable = _vehicleRepository.Where(x => x.IsDelete == dto.IsDelete)
                  .WhereIf(!dto.License.IsNullOrWhiteSpace(), vehicle => vehicle.License.Contains(dto.License))
                  .WhereIf(!dto.Vin.IsNullOrWhiteSpace(), vehicle => vehicle.Vin.Contains(dto.Vin))
                  .WhereIf(dto.UnitId.HasValue, vehicle => vehicle.UnitId == dto.UnitId);

            var query = from v in queryable.PageBy(dto.SkipCount, dto.MaxResultCount)
                        join
                        u in _unitRepository.WhereIf(dto.UnitId.HasValue, unit => unit.Id == dto.UnitId)
                        on v.UnitId equals u.Id
                        into cls
                        from c in cls.DefaultIfEmpty()
                        select new VehicleEntity(v.Id)
                        {
                            License = v.License,
                            IsDelete = v.IsDelete,
                            InteriorCode = v.InteriorCode,
                            EngineNo = v.EngineNo,
                            ActivationTime = v.ActivationTime,
                            Color = v.Color,
                            CreateTime = v.CreateTime,
                            Creator = v.Creator,
                            Displacement = v.Displacement,
                            Price = v.Price,
                            PurchaseDate = v.PurchaseDate,
                            Purpose = v.Purpose,
                            Remark = v.Remark,
                            UnitId = v.UnitId,
                            VehicleType = v.VehicleType,
                            Vin = v.Vin,
                            Unit = c
                        };

            var vehicles = query.ToList();

            var totalCount = await AsyncExecuter.CountAsync(queryable);

            var dtos = ObjectMapper.Map<List<VehicleEntity>, List<VehicleDto>>(vehicles);
            result.Success(new PagedResultDto<VehicleDto>(totalCount, dtos));
            return result;
        }

        public async Task<PopularResult<byte[]>> GetBytesAsync(VehicleQueryDto dto)
        {
            var result = new PopularResult<byte[]>();

            var queryable = _vehicleRepository.Where(x => x.IsDelete == dto.IsDelete)
                  .WhereIf(!dto.License.IsNullOrWhiteSpace(), vehicle => vehicle.License.Contains(dto.License))
                  .WhereIf(!dto.Vin.IsNullOrWhiteSpace(), vehicle => vehicle.Vin.Contains(dto.Vin))
                  .WhereIf(dto.UnitId.HasValue, vehicle => vehicle.UnitId == dto.UnitId);

            var query = from v in queryable.PageBy(dto.SkipCount, dto.MaxResultCount)
                        join
                        u in _unitRepository.WhereIf(dto.UnitId.HasValue, unit => unit.Id == dto.UnitId)
                        on v.UnitId equals u.Id
                        into cls
                        from c in cls.DefaultIfEmpty()
                        select new VehicleEntity(v.Id)
                        {
                            License = v.License,
                            IsDelete = v.IsDelete,
                            InteriorCode = v.InteriorCode,
                            EngineNo = v.EngineNo,
                            ActivationTime = v.ActivationTime,
                            Color = v.Color,
                            CreateTime = v.CreateTime,
                            Creator = v.Creator,
                            Displacement = v.Displacement,
                            Price = v.Price,
                            PurchaseDate = v.PurchaseDate,
                            Purpose = v.Purpose,
                            Remark = v.Remark,
                            UnitId = v.UnitId,
                            VehicleType = v.VehicleType,
                            Vin = v.Vin,
                            Unit = c
                        };

            var vehicles = await Task.FromResult(query.ToList());

            //转换为导出对象
            var dtos = ObjectMapper.Map<List<VehicleEntity>, List<VehicleDto>>(vehicles);

            var stream = EPPlusHelper.GetMemoryStream(dtos);

            result.Success(stream.ToArray());

            return result;
        }

        public async Task<PopularResult> BatchInsertAsync(List<VehicleDto> dtos)
        {
            var result = new PopularResult();
            var vehicles = ObjectMapper.Map<List<VehicleDto>, List<VehicleEntity>>(dtos);
            //基地名称转换为ID
            var units = await _unitRepository.GetListAsync();
            //foreach (var x in dtos)
            //{
            //    if (!units.Any(u => u.Name == x.UnitName))
            //    {
            //        result.Failed("未找到基地：" + x.UnitName);
            //        return result;
            //    }
            //}
            await _vehicleRepository.BulkInsertAsync(vehicles);
            return result;
        }
    }
}

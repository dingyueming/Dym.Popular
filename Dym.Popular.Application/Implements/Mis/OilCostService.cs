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
    public class OilCostService : PopularAppService, IOilCostService
    {
        private readonly IOilCostRepository _oilCostRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IDictRepository _dictRepository;

        public OilCostService(IOilCostRepository oilCostRepository, IVehicleRepository vehicleRepository, IDictRepository dictRepository)
        {
            _dictRepository = dictRepository;
            _oilCostRepository = oilCostRepository;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<PopularResult<string>> InsertAsync(OilCostDto dto)
        {
            var result = new PopularResult<string>();
            var entity = ObjectMapper.Map<OilCostDto, OilCostEntity>(dto);
            var oilCost = await _oilCostRepository.InsertAsync(entity);
            if (oilCost == null)
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
            await _oilCostRepository.DeleteAsync(id);
            return result;
        }

        public async Task<PopularResult<string>> UpdateAsync(OilCostDto dto)
        {
            var result = new PopularResult<string>();
            dto.Vehicle = null;
            dto.OilType = null;
            var oilCost = ObjectMapper.Map<OilCostDto, OilCostEntity>(dto);
            await _oilCostRepository.UpdateAsync(oilCost);
            result.Success("更新成功");
            return result;
        }

        public async Task<PopularResult<OilCostDto>> GetAsync(int id)
        {
            var result = new PopularResult<OilCostDto>();

            var oilCost = await _oilCostRepository.GetAsync(id);
            if (oilCost == null)
            {
                result.Failed("数据不存在");
                return result;
            }
            var dto = ObjectMapper.Map<OilCostEntity, OilCostDto>(oilCost);
            result.Success(dto);
            return result;
        }

        public async Task<PopularResult<PagedResultDto<OilCostDto>>> GetListAsync(OilCostQueryDto dto)
        {
            var result = new PopularResult<PagedResultDto<OilCostDto>>();

            var queryable = _oilCostRepository.Where(x => x.IsDelete == dto.IsDelete)
                .WhereIf(!dto.CardNo.IsNullOrWhiteSpace(), oilCost => oilCost.CardNo.Contains(dto.CardNo))
                .WhereIf(dto.VehicleId.HasValue, oilCost => oilCost.VehicleId == dto.VehicleId);

            var query = from v in queryable.PageBy(dto.SkipCount, dto.MaxResultCount)
                        join
                        u in _vehicleRepository.WhereIf(dto.VehicleId.HasValue, vehicle => vehicle.Id == dto.VehicleId)
                        on v.VehicleId equals u.Id
                        into cls
                        from c in cls.DefaultIfEmpty()
                        join d in _dictRepository.Where(x => true) on v.OilTypeId equals d.Id
                        into f
                        from e in f.DefaultIfEmpty()
                        select new OilCostEntity(v.Id)
                        {
                            Balance = v.Balance,
                            CardNo = v.CardNo,
                            Expend = v.Expend,
                            OilType = e,
                            OilTypeId = v.OilTypeId,
                            RefuelingTime = v.RefuelingTime,
                            Vehicle = c,
                            VehicleId = v.VehicleId,
                            IsDelete = v.IsDelete,
                            CreateTime = v.CreateTime,
                            Creator = v.Creator,
                            Remark = v.Remark,
                        };


            var oilCosts = await AsyncExecuter.ToListAsync(query.PageBy(dto.SkipCount, dto.MaxResultCount));

            var totalCount = await AsyncExecuter.CountAsync(queryable);

            var dtos = ObjectMapper.Map<List<OilCostEntity>, List<OilCostDto>>(oilCosts);
            result.Success(new PagedResultDto<OilCostDto>(totalCount, dtos));
            return result;
        }

        public async Task<PopularResult<byte[]>> GetBytesAsync(OilCostQueryDto dto)
        {
            var result = new PopularResult<byte[]>();

            var queryAble = _oilCostRepository
                 .WhereIf(!dto.CardNo.IsNullOrWhiteSpace(), oilCost => oilCost.CardNo.Contains(dto.CardNo))
                 .WhereIf(dto.VehicleId.HasValue, oilCost => oilCost.VehicleId.Equals(dto.VehicleId));

            var oilCosts = await AsyncExecuter.ToListAsync(queryAble);

            //转换为导出对象
            var dtos = ObjectMapper.Map<List<OilCostEntity>, List<OilCostDto>>(oilCosts);

            var stream = EPPlusHelper.GetMemoryStream(dtos);

            result.Success(stream.ToArray());

            return result;
        }
    }
}

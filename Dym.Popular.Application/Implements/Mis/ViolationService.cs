using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Application.Contracts.Interface.Mis;
using Dym.Popular.Domain.Entities.Mis;
using Dym.Popular.Domain.IRepositories.Mis;
using Dym.Popular.Domain.Shared.Result;
using Dym.Popular.Utils.EPPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Dym.Popular.Application.Implements.Mis
{
    public class ViolationService : PopularAppService, IViolationService
    {
        private readonly IViolationRepository _violationRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IDictRepository _dictRepository;

        public ViolationService(IViolationRepository violationRepository, IVehicleRepository vehicleRepository, IDictRepository dictRepository)
        {
            _dictRepository = dictRepository;
            _violationRepository = violationRepository;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<PopularResult<string>> InsertAsync(ViolationDto dto)
        {
            var result = new PopularResult<string>();
            var entity = ObjectMapper.Map<ViolationDto, ViolationEntity>(dto);
            var violation = await _violationRepository.InsertAsync(entity);
            if (violation == null)
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
            await _violationRepository.DeleteAsync(id);
            return result;
        }

        public async Task<PopularResult<string>> UpdateAsync(ViolationDto dto)
        {
            var result = new PopularResult<string>();
            dto.Vehicle = null;
            var violation = ObjectMapper.Map<ViolationDto, ViolationEntity>(dto);
            await _violationRepository.UpdateAsync(violation);
            result.Success("更新成功");
            return result;
        }

        public async Task<PopularResult<ViolationDto>> GetAsync(int id)
        {
            var result = new PopularResult<ViolationDto>();

            var violation = await _violationRepository.GetAsync(id);
            if (violation == null)
            {
                result.Failed("数据不存在");
                return result;
            }
            var dto = ObjectMapper.Map<ViolationEntity, ViolationDto>(violation);
            result.Success(dto);
            return result;
        }

        public async Task<PopularResult<PagedResultDto<ViolationDto>>> GetListAsync(ViolationQueryDto dto)
        {
            var result = new PopularResult<PagedResultDto<ViolationDto>>();

            var countQuery = _violationRepository.Where(x => x.IsDelete == dto.IsDelete)
            .WhereIf(!dto.License.IsNullOrWhiteSpace(), violation => violation.Vehicle.License.Contains(dto.License));

            var query = from m in countQuery.OrderBy(x => x.CreateTime).PageBy(dto.ToSkipCount(), dto.ToMaxResultCount())
                        join v in _vehicleRepository on m.VehicleId equals v.Id into cls
                        from c in cls.DefaultIfEmpty()
                        select new ViolationEntity(m.Id)
                        {
                            Fine = m.Fine,
                            Indemnity = m.Indemnity,
                            IsOutDanger = m.IsOutDanger,
                            TookDate = m.TookDate,
                            MaintenanceCost = m.MaintenanceCost,
                            Vehicle = c,
                            VehicleId = m.VehicleId,
                            IsDelete = m.IsDelete,
                            CreateTime = m.CreateTime,
                            Creator = m.Creator,
                            Remark = m.Remark,
                        };

            var violations = await AsyncExecuter.ToListAsync(query);

            var totalCount = await AsyncExecuter.CountAsync(countQuery);

            var dtos = ObjectMapper.Map<List<ViolationEntity>, List<ViolationDto>>(violations);
            result.Success(new PagedResultDto<ViolationDto>(totalCount, dtos));
            return result;
        }

        public async Task<PopularResult<byte[]>> GetBytesAsync(ViolationQueryDto dto)
        {
            var result = new PopularResult<byte[]>();

            var query = _violationRepository.Where(x => x.IsDelete == dto.IsDelete);

            var violations = await AsyncExecuter.ToListAsync(query);

            //转换为导出对象
            var dtos = ObjectMapper.Map<List<ViolationEntity>, List<ViolationDto>>(violations);

            var stream = EPPlusHelper.GetMemoryStream(dtos);

            result.Success(stream.ToArray());

            return result;
        }
    }
}

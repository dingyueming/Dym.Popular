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
    public class MaintenanceService : PopularAppService, IMaintenanceService
    {
        private readonly IMaintenanceRepository _maintenanceRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IDictRepository _dictRepository;

        public MaintenanceService(IMaintenanceRepository maintenanceRepository, IVehicleRepository vehicleRepository, IDictRepository dictRepository)
        {
            _dictRepository = dictRepository;
            _maintenanceRepository = maintenanceRepository;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<PopularResult<string>> InsertAsync(MaintenanceDto dto)
        {
            var result = new PopularResult<string>();
            var entity = ObjectMapper.Map<MaintenanceDto, MaintenanceEntity>(dto);
            var maintenance = await _maintenanceRepository.InsertAsync(entity);
            if (maintenance == null)
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
            await _maintenanceRepository.DeleteAsync(id);
            return result;
        }

        public async Task<PopularResult<string>> UpdateAsync(MaintenanceDto dto)
        {
            var result = new PopularResult<string>();
            dto.Vehicle = null;
            var maintenance = ObjectMapper.Map<MaintenanceDto, MaintenanceEntity>(dto);
            await _maintenanceRepository.UpdateAsync(maintenance);
            result.Success("更新成功");
            return result;
        }

        public async Task<PopularResult<MaintenanceDto>> GetAsync(int id)
        {
            var result = new PopularResult<MaintenanceDto>();

            var maintenance = await _maintenanceRepository.GetAsync(id);
            if (maintenance == null)
            {
                result.Failed("数据不存在");
                return result;
            }
            var dto = ObjectMapper.Map<MaintenanceEntity, MaintenanceDto>(maintenance);
            result.Success(dto);
            return result;
        }

        public async Task<PopularResult<PagedResultDto<MaintenanceDto>>> GetListAsync(MaintenanceQueryDto dto)
        {
            var result = new PopularResult<PagedResultDto<MaintenanceDto>>();

            var countQuery = _maintenanceRepository.Where(x => x.IsDelete == dto.IsDelete);
            //.WhereIf(!dto.License.IsNullOrWhiteSpace(), maintenance => maintenance.Vehicle.License.Contains(dto.License));

            var query = from m in _maintenanceRepository.OrderBy(x => x.CreateTime).PageBy(dto.ToSkipCount(), dto.ToMaxResultCount()).Where(x => x.IsDelete == dto.IsDelete)
                        join v in _vehicleRepository on m.VehicleId equals v.Id into cls
                        from c in cls.DefaultIfEmpty()
                        join d in _dictRepository on m.CostTypeId equals d.Id into md
                        from s in md.DefaultIfEmpty()
                        select new MaintenanceEntity(m.Id)
                        {
                            Address = m.Address,
                            CostType = s,
                            CostTypeId = m.CostTypeId,
                            Expend = m.Expend,
                            RecordTime = m.RecordTime,
                            Vehicle = c,
                            VehicleId = m.VehicleId,
                            //IsDelete = m.IsDelete,
                            CreateTime = m.CreateTime,
                            Creator = m.Creator,
                            Remark = m.Remark,
                        };

            var maintenances = await AsyncExecuter.ToListAsync(query);

            var totalCount = await AsyncExecuter.CountAsync(countQuery);

            var dtos = ObjectMapper.Map<List<MaintenanceEntity>, List<MaintenanceDto>>(maintenances);
            result.Success(new PagedResultDto<MaintenanceDto>(totalCount, dtos));
            return result;
        }

        public async Task<PopularResult<byte[]>> GetBytesAsync(MaintenanceQueryDto dto)
        {
            var result = new PopularResult<byte[]>();

            var query = _maintenanceRepository.Where(x => x.IsDelete == dto.IsDelete);

            var maintenances = await AsyncExecuter.ToListAsync(query);

            //转换为导出对象
            var dtos = ObjectMapper.Map<List<MaintenanceEntity>, List<MaintenanceDto>>(maintenances);

            var stream = EPPlusHelper.GetMemoryStream(dtos);

            result.Success(stream.ToArray());

            return result;
        }
    }
}

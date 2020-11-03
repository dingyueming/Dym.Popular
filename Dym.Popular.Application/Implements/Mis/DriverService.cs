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
    public class DriverService : PopularAppService, IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly IDictRepository _dictRepository;

        public DriverService(IDriverRepository driverRepository, IUnitRepository unitRepository, IDictRepository dictRepository)
        {
            _dictRepository = dictRepository;
            _driverRepository = driverRepository;
            _unitRepository = unitRepository;
        }

        public async Task<PopularResult<string>> InsertAsync(DriverDto dto)
        {
            var result = new PopularResult<string>();
            var entity = ObjectMapper.Map<DriverDto, DriverEntity>(dto);
            var driver = await _driverRepository.InsertAsync(entity);
            if (driver == null)
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
            await _driverRepository.DeleteAsync(id);
            return result;
        }

        public async Task<PopularResult<string>> UpdateAsync(DriverDto dto)
        {
            var result = new PopularResult<string>();
            dto.Unit = null;
            var driver = ObjectMapper.Map<DriverDto, DriverEntity>(dto);
            await _driverRepository.UpdateAsync(driver);
            result.Success("更新成功");
            return result;
        }

        public async Task<PopularResult<DriverDto>> GetAsync(int id)
        {
            var result = new PopularResult<DriverDto>();

            var driver = await _driverRepository.GetAsync(id);
            if (driver == null)
            {
                result.Failed("数据不存在");
                return result;
            }
            var dto = ObjectMapper.Map<DriverEntity, DriverDto>(driver);
            result.Success(dto);
            return result;
        }

        public async Task<PopularResult<PagedResultDto<DriverDto>>> GetListAsync(DriverQueryDto dto)
        {
            var result = new PopularResult<PagedResultDto<DriverDto>>();

            var queryable = _driverRepository.Where(x => x.IsDelete == dto.IsDelete)
                .WhereIf(!dto.Name.IsNullOrWhiteSpace(), driver => driver.Name.Contains(dto.Name))
                .WhereIf(!dto.Name.IsNullOrWhiteSpace(), driver => driver.Name.Contains(dto.Name))
                .WhereIf(dto.UnitId.HasValue, driver => driver.UnitId.Equals(dto.UnitId));

            var query = from v in queryable.PageBy(dto.SkipCount, dto.MaxResultCount)
                        join
                        u in _unitRepository.WhereIf(dto.UnitId.HasValue, unit => unit.Id == dto.UnitId)
                        on v.UnitId equals u.Id
                        into cls
                        from c in cls.DefaultIfEmpty()
                        join d in _dictRepository.Where(x => true) on v.ClassId equals d.Id
                        into f
                        from e in f.DefaultIfEmpty()
                        join cc in _dictRepository.Where(x => true) on v.StatusId equals cc.Id
                        into ee
                        from ff in ee.DefaultIfEmpty()
                        select new DriverEntity(v.Id)
                        {
                            Address = v.Address,
                            ClassId = v.ClassId,
                            FirstIssueDate = v.FirstIssueDate,
                            Hiredate = v.Hiredate,
                            IdNo = v.IdNo,
                            Name = v.Name,
                            Sex = v.Sex,
                            StatusId = v.StatusId,
                            IsDelete = v.IsDelete,
                            CreateTime = v.CreateTime,
                            Creator = v.Creator,
                            Remark = v.Remark,
                            UnitId = v.UnitId,
                            Unit = c,
                            Class = e,
                            Status = ff
                        };


            var drivers = await AsyncExecuter.ToListAsync(query.PageBy(dto.SkipCount, dto.MaxResultCount));

            var totalCount = await AsyncExecuter.CountAsync(queryable);

            var dtos = ObjectMapper.Map<List<DriverEntity>, List<DriverDto>>(drivers);
            result.Success(new PagedResultDto<DriverDto>(totalCount, dtos));
            return result;
        }

        public async Task<PopularResult<byte[]>> GetBytesAsync(DriverQueryDto dto)
        {
            var result = new PopularResult<byte[]>();

            var queryAble = _driverRepository
                 .WhereIf(!dto.Name.IsNullOrWhiteSpace(), driver => driver.Name.Contains(dto.Name))
                 .WhereIf(dto.UnitId != 0, driver => driver.UnitId.Equals(dto.UnitId));

            var drivers = await AsyncExecuter.ToListAsync(queryAble);

            //转换为导出对象
            var dtos = ObjectMapper.Map<List<DriverEntity>, List<DriverDto>>(drivers);

            var stream = EPPlusHelper.GetMemoryStream(dtos);

            result.Success(stream.ToArray());

            return result;
        }
    }
}

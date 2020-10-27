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
    public class DriverService : PopularAppService, IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
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

        public async Task<PopularResult<PagedResultDto<DriverDto>>> GetListAsync(DriverGetListDto dto)
        {
            var result = new PopularResult<PagedResultDto<DriverDto>>();

            var queryAble = _driverRepository
                  .WhereIf(!dto.Name.IsNullOrWhiteSpace(), driver => driver.Name.Contains(dto.Name))
                  .WhereIf(dto.UnitId != 0, driver => driver.UnitId.Equals(dto.UnitId));

            var drivers = await AsyncExecuter.ToListAsync(queryAble.PageBy(dto.SkipCount, dto.MaxResultCount));

            var totalCount = await AsyncExecuter.CountAsync(queryAble);

            var dtos = ObjectMapper.Map<List<DriverEntity>, List<DriverDto>>(drivers);
            result.Success(new PagedResultDto<DriverDto>(totalCount, dtos));
            return result;
        }

        public async Task<PopularResult<byte[]>> GetBytesAsync(DriverGetListDto dto)
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

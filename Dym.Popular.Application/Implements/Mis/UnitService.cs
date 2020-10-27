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
    public class UnitService : PopularAppService, IUnitService
    {
        private readonly IUnitRepository _unitRepository;

        public UnitService(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public async Task<PopularResult<string>> InsertAsync(UnitDto dto)
        {
            var result = new PopularResult<string>();
            var entity = ObjectMapper.Map<UnitDto, UnitEntity>(dto);
            var unit = await _unitRepository.InsertAsync(entity);
            if (unit == null)
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
            await _unitRepository.DeleteAsync(id);
            return result;
        }

        public async Task<PopularResult<string>> UpdateAsync(UnitDto dto)
        {
            var result = new PopularResult<string>();
            var unit = ObjectMapper.Map<UnitDto, UnitEntity>(dto);
            await _unitRepository.UpdateAsync(unit);
            result.Success("更新成功");
            return result;
        }

        public async Task<PopularResult<UnitDto>> GetAsync(int id)
        {
            var result = new PopularResult<UnitDto>();

            var unit = await _unitRepository.GetAsync(id);
            if (unit == null)
            {
                result.Failed("数据不存在");
                return result;
            }
            var dto = ObjectMapper.Map<UnitEntity, UnitDto>(unit);
            result.Success(dto);
            return result;
        }

        public async Task<PopularResult<List<UnitDto>>> GetAllAsync()
        {
            var result = new PopularResult<List<UnitDto>>();

            var units = await _unitRepository.GetListAsync();
            if (units == null)
            {
                result.Failed("数据不存在");
                return result;
            }
            var dtos = ObjectMapper.Map<List<UnitEntity>, List<UnitDto>>(units);
            result.Success(dtos);
            return result;
        }

        public async Task<PopularResult<PagedResultDto<UnitDto>>> GetListAsync(UnitGetListDto dto)
        {
            var result = new PopularResult<PagedResultDto<UnitDto>>();

            var queryAble = _unitRepository
                  .WhereIf(!dto.Name.IsNullOrWhiteSpace(), unit => unit.Name.Contains(dto.Name))
                  .WhereIf(!dto.InteriorCode.IsNullOrWhiteSpace(), unit => unit.InteriorCode.Contains(dto.InteriorCode));

            var units = await AsyncExecuter.ToListAsync(queryAble.PageBy(dto.SkipCount, dto.MaxResultCount));

            var totalCount = await AsyncExecuter.CountAsync(queryAble);

            var dtos = ObjectMapper.Map<List<UnitEntity>, List<UnitDto>>(units);
            result.Success(new PagedResultDto<UnitDto>(totalCount, dtos));
            return result;
        }

        public async Task<PopularResult<byte[]>> GetBytesAsync(UnitGetListDto dto)
        {
            var result = new PopularResult<byte[]>();

            var queryAble = _unitRepository
                  .WhereIf(!dto.Name.IsNullOrWhiteSpace(), unit => unit.Name.Contains(dto.Name))
                  .WhereIf(!dto.InteriorCode.IsNullOrWhiteSpace(), unit => unit.InteriorCode.Contains(dto.InteriorCode));

            var units = await AsyncExecuter.ToListAsync(queryAble);

            //转换为导出对象
            var dtos = ObjectMapper.Map<List<UnitEntity>, List<UnitDto>>(units);

            var stream = EPPlusHelper.GetMemoryStream(dtos);

            result.Success(stream.ToArray());

            return result;
        }
    }
}

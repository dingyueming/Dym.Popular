using Dym.Popular.Application.Contracts.Dto.Mis;
using Dym.Popular.Application.Contracts.Interface.Mis;
using Dym.Popular.Domain.Entities.Mis;
using Dym.Popular.Domain.IRepositories.Mis;
using Dym.Popular.Domain.Shared.Result;
using Dym.Popular.Utils.EPPlus;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Dym.Popular.Application.Implements.Mis
{
    public class DictTypeService : PopularAppService, IDictTypeService
    {
        private readonly IDictTypeRepository _dictTypeRepository;
        private readonly IDictRepository _dictRepository;

        public DictTypeService(IDictTypeRepository dictTypeRepository, IDictRepository dictRepository)
        {
            _dictTypeRepository = dictTypeRepository;
            _dictRepository = dictRepository;
        }

        public async Task<PopularResult<string>> InsertAsync(DictTypeDto dto)
        {
            var result = new PopularResult<string>();
            var entity = ObjectMapper.Map<DictTypeDto, DictTypeEntity>(dto);
            var dictType = await _dictTypeRepository.InsertAsync(entity);
            if (dictType == null)
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
            await _dictTypeRepository.DeleteAsync(id);
            return result;
        }

        public async Task<PopularResult<string>> UpdateAsync(DictTypeDto dto)
        {
            var result = new PopularResult<string>();
            var dictType = ObjectMapper.Map<DictTypeDto, DictTypeEntity>(dto);
            await _dictRepository.DeleteAsync(x => x.DictTypeId == dto.Id);
            await _dictTypeRepository.UpdateAsync(dictType);
            result.Success("更新成功");
            return result;
        }

        public async Task<PopularResult<DictTypeDto>> GetAsync(int id)
        {
            var result = new PopularResult<DictTypeDto>();

            var dictType = await _dictTypeRepository.GetAsync(id, true);
            if (dictType == null)
            {
                result.Failed("数据不存在");
                return result;
            }
            var dto = ObjectMapper.Map<DictTypeEntity, DictTypeDto>(dictType);
            result.Success(dto);
            return result;
        }

        public async Task<PopularResult<List<DictTypeDto>>> GetAllAsync()
        {
            var result = new PopularResult<List<DictTypeDto>>();

            var dictTypes = await _dictTypeRepository.GetListAsync();
            if (dictTypes == null)
            {
                result.Failed("数据不存在");
                return result;
            }
            var dtos = ObjectMapper.Map<List<DictTypeEntity>, List<DictTypeDto>>(dictTypes);
            result.Success(dtos);
            return result;
        }

        public async Task<PopularResult<PagedResultDto<DictTypeDto>>> GetListAsync(DictTypeQueryDto dto)
        {
            var result = new PopularResult<PagedResultDto<DictTypeDto>>();

            var queryable = _dictTypeRepository
                  .WhereIf(!dto.Name.IsNullOrWhiteSpace(), dictType => dictType.Name.Contains(dto.Name));

            var dictTypes = await _dictTypeRepository.GetPagedAsync(dto.Name, dto.SkipCount, dto.MaxResultCount);

            var totalCount = await AsyncExecuter.CountAsync(queryable);

            var dtos = ObjectMapper.Map<List<DictTypeEntity>, List<DictTypeDto>>(dictTypes);
            result.Success(new PagedResultDto<DictTypeDto>(totalCount, dtos));
            return result;
        }

        public async Task<PopularResult<byte[]>> GetBytesAsync(DictTypeQueryDto dto)
        {
            var result = new PopularResult<byte[]>();

            var queryAble = _dictTypeRepository
                  .WhereIf(!dto.Name.IsNullOrWhiteSpace(), dictType => dictType.Name.Contains(dto.Name));

            var dictTypes = await AsyncExecuter.ToListAsync(queryAble);

            //转换为导出对象
            var dtos = ObjectMapper.Map<List<DictTypeEntity>, List<DictTypeDto>>(dictTypes);

            var stream = EPPlusHelper.GetMemoryStream(dtos);

            result.Success(stream.ToArray());

            return result;
        }
    }
}

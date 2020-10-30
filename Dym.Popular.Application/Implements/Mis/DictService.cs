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
    public class DictService : PopularAppService, IDictService
    {
        private readonly IDictRepository _dictRepository;

        public DictService(IDictRepository dictRepository)
        {
            _dictRepository = dictRepository;
        }

        public async Task<PopularResult<string>> InsertAsync(DictDto dto)
        {
            var result = new PopularResult<string>();
            var entity = ObjectMapper.Map<DictDto, DictEntity>(dto);
            var dict = await _dictRepository.InsertAsync(entity);
            if (dict == null)
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
            await _dictRepository.DeleteAsync(id);
            return result;
        }

        public async Task<PopularResult<string>> UpdateAsync(DictDto dto)
        {
            var result = new PopularResult<string>();
            var dict = ObjectMapper.Map<DictDto, DictEntity>(dto);
            await _dictRepository.UpdateAsync(dict);
            result.Success("更新成功");
            return result;
        }

        public async Task<PopularResult<DictDto>> GetAsync(int id)
        {
            var result = new PopularResult<DictDto>();

            var dict = await _dictRepository.GetAsync(id);
            if (dict == null)
            {
                result.Failed("数据不存在");
                return result;
            }
            var dto = ObjectMapper.Map<DictEntity, DictDto>(dict);
            result.Success(dto);
            return result;
        }

        public async Task<PopularResult<List<DictDto>>> GetAllAsync()
        {
            var result = new PopularResult<List<DictDto>>();

            var dicts = await _dictRepository.GetListAsync();
            if (dicts == null)
            {
                result.Failed("数据不存在");
                return result;
            }
            var dtos = ObjectMapper.Map<List<DictEntity>, List<DictDto>>(dicts);
            result.Success(dtos);
            return result;
        }

        public async Task<PopularResult<List<DictDto>>> GetAllAsync(int id)
        {
            var result = new PopularResult<List<DictDto>>();

            var dicts = await AsyncExecuter.ToListAsync(_dictRepository.Where(x => x.DictTypeId == id));
            if (dicts == null)
            {
                result.Failed("数据不存在");
                return result;
            }
            var dtos = ObjectMapper.Map<List<DictEntity>, List<DictDto>>(dicts);
            result.Success(dtos);
            return result;
        }
    }
}

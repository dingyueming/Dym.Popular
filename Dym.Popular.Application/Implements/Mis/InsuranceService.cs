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

namespace Dym.Popular.Application.Implements.Mis
{
    public class InsuranceService : PopularAppService, IInsuranceService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IInsuranceRepository _insuranceRepository;

        public InsuranceService(IInsuranceRepository insuranceRepository, IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
            _insuranceRepository = insuranceRepository;
        }

        public async Task<PopularResult<string>> InsertAsync(InsuranceDto dto)
        {
            var result = new PopularResult<string>();
            var entity = ObjectMapper.Map<InsuranceDto, InsuranceEntity>(dto);
            var insurance = await _insuranceRepository.InsertAsync(entity);
            if (insurance == null)
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
            var insurance = await _insuranceRepository.GetAsync(id);
            if (insurance == null)
            {
                result.Failed("数据不存在");
                return result;
            }
            insurance.Delete();
            await _insuranceRepository.UpdateAsync(insurance);
            return result;
        }

        public async Task<PopularResult<string>> UpdateAsync(InsuranceDto dto)
        {
            var result = new PopularResult<string>();
            var insurance = ObjectMapper.Map<InsuranceDto, InsuranceEntity>(dto);
            await _insuranceRepository.UpdateAsync(insurance);
            result.Success("更新成功");
            return result;
        }

        public async Task<PopularResult<InsuranceDto>> GetAsync(int id)
        {
            var result = new PopularResult<InsuranceDto>();

            var insurance = await _insuranceRepository.GetAsync(id);
            if (insurance == null)
            {
                result.Failed("数据不存在");
                return result;
            }
            var dto = ObjectMapper.Map<InsuranceEntity, InsuranceDto>(insurance);
            result.Success(dto);
            return result;
        }

        public async Task<PopularResult<List<InsuranceDto>>> GetAllAsync()
        {
            var result = new PopularResult<List<InsuranceDto>>();

            var insurances = await _insuranceRepository.GetListAsync();
            if (insurances == null)
            {
                result.Failed("数据不存在");
                return result;
            }
            var dtos = ObjectMapper.Map<List<InsuranceEntity>, List<InsuranceDto>>(insurances);
            result.Success(dtos);
            return result;
        }

        public async Task<PopularResult<PagedResultDto<InsuranceDto>>> GetListAsync(InsuranceQueryDto dto)
        {
            var result = new PopularResult<PagedResultDto<InsuranceDto>>();

            var countQuery = _insuranceRepository.Where(x => x.IsDelete == dto.IsDelete)
            .WhereIf(!dto.License.IsNullOrWhiteSpace(), insurance => insurance.Vehicle.License.Contains(dto.License));

            var query = from m in countQuery.OrderBy(x => x.CreateTime).PageBy(dto.ToSkipCount(), dto.ToMaxResultCount())
                        join v in _vehicleRepository on m.VehicleId equals v.Id into cls
                        from c in cls.DefaultIfEmpty()
                        select new InsuranceEntity(m.Id)
                        {
                            EndDate = m.EndDate,
                            StartDate = m.StartDate,
                            Expend = m.Expend,
                            InsureCompany = m.InsureCompany,
                            InsureName = m.InsureName,
                            InsureNote = m.InsureNote,
                            InsureType = m.InsureType,
                            Vehicle = c,
                            VehicleId = m.VehicleId,
                            IsDelete = m.IsDelete,
                            CreateTime = m.CreateTime,
                            Creator = m.Creator,
                            Remark = m.Remark,
                        };

            var insurances = await AsyncExecuter.ToListAsync(query);

            var totalCount = await AsyncExecuter.CountAsync(countQuery);

            var dtos = ObjectMapper.Map<List<InsuranceEntity>, List<InsuranceDto>>(insurances);
            result.Success(new PagedResultDto<InsuranceDto>(totalCount, dtos));
            return result;
        }

        public async Task<PopularResult<byte[]>> GetBytesAsync(InsuranceQueryDto dto)
        {
            var result = new PopularResult<byte[]>();

            var query = _insuranceRepository.Where(x => x.IsDelete == dto.IsDelete);

            var insurances = await AsyncExecuter.ToListAsync(query);

            //转换为导出对象
            var dtos = ObjectMapper.Map<List<InsuranceEntity>, List<InsuranceDto>>(insurances);

            var stream = EPPlusHelper.GetMemoryStream(dtos);

            result.Success(stream.ToArray());

            return result;
        }
    }
}

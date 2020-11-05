using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    public class OilCostQueryDto : PagedAndSortedResultRequestDto
    {
        public string CardNo { get; set; }

        public int IsDelete { get; set; }

        public int? VehicleId { get; set; }
    }
}

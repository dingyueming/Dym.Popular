using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    public class VehicleGetListDto : PagedAndSortedResultRequestDto
    {
        public string Vin { get; set; }

        public string License { get; set; }

        public int IsDelete { get; set; }

        public int? UnitId { get; set; }
    }
}

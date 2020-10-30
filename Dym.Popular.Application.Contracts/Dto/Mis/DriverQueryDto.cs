using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    public class DriverQueryDto : PagedAndSortedResultRequestDto
    {
        public string Name { get; set; }

        public int UnitId { get; set; }
    }
}

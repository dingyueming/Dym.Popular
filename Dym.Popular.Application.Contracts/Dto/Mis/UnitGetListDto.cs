using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    public class UnitGetListDto : PagedAndSortedResultRequestDto
    {
        public string Name { get; set; }

        public string InteriorCode { get; set; }
    }
}

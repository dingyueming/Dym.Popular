using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    public class InsuranceQueryDto : PopularPagedQueryDto
    {
        public string License { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dym.Popular.Application.Contracts.Dto
{
    public class PopularBaseQueryDto : PagedAndSortedResultRequestDto
    {
        public int Page { get; set; }

        public int Limit { get; set; }

        public int IsDelete { get; set; }

        public override int SkipCount { get => (Page - 1) * Limit; set => base.SkipCount = value; }

        public override int MaxResultCount { get => Limit; set => base.MaxResultCount = value; }
    }
}

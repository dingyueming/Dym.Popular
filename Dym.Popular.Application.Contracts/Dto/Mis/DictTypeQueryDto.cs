using Dym.Popular.Utils.EPPlus;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    public class DictTypeQueryDto : PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// 字典名称
        /// </summary>
        public string Name { get; set; }

    }
}

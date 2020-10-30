using Dym.Popular.Utils.EPPlus;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    public class DictTypeDto : EntityDto<int>
    {
        /// <summary>
        /// 字典名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 字典集合
        /// </summary>
        public List<DictDto> Dicts { get; set; }
    }
}

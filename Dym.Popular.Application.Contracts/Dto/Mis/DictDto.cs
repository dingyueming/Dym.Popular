using Dym.Popular.Utils.EPPlus;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    public class DictDto : EntityDto<int>
    {
        /// <summary>
        /// 字典值
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 字典类型ID
        /// </summary>
        public int DictTypeId { get; set; }
    }
}

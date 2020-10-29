using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Dym.Popular.Domain.Entities.Mis
{
    public class DictEntity : Entity<int>
    {
        /// <summary>
        /// 字典Key
        /// </summary>
        public int Key { get; set; }
        /// <summary>
        /// 字典值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 字典分类
        /// </summary>
        public int DictTypeId { get; set; }
    }
}

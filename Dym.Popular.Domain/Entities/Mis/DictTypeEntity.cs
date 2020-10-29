using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Dym.Popular.Domain.Entities.Mis
{
    public class DictTypeEntity : Entity<int>
    {
        /// <summary>
        /// 字典名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 字典集合
        /// </summary>
        public List<DictEntity> Dicts { get; set; }
    }
}

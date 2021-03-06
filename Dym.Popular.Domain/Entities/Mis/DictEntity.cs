﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Dym.Popular.Domain.Entities.Mis
{
    public class DictEntity : Entity<int>
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

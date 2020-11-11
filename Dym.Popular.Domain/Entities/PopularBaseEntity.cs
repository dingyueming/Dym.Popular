using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Dym.Popular.Domain.Entities
{
    public class PopularBaseEntity<T> : Entity<T>
    {
        protected PopularBaseEntity() : base()
        {

        }
        protected PopularBaseEntity(T id) : base(id)
        {

        }
        /// <summary>
        /// 是否删除（报废）
        /// </summary>
        public virtual int IsDelete { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public virtual int Creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 删除操作
        /// </summary>
        public virtual void Delete()
        {
            IsDelete = 1;
        }
    }
}

using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Dym.Popular.Domain.Entities.Mis
{
    public class DriverEntity : Entity<int>
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 出生年月
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IdNo { get; set; }
        /// <summary>
        /// 身高
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// 体重
        /// </summary>
        public int Weight { get; set; }
        /// <summary>
        /// 档案编号
        /// </summary>
        public string FileNo { get; set; }
        /// <summary>
        /// 准驾车型
        /// </summary>
        public int Class { get; set; }
        /// <summary>
        /// 初始领证日期
        /// </summary>
        public DateTime FirstIssueDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public int Creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}

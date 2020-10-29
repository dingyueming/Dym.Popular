using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Dym.Popular.Domain.Entities.Mis
{
    public class DriverEntity : PopularBaseEntity<int>
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
        /// 单位
        /// </summary>
        public int UnitId { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public UnitEntity Unit { get; set; }
        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime Hiredate { get; set; }
        /// <summary>
        /// 员工状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 联系地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IdNo { get; set; }
        /// <summary>
        /// 准驾车型
        /// </summary>
        public int Class { get; set; }
        /// <summary>
        /// 初始领证日期
        /// </summary>
        public DateTime FirstIssueDate { get; set; }
    }
}

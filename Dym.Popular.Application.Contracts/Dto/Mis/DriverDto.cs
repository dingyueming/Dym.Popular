using AutoMapper;
using Dym.Popular.Utils.EPPlus;
using System;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    public class DriverDto : PopularBaseEntityDto<int>
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [EPPlusColumn("")]
        public string Name { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public int UnitId { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [IgnoreMap]
        [EPPlusColumn("单位")]
        public string UnitName { get => Unit == null ? "" : Unit.Name; set => UnitName = value; }
        /// <summary>
        /// 单位
        /// </summary>
        [IgnoreMap]
        public UnitDto Unit { get; set; }
        /// <summary>
        /// 入职时间
        /// </summary>
        [EPPlusColumn("Hiredate")]
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
    }
}

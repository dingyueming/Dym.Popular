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
        [EPPlusColumn("姓名")]
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
        /// 单位名称
        /// </summary>
        [EPPlusColumn("单位")]
        public string UnitName { get => Unit == null ? "" : Unit.Name; }
        /// <summary>
        /// 单位dto
        /// </summary>
        public UnitDto Unit { get; set; }
        /// <summary>
        /// 入职时间
        /// </summary>
        [EPPlusColumn("入职时间")]
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

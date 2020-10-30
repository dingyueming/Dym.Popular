using Dym.Popular.Utils.EPPlus;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    public class UnitDto : PopularBaseDto<int>
    {
        /// <summary>
        /// 单位名
        /// </summary>
        [EPPlusColumn("基地名称")]
        public string Name { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        [EPPlusColumn("内部编号")]
        public string InteriorCode { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [EPPlusColumn("地址")]
        public string Address { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [EPPlusColumn("联系人")]
        public string Liaison { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [EPPlusColumn("电话")]
        public string Telephone { get; set; }
        /// <summary>
        /// 车辆编制数
        /// </summary>
        [EPPlusColumn("车辆编制数")]
        public int VehicleCount { get; set; }
        /// <summary>
        /// 经纬度
        /// </summary>
        [EPPlusColumn("经纬度")]
        public string Position { get; set; }
    }
}

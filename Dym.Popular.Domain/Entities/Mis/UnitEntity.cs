using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;


namespace Dym.Popular.Domain.Entities.Mis
{
    /// <summary>
    /// 基地信息
    /// </summary>
    public class UnitEntity : PopularBaseEntity<int>
    {
        /// <summary>
        /// 单位名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string InteriorCode { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Liaison { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 车辆编制数
        /// </summary>
        public int VehicleCount { get; set; }
        /// <summary>
        /// 经纬度
        /// </summary>
        public string Position { get; set; }
    }
}

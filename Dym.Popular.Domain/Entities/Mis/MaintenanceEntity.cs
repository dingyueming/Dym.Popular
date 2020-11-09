using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Dym.Popular.Domain.Entities.Mis
{
    /// <summary>
    /// 维修保养
    /// </summary>
    public class MaintenanceEntity : PopularBaseEntity<int>
    {
        public MaintenanceEntity(int id) : base(id)
        {

        }
        /// <summary>
        /// 费用类型
        /// </summary>
        public int CostTypeId { get; set; }
        /// <summary>
        /// 费用类型
        /// </summary>
        public DictEntity CostType { get; set; }
        /// <summary>
        /// 车辆
        /// </summary>
        public int VehicleId { get; set; }
        /// <summary>
        /// 车辆
        /// </summary>
        public VehicleEntity Vehicle { get; set; }
        /// <summary>
        /// 费用
        /// </summary>
        public double Expend { get; set; }
        /// <summary>
        /// 维修保养时间
        /// </summary>
        public DateTime RecordTime { get; set; }
        /// <summary>
        /// 维修保养地点
        /// </summary>
        public string Address { get; set; }
    }
}

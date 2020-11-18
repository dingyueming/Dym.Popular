using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Dym.Popular.Domain.Entities.Mis
{
    /// <summary>
    /// 车辆违章
    /// </summary>
    public class ViolationEntity : PopularBaseEntity<int>
    {
        public ViolationEntity(int id) : base(id)
        {

        }
        /// <summary>
        /// 车辆
        /// </summary>
        public int VehicleId { get; set; }
        /// <summary>
        /// 车辆
        /// </summary>
        public VehicleEntity Vehicle { get; set; }
        /// <summary>
        /// 发生日期
        /// </summary>
        public DateTime TookDate { get; set; }
        /// <summary>
        /// 罚款
        /// </summary>
        public double Fine { get; set; }
        /// <summary>
        /// 赔偿
        /// </summary>
        public double Indemnity { get; set; }
        /// <summary>
        /// 维修费用
        /// </summary>
        public double MaintenanceCost { get; set; }
        /// <summary>
        /// 是否出险
        /// </summary>
        public int IsOutDanger { get; set; }
    }
}

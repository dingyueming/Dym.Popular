using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Dym.Popular.Domain.Entities.Mis
{
    /// <summary>
    /// 油料费用
    /// </summary>
    public class OilCostEntity : PopularBaseEntity<int>
    {
        public OilCostEntity(int id) : base(id)
        {

        }
        /// <summary>
        /// 加油卡卡号
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 油料类型
        /// </summary>
        public int OilTypeId { get; set; }
        /// <summary>
        /// 油料类型
        /// </summary>
        public DictEntity OilType { get; set; }
        /// <summary>
        /// 车辆
        /// </summary>
        public int VehicleId { get; set; }
        /// <summary>
        /// 车辆
        /// </summary>
        public VehicleEntity Vehicle { get; set; }
        /// <summary>
        /// 加油金额
        /// </summary>
        public double Expend { get; set; }
        /// <summary>
        /// 加油时间
        /// </summary>
        public DateTime RefuelingTime { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        public double Balance { get; set; }
    }
}

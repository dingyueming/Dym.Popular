using AutoMapper;
using Dym.Popular.Utils.EPPlus;
using System;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    public class OilCostDto : PopularBaseDto<int>
    {
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
        public DictDto OilType { get; set; }
        /// <summary>
        /// 车辆
        /// </summary>
        public int VehicleId { get; set; }
        /// <summary>
        /// 车辆
        /// </summary>
        public VehicleDto Vehicle { get; set; }
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

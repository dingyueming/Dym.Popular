using AutoMapper;
using Dym.Popular.Utils.EPPlus;
using System;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    public class MaintenanceDto : PopularBaseDto<int>
    {
        /// <summary>
        /// 费用类型
        /// </summary>
        public int CostTypeId { get; set; }
        /// <summary>
        /// 费用类型
        /// </summary>
        public DictDto CostType { get; set; }
        /// <summary>
        /// 车辆
        /// </summary>
        public int VehicleId { get; set; }
        /// <summary>
        /// 车辆
        /// </summary>
        public VehicleDto Vehicle { get; set; }
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

using Dym.Popular.Utils.EPPlus;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    public class ViolationDto : PopularBaseDto<int>
    {
        /// <summary>
        /// 车辆
        /// </summary>
        public int VehicleId { get; set; }
        /// <summary>
        /// 车辆
        /// </summary>
        public VehicleDto Vehicle { get; set; }
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

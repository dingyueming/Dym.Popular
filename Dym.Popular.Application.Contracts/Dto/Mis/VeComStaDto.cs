using System;
using System.Collections.Generic;
using System.Text;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    /// <summary>
    /// Vehicle Comprehensive Statistics Dto
    /// </summary>
    public class VeComStaDto
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public string License { get; set; }
        /// <summary>
        /// 累计里程
        /// </summary>
        public double Mileage { get; set; }
        /// <summary>
        /// 油量消耗
        /// </summary>
        public double OilCost { get; set; }
        /// <summary>
        /// 累计费用
        /// </summary>
        public double Maintenance { get; set; }
    }
}

using Dym.Popular.Utils.EPPlus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [EPPlusColumn("车牌号")]
        public string License { get; set; }
        /// <summary>
        /// 累计里程
        /// </summary>
        [EPPlusColumn("累计里程")]
        public double Mileage { get; set; }
        /// <summary>
        /// 油量消耗
        /// </summary>
        [EPPlusColumn("油量消耗")]
        public double OilCost { get; set; }
        /// <summary>
        /// 累计费用
        /// </summary>
        [EPPlusColumn("累计费用")]
        public double Maintenance { get; set; }
    }
}

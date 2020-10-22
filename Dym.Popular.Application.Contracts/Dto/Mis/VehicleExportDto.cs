using System;
using System.Collections.Generic;
using System.Text;
using Dym.Popular.Utils.EPPlus;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    public class VehicleExportDto
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        [EPPlusColumnName("车牌号")]
        public string License { get; set; }
        /// <summary>
        /// 车辆颜色
        /// </summary>
        [EPPlusColumnName("车辆颜色")]
        public string Color { get; set; }
        /// <summary>
        /// 发动机编号
        /// </summary>
        [EPPlusColumnName("发动机编号")]
        public string EngineNo { get; set; }
    }
}

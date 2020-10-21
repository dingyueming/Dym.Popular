using System;
using System.Collections.Generic;
using System.Text;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    public class VehicleDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string License { get; set; }
        /// <summary>
        /// 车辆颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 发动机编号
        /// </summary>
        public string EngineNo { get; set; }
        /// <summary>
        /// 车架号
        /// </summary>
        public string Vin { get; set; }
        /// <summary>
        /// 车辆类型
        /// </summary>
        public int VehicleType { get; set; }
        /// <summary>
        /// 购车价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 采购日期
        /// </summary>
        public DateTime PurchaseDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public int Creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

    }
}

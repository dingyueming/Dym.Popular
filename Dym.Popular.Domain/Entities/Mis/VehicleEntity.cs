using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Dym.Popular.Domain.Entities.Mis
{
    public class VehicleEntity : PopularBaseEntity<int>
    {
        public VehicleEntity()
        {
        }
        public VehicleEntity(int id)
        {
            base.Id = id;
        }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string License { get; set; }
        /// <summary>
        /// 内部编号
        /// </summary>
        public string InteriorCode { get; set; }
        /// <summary>
        /// 所属基地
        /// </summary>
        public int UnitId { get; set; }
        /// <summary>
        /// 车辆用途
        /// </summary>
        public int Purpose { get; set; }
        /// <summary>
        /// 车辆颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 发动机编号
        /// </summary>
        public string EngineNo { get; set; }
        /// <summary>
        /// 车辆型号
        /// </summary>
        public string Vin { get; set; }
        /// <summary>
        /// 车辆类型
        /// </summary>
        public int VehicleType { get; set; }
        /// <summary>
        /// 排量
        /// </summary>
        public string Displacement { get; set; }
        /// <summary>
        /// 购车价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 购车时间
        /// </summary>
        public DateTime PurchaseDate { get; set; }
        /// <summary>
        /// 投入使用时间
        /// </summary>
        public DateTime ActivationTime { get; set; }
        public UnitEntity Unit { get; set; }
    }
}

using AutoMapper;
using Dym.Popular.Utils.EPPlus;
using System;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    public class VehicleDto : PopularBaseEntityDto<int>
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        [EPPlusColumn("车牌号")]
        public string License { get; set; }
        /// <summary>
        /// 内部编号
        /// </summary>
        [EPPlusColumn("内部编号")]
        public string InteriorCode { get; set; }
        /// <summary>
        /// 所属基地
        /// </summary>
        public int UnitId { get; set; }
        [EPPlusColumn("所属基地")]
        [IgnoreMap]
        public string UnitName { get => Unit == null ? "" : Unit.Name; set => UnitName = value; }
        public UnitDto Unit { get; set; }
        /// <summary>
        /// 车辆用途
        /// </summary>
        [EPPlusColumn("车辆用途")]
        public int Purpose { get; set; }
        /// <summary>
        /// 车辆颜色
        /// </summary>
        [EPPlusColumn("车辆颜色")]
        public string Color { get; set; }
        /// <summary>
        /// 发动机编号
        /// </summary>
        [EPPlusColumn("发动机编号")]
        public string EngineNo { get; set; }
        /// <summary>
        /// 车辆型号
        /// </summary>
        [EPPlusColumn("车辆型号")]
        public string Vin { get; set; }
        /// <summary>
        /// 车辆类型
        /// </summary>
        [EPPlusColumn("车辆类型")]
        public int VehicleType { get; set; }
        /// <summary>
        /// 排量
        /// </summary>
        [EPPlusColumn("排量")]
        public string Displacement { get; set; }
        /// <summary>
        /// 购车价格
        /// </summary>
        [EPPlusColumn("购车价格")]
        public decimal Price { get; set; }
        /// <summary>
        /// 采购日期
        /// </summary>
        [EPPlusColumn("采购日期")]
        public DateTime PurchaseDate { get; set; }
        /// <summary>
        /// 投用日期
        /// </summary>
        [EPPlusColumn("投用日期")]
        public DateTime ActivationTime { get; set; }
    }
}

using AutoMapper;
using Dym.Popular.Utils.EPPlus;
using System;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    public class VehicleMileageDto : PopularBaseDto<int>
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
        /// 里程
        /// </summary>
        public double Mileage { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 上报时间
        /// </summary>
        public DateTime RecordDate { get; set; }
    }
}

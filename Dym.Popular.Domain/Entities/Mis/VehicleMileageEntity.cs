using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Dym.Popular.Domain.Entities.Mis
{
    /// <summary>
    /// 车辆里程
    /// </summary>
    public class VehicleMileageEntity : PopularBaseEntity<int>
    {
        public VehicleMileageEntity(int id) : base(id)
        {

        }
        /// <summary>
        /// 车辆
        /// </summary>
        public int VehicleId { get; set; }
        /// <summary>
        /// 车辆
        /// </summary>
        public VehicleEntity Vehicle { get; set; }
        /// <summary>
        /// 里程
        /// </summary>
        public double Mileage { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime RecordDate { get; set; }
    }
}

using Dym.Popular.Utils.EPPlus;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Dym.Popular.Application.Contracts.Dto.Mis
{
    public class InsuranceDto : PopularBaseDto<int>
    {
        /// <summary>
        /// 车辆ID
        /// </summary>
        public int VehicleId { get; set; }
        /// <summary>
        /// 车辆
        /// </summary>
        public VehicleDto Vehicle { get; set; }
        /// <summary>
        /// 保险项目
        /// </summary>
        public string InsureName { get; set; }
        /// <summary>
        /// 保险开始日期
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 保险结束日期
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 保险公司
        /// </summary>
        public string InsureCompany { get; set; }
        /// <summary>
        /// 保险种类
        /// </summary>
        public string InsureType { get; set; }
        /// <summary>
        /// 保险说明
        /// </summary>
        public string InsureNote { get; set; }
        /// <summary>
        /// 投保金额
        /// </summary>
        public double Expend { get; set; }
    }
}

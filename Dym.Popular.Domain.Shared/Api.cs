using System;
using System.Collections.Generic;
using System.Text;

namespace Dym.Popular.Domain.Shared
{
    /// <summary>
    /// Api分组
    /// </summary>
    public class ApiGrouping
    {
        /// <summary>
        /// 博客前台接口组
        /// </summary>
        public const string GroupName_UI = "v1";

        /// <summary>
        /// 博客后台接口组
        /// </summary>
        public const string GroupName_Admin = "v2";

        /// <summary>
        /// 项目通用接口组
        /// </summary>
        public const string GroupName_Common = "v3";

        /// <summary>
        /// 押运车辆综合管理系统
        /// </summary>
        public const string GroupName_Mis = "v5";
    }
}

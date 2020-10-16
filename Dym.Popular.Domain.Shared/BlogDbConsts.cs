﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dym.Popular.Domain.Shared.Blogs
{
    public class BlogDbConsts
    {
        public static class DbTableName
        {
            public const string Posts = "_Posts";

            public const string Categories = "_Categories";

            public const string Tags = "_Tags";

            public const string PostTags = "_Post_Tags";

            public const string Friendlinks = "_Friendlinks";
        }
        /// <summary>
        /// 博客分组
        /// </summary>
        public static class BlogGrouping
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
}

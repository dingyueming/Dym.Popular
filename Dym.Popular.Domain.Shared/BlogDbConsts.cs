using System;
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
    }
}

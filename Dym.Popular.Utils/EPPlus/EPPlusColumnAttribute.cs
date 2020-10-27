using System;
using System.Collections.Generic;
using System.Text;

namespace Dym.Popular.Utils.EPPlus
{
    public class EPPlusColumnAttribute : Attribute
    {
        public EPPlusColumnAttribute(string columnName)
        {
            ColumnName = columnName;
        }
        public string ColumnName { get; set; }
    }
}

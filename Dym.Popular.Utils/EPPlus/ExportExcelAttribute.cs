using System;
using System.Collections.Generic;
using System.Text;

namespace Dym.Popular.Utils.EPPlus
{
    public class ExportExcelAttribute : Attribute
    {
        public ExportExcelAttribute(string columnName)
        {
            ColumnName = columnName;
        }
        public string ColumnName { get; set; }
    }
}

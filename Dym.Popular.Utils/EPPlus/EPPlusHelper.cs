using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;

namespace Dym.Popular.Utils.EPPlus
{
    public class EPPlusHelper
    {
        /// <summary>
        /// 导出数据到Excel中
        /// </summary>
        /// <param name="list"></param>
        public static MemoryStream GetMemoryStream<T>(List<T> list)
        {
            var dt = ListToTable(list);
            var ms = new MemoryStream();
            //在using语句里面我们可以创建多个worksheet，ExcelPackage后面可以传入路径参数
            //指定非商业证书
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(ms))
            {
                //创建工作表worksheet
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                //给单元格赋值有两种方式
                //worksheet.Cells[1, 1].Value = "单元格的值";直接指定行列数进行赋值
                //worksheet.Cells["A1"].Value = "单元格的值";直接指定单元格进行赋值
                worksheet.Cells.Style.Font.Name = "微软雅黑";
                worksheet.Cells.Style.Font.Size = 12;
                //worksheet.Cells.Style.ShrinkToFit = true;//单元格自动适应大小

                //第一行设置为table的列头
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dt.Columns[i].ColumnName;
                }
                //table内容
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dt.Rows[i][j].ToString();
                    }
                }
                //设置样式
                using (var cell = worksheet.Cells[1, 1, 1, dt.Columns.Count])
                {
                    //设置样式:首行居中加粗背景色
                    cell.Style.Font.Bold = true; //加粗
                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; //水平居中
                    cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;     //垂直居中
                    cell.Style.Font.Size = 14;
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;  //背景颜色
                    cell.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(204, 232, 207));//设置单元格背景色
                }

                //保存
                package.Save();
            }
            return ms;
        }

        /// <summary>
        /// 读取Excel数据
        /// </summary>
        /// <param name="fileName"></param>
        public static string ReadExcel(string fileName)
        {
            StringBuilder sb = new StringBuilder();
            FileInfo file = new FileInfo(fileName);
            try
            {
                using (ExcelPackage package = new ExcelPackage(file))
                {
                    var count = package.Workbook.Worksheets.Count;
                    for (int k = 1; k <= count; k++)  //worksheet是从1开始的
                    {
                        var workSheet = package.Workbook.Worksheets[k];
                        sb.Append(workSheet.Name);
                        sb.Append(Environment.NewLine);
                        int row = workSheet.Dimension.Rows;
                        int col = workSheet.Dimension.Columns;
                        for (int i = 1; i <= row; i++)
                        {
                            for (int j = 1; j <= col; j++)
                            {
                                sb.Append(workSheet.Cells[i, j].Value.ToString() + "\t");
                            }
                            sb.Append(Environment.NewLine);
                        }
                        sb.Append(Environment.NewLine);
                        sb.Append(Environment.NewLine);
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return sb.ToString();
        }


        #region 私有方法

        private static DataTable ListToTable<T>(List<T> list)
        {
            Type tp = typeof(T);
            PropertyInfo[] proInfos = tp.GetProperties();
            DataTable dt = new DataTable();
            foreach (var item in proInfos)
            {
                //解决DataSet不支持System.Nullable<>问题
                Type colType = item.PropertyType;
                if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                {
                    colType = colType.GetGenericArguments()[0];
                }
                //添加列名及对应类型 
                {
                    var attribute = item.GetCustomAttribute<ExportExcelAttribute>();
                    if (attribute != null)
                    {
                        dt.Columns.Add(attribute.ColumnName, colType);
                    }
                    else
                    {
                        dt.Columns.Add(item.Name, colType);
                    }
                }

            }
            foreach (var item in list)
            {
                DataRow dr = dt.NewRow();
                foreach (var proInfo in proInfos)
                {
                    object obj = proInfo.GetValue(item);
                    if (obj == null)
                    {
                        continue;
                    }
                    if (proInfo.PropertyType == typeof(DateTime) && Convert.ToDateTime(obj) < Convert.ToDateTime("1753-01-01"))
                    {
                        continue;
                    }
                    var columnName = proInfo.Name;
                    var attribute = proInfo.GetCustomAttribute<ExportExcelAttribute>();
                    if (attribute != null)
                    {
                        columnName = attribute.ColumnName;
                    }
                    dr[columnName] = obj;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        #endregion
    }
}

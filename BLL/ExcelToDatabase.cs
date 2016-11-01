using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BLL
{
    public class ExcelToDatabase
    {
        /// <summary>
        /// 检查excel文件的大小以及格式（后缀）
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="identity">数据库表名</param>
        /// <returns></returns>
        public static string CheckFile(string fileName, string identity)
        {
            int filesize = 0;
            string fileextend = "";
            try
            {
                if (fileName != string.Empty)
                {
                    filesize = fileName.Length;//判断文件路径长度就能判断文件大小为0吗？？？？？？？？？？？
                    if (filesize == 0)
                    {
                        return "导入的Excel文件大小为0，请检查是否正确！";

                    }
                    fileextend = fileName.Substring(fileName.LastIndexOf(".") + 1);
                    if (fileextend != "xls")
                    {
                        return "选择的文件格式不正确，只能导入Excel文件！";

                    }
                    return ToSQLSever(fileName, identity);

                }
                else
                    return "文件为空，请重新选择！";
            }
            catch (Exception ex)
            { throw ex; }
        }
        /// <summary>
        /// 中转作用，将Excel导入到SqlServer并返回导入的结果，另带检查，只有表名符合规范才能导入
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="identity"></param>
        /// <returns>导入的结果</returns>
        public static string ToSQLSever(string fileName, string identity)
        {
            if (identity == "TabTeachers" | identity == "TabOtherTeachers")
            {
                return DAL.ExcelToSQLServer.ReadTeachersExcel(fileName, identity);
            }
            else if (identity == "TabCalendar")
            {
                return DAL.ExcelToSQLServer.ReadCalendarExcel(fileName, identity);
            }
            else
            {
                return DAL.ExcelToSQLServer.ReadCoursesExcel(fileName, identity);
            }
        }
    }
}

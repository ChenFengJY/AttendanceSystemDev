using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Class1
    {
        public static string ReadCalendarExcel(string fileName, string identity)
        {
            List<string> SheetName = new List<string>();
            SheetName = GetSheetName(fileName);
            string strSQL = "";
            if (SheetName[0] != "sheet1$")
            {
                return "指定的Excel文件的工作名不为“Sheet1”,当前的表名为" + SheetName[0];
            }
            strSQL = "select*from [Sheet1$]";
            ReadExcelToDataSet(fileName, strSQL);
            if (CheckExcelTableCalendar())
            {
                CalendarToSQLServer(identity);
                return "文件导入成功！";
            }
            else
            {
                return "选择的Excel文件中的内容与数据库要求不匹配，请确认！";
            }
        }
}

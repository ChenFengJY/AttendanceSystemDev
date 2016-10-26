﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BLL
{
    public class ExcelToDatabase
    {
        public static string CheckFile(string fileName, string identity)
        {
            int filesize = 0;
            string fileextend = "";
            try
            {
                if (fileName != string.Empty)
                {
                    filesize = fileName.Length;
                    if (filesize == 0)
                    {
                        return "导入的Excel文件大小为0，请检查是否正确！";

                    }
                    fileextend = fileName.Substring(fileName.LastIndexOf("." + 1));
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
        public static string ToSQLSever(string fileName, string identity)
        {
            if (identity == "TabTeachers" | identity == "TabOtherTeachers")
            {
                return DAL.ExcelToSQLServer.ReadCalendarExcel(fileName, identity);
            }
            else if (identity == "TabCalendar")
            {
                return DAL.ExcelToSQLServer.ReadCalendarExcel(fileName, identity);

            }
            else
            {
                return DAL.ExcelToSQLServer.ReadCalendarExcel(fileName, identity);
            }
        }
    }
}

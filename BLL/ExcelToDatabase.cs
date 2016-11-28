using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.OleDb;
using System.Data;

namespace BLL
{
    public class ExcelToDatabase
    {
        private static DataSet ds;
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
                    else
                    {
                        return ToSQLSever(fileName, identity);
                    }

                }
                else
                    return "文件为空，请重新选择！";
            }
            catch (Exception ex)
            { throw ex; }
        }

        /// <summary>
        /// 中转作用，将Excel导入到SqlServer并返回导入的结果，
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="identity"></param>
        /// <returns>导入的结果</returns>
        public static string ToSQLSever(string fileName, string identity)
        {
            string[] str = { "会计系", "信息工程系", "经济管理系", "食品工程系", "机械工程系", "商务外语系", "建筑工程系","教务处","基础教学部" };
            if (identity == "TabTeachers" | identity == "TabOtherTeachers")
            {
                return ReadTeachersExcel(fileName, identity);
            }
            else if (identity == "TabCalendar")
            {
                return ReadCalendarExcel(fileName, identity);
            }
            else if(Array.IndexOf<string>(str,identity)!=-1)
           {
                return ReadCoursesExcel(fileName, identity);
            }
            else
            {
                return "选择的表名不符合规范";
            }

        }

        /// <summary>
        /// 读取课程Excel并保存到SQL
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string ReadCoursesExcel(string fileName, string identity)
        {
            List<string> SheetName = new List<string>();
            SheetName = GetSheetName(fileName);
            string strSQL = "";
            if (SheetName[0] != identity + "$")
            {
                return "指定的Excel文件的工作表名不为" + identity + ",当前的表名为" + SheetName[0];
            }
            strSQL = "select * from [" + SheetName[0] + "]";
            ReadExcelToDataSet(fileName, strSQL);

            if (CheckExcelTableCourses())
            {
                //CoursesTOSQLServer(identity);
                //在原表的基础上添加两列数据并指定添加的位置，使得与数据库目标表结构相同
                DataTable dt = ds.Tables["ExcelInfo"];
                dt.Columns.Add("TeacherID");
                dt.Columns["TeacherID"].SetOrdinal(1);
                dt.Columns.Add("TeacherName");
                dt.Columns["TeacherName"].SetOrdinal(2);

                dt.Columns.Add("CourseID");
                dt.Columns.Add("CourseName");
                dt.Columns["CourseID"].SetOrdinal(5);
                dt.Columns["CourseName"].SetOrdinal(6);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SplitToDataTable.SplitTeacherIDAndTeacherName(dt.Rows[i]);
                }
                //移除已经拆分完毕的列--任课教师
                dt.Columns.Remove(dt.Columns[3]);
                dt.Columns.Remove(dt.Columns[6]);

                
                return ExcelToSQLServer.DataTableToSQLServer(DisposeDataTable(dt), "TabTeacherAllCourse", 21);
            }
            else
                return "选择的Excel文件中的内容与数据库要求不匹配。请确认！";
        }

        private static DataTable DisposeDataTable(DataTable dt)
        {
            dt.Columns.Add("SplitTimeAndArea");//单节课信息
            dt.Columns["SplitTimeAndArea"].SetOrdinal(3);

            DataTable TabCourseSimple = dt.Clone();//中转作用，保存拆分
            TabCourseSimple.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SplitToDataTable.SplitTimeAndArea(dt.Rows[i], 4, TabCourseSimple, 3, new char[] { '@' });
            }
            
            //表列结构[TeacherDepartment],[TeacherID],[TeacherName],[SplitTimeAndArea],[TimeAndArea]
            TabCourseSimple.Columns.Add("CourseAllWeek");//所有周
            TabCourseSimple.Columns.Add("CourseWeek");//星期数
            TabCourseSimple.Columns.Add("CourseTime");//节数
            TabCourseSimple.Columns.Add("CourseAddress");//教室地址
            TabCourseSimple.Columns["CourseAllWeek"].SetOrdinal(3);
            TabCourseSimple.Columns["CourseWeek"].SetOrdinal(4);
            TabCourseSimple.Columns["CourseTime"].SetOrdinal(5);
            TabCourseSimple.Columns["CourseAddress"].SetOrdinal(6);

            for (int i = 0; i < TabCourseSimple.Rows.Count; i++)
            {
                SplitToDataTable.SplitTimeAndArea2(TabCourseSimple.Rows[i]);
            }
            TabCourseSimple.Columns.RemoveAt(7);

            //ConnHelper.DataTableToSQLServer("TabTeacherAllCourse", TabCourseSimple);

            //表列结构[TeacherDepartment],[TeacherID],[TeacherName],CourseAllWeek,CourseWeek,CourseTime,CourseAddress,[TimeAndArea]

            return TabCourseSimple;
        }
    



        /// <summary>
        /// 读取教师信息Excel并保存到SQL
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string ReadTeachersExcel(string fileName, string identity)
        {
            List<string> SheetName = new List<string>();
            SheetName = GetSheetName(fileName);
            string strSQL = "";

            if (SheetName[0] != "Sheet1$")
            {
                return "指定的Excel文件的工作表名不为“Sheet1”,当前的表名为" + SheetName[0];
            }
            strSQL = "select * from [Sheet1$]";
            ReadExcelToDataSet(fileName, strSQL);

            if (CheckExcelTableTeachers())
            {
                DataTable dt = ds.Tables["ExcelInfo"];
                //  TeachersToSQLServer(identity);
                return ExcelToSQLServer.DataTableToSQLServer(dt,identity, 6);
            }
            else
            {
                return "选择的Excel文件中的内容与数据与数据库中的要求不匹配，请确认！";
            }
        }

        /// <summary>
        /// 读取校历Excel并保存到SQL
        /// </summary>
        /// <param name="fileName">服务器端Excel文件路径</param>
        /// <param name="identity">sql表名</param>
        /// <returns></returns>
        public static string ReadCalendarExcel(string fileName, string identity)
        {
            List<string> SheetName = new List<string>();
            SheetName = GetSheetName(fileName);
            string strSQL = "";

            if (SheetName[0] != "Sheet1$")
            {
                return "指定的Excel文件的工作表不为“Sheet1”,当前的表名为" + SheetName[0];
            }
            strSQL = "select * from [Sheet1$]";
            ReadExcelToDataSet(fileName, strSQL);

            if (CheckExcelTableCalendar())
            {
                DataTable dt = ds.Tables["ExcelInfo"];
                // CalenderToSQLServer(identity);
                return ExcelToSQLServer.DataTableToSQLServer(dt,identity, 3);
            }
            else
            {
                return "选择的Excel文件中的内容与数据与数据库中的要求不匹配，请确认！";
            }

        }

        /// <summary>
        /// 获取Excel表Sheet名
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static List<string> GetSheetName(string fileName)
        {
            string str1 = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(str1);
            conn.Open();

            List<string> SheetNameList = new List<string>();
            DataTable dtExcelSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string SheetName = "";
            for (int i = 0; i < dtExcelSchema.Rows.Count; i++)
            {
                SheetName = dtExcelSchema.Rows[i]["TABLE_NAME"].ToString();
                SheetNameList.Add(SheetName);
            }
            conn.Close();
            conn.Dispose();
            return SheetNameList;
        }

        /// <summary>
        /// 从本地读取Excel到DataSet并分别指定里面的DataTable名为ExcelInfo
        /// </summary>
        /// <param name="fileName">服务器端Excel文件路径</param>
        /// <param name="strSQL"></param>
        public static void ReadExcelToDataSet(string fileName, string strSQL)
        {
            string str1 = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(str1);
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(strSQL, conn);
            da.SelectCommand.CommandTimeout = 600;

            ds = new DataSet();
            da.Fill(ds, "ExcelInfo");
            conn.Close();
            conn.Dispose();
        }

        /// <summary>
        /// 检查课程表列名是否符合规范
        /// </summary>
        /// <returns></returns>
        private static bool CheckExcelTableCourses()
        {
            try
            {
                string[] str = { "承担单位", "任课教师", "上课时间/地点", "课程", "所属部门" };
                for (int i = 0; i <= 4; i++)
                {
                    if (ds.Tables["ExcelInfo"].Columns[i].ColumnName.ToString() != str[i])
                        return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 检查教师Excel表的列名是否规范
        /// </summary>
        /// <returns></returns>
        private static bool CheckExcelTableTeachers()
        {
            try
            {
                string[] str = { "部门", "工号", "密码", "姓名", "性别", "权限" };
                for (int i = 0; i <= 5; i++)
                {
                    if (ds.Tables["ExcelInfo"].Columns[i].ColumnName.ToString() != str[i])
                        return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 检查校历Excel表的列名是否规范
        /// </summary>
        /// <returns></returns>
        private static bool CheckExcelTableCalendar()
        {
            try
            {
                string[] str = { "周次", "起", "止" };
                for (int i = 0; i <= 2; i++)
                {
                    if (ds.Tables["ExcelInfo"].Columns[i].ColumnName.ToString() != str[i])
                        return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 清空第一次导入数据库数据
        /// </summary>
        /// <returns></returns>
        public static bool ClearExcel()
        {
            bool clearTabTeachers=true, clearTabOtherTeachers, clearTabCalendar, clearTabAllCourses, clearTabTeacherAllCourse, clearTabTeacherCourseWeek;//记录删除成果
            clearTabAllCourses = ConnHelper.ExecuteNoneQueryOperation("truncate table TabAllCourses");
            //clearTabTeachers = ConnHelper.ExecuteNoneQueryOperation("truncate table TabTeachers");
            clearTabCalendar = ConnHelper.ExecuteNoneQueryOperation("truncate table TabCalendar");
            clearTabOtherTeachers = ConnHelper.ExecuteNoneQueryOperation("truncate table TabOtherTeachers");
            clearTabTeacherAllCourse = ConnHelper.ExecuteNoneQueryOperation("truncate table TabTeacherAllCourse");
            clearTabTeacherCourseWeek = ConnHelper.ExecuteNoneQueryOperation("truncate table TabTeacherCourseWeek");
            //ConnHelper.ExecuteNoneQueryOperation("delete from TabAllCourses");//可找回但速度慢
            return clearTabTeachers && clearTabOtherTeachers && clearTabCalendar && clearTabAllCourses&& clearTabTeacherAllCourse&& clearTabTeacherCourseWeek;
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 将Excel表读取到sql
    /// 根据文件路径（服务器端）读取Excel表存到容器中（DataSet）,然后遍历容器，分别将数据插入到Sql中
    /// </summary>
    public class ExcelToSQLServer
    {
        private static DataSet ds;
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
                for (int i = 0; i < dt.Rows.Count; i++  )
                {
                    SplitTeacherIDAndTeacherName(dt.Rows[i]);
                }
                //移除已经拆分完毕的列--任课教师
                dt.Columns.Remove(dt.Columns[3]);
                dt.Columns.Remove(dt.Columns[6]);
                return DataTableToSQLServer("TabAllCourses", 17) ? "导入成功" : "导入失败";
            }
            else
                return "选择的Excel文件中的内容与数据库要求不匹配。请确认！";
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
                // CalenderToSQLServer(identity);
                return DataTableToSQLServer(identity, 2) ? "导入成功" : "导入失败";
            }
            else
            {
                return "选择的Excel文件中的内容与数据与数据库中的要求不匹配，请确认！";
            }

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
                //  TeachersToSQLServer(identity);
                return DataTableToSQLServer(identity, 6) ? "导入成功" : "导入失败";
            }
            else
            {
                return "选择的Excel文件中的内容与数据与数据库中的要求不匹配，请确认！";
            }
        }

        /// <summary>
        /// 将dt导入数据库
        /// </summary>
        /// <param name="dt">要插入表的表名</param>
        /// <param name="columnCount">数据表中列数</param>
        /// <returns></returns>
        public static bool DataTableToSQLServer(string insertTableName, int columnCount)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SdbiAttentionSystemConnectionString"].ConnectionString;
            using (SqlConnection destinationConnection = new SqlConnection(connectionString))
            {
                destinationConnection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                {
                    try
                    {
                        bulkCopy.DestinationTableName = insertTableName;//要插入的表的表名
                        //bulkCopy.BulkCopyTimeout = 60;
                        //bulkCopy.BatchSize = 100;//每次传输的行数 
                        //bulkCopy.NotifyAfter = 100;//进度提示的行数 
                        //bulkCopy.ColumnMappings.Add("承担单位", "TercherDepartment");//映射字段名 DataTable列名 ,数据库 对应的列名  
                        //bulkCopy.ColumnMappings.Add("任课教师", "TeacherIDName");
                        //bulkCopy.ColumnMappings.Add("上课时间/地点", "LessonNameAddress");
                        //bulkCopy.ColumnMappings.Add("课程", "LessonMessage");
                        //bulkCopy.ColumnMappings.Add("所属部门", "LessonDepartment");
                        //bulkCopy.ColumnMappings.Add("学分", "Credit");
                        //bulkCopy.ColumnMappings.Add("总学时", "AllCredit");
                        //bulkCopy.ColumnMappings.Add("上课班级名称", "ClassName");
                        //bulkCopy.ColumnMappings.Add("院(系)/部", "ClassDepartment");
                        //bulkCopy.ColumnMappings.Add("学号", "StudentId");
                        //bulkCopy.ColumnMappings.Add("姓名", "StudentName");
                        //bulkCopy.ColumnMappings.Add("行政班级", "StudentClass");
                        //bulkCopy.ColumnMappings.Add("性别", "StudentSex");
                        //bulkCopy.ColumnMappings.Add("课程类别1", "ClassClassOne");
                        //bulkCopy.ColumnMappings.Add("课程类别2", "ClassClassTwo");

                        //bulkCopy.ColumnMappings.Add(0, 0);//映射字段名 DataTable列名 ,数据库 对应的列名，可以用数字代替
                        //bulkCopy.ColumnMappings.Add(1, 1);
                        for (int i = 0; i < columnCount; i++)
                        {
                            bulkCopy.ColumnMappings.Add(i, i);
                        }
                        bulkCopy.WriteToServer(ds.Tables["ExcelInfo"]);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 根据[]拆分教师Excel第二列教师ID和教师名，并添加到yuanbiao 拆分课程列
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static DataTable SplitTeacherIDAndTeacherName(DataRow dr)
        {
            //   ds.Tables["ExcelInfo"].Rows[i][1];
            string[] newStr = dr[3].ToString().Split(new char[] { '[',']'}, StringSplitOptions.RemoveEmptyEntries);
            string[] newStr2 = dr[7].ToString().Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
            dr.BeginEdit();
            for (int i = 0; i < newStr.Length; i++)
            {
                dr[i + 1] = newStr[i];
                dr[i + 5] = newStr2[i];
            }
            
            dr.EndEdit();
            return null;
        }

    }
}

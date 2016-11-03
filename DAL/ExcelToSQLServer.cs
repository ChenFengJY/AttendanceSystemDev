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
        /// 从本地读取Excel
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="strSQL"></param>
        private static void ExcelToDatabaseByDataReader(string fileName, string strSQL)
        {
            System.GC.Collect();
            string oleStr1 = @"Privider = Microsoft.Jet.OLEDB.4.0;Data Source = " + fileName + ";Extended Properties=Excel8.0";
            OleDbConnection oleConn = new OleDbConnection(oleStr1);
            oleConn.Open();

            OleDbCommand oleCmd = new OleDbCommand(strSQL, oleConn);
            OleDbDataReader oleDr = oleCmd.ExecuteReader();

            string sqlStr1 = ConfigurationManager.ConnectionStrings["SdbiAttentionSystemConnectionString"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(sqlStr1);
            sqlConn.Open();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;
            StringBuilder strconn = new StringBuilder();
            List<string> str = new List<string>();
            while (oleDr.Read())
            {
                str = SplitTeacherIDAndTeacherName(oleDr[1].ToString());
                strconn.Append("insert into TabAllCourses(TeacherDepartment,TeacherID,TeacherName,TimeAndArea,Course,t1,t2,t3,Class,StudentDepartment,StudentID,StudentName,t4,t5,t6,t7)values(");
                strconn.Append("'" + oleDr[0].ToString() + "','" + str[0] + "','" + str[1] + "'");
                for (int j = 2; j <= 14; j++)
                {
                    strconn.Append(",'" + oleDr[j].ToString() + "'");
                }
                strconn.Append(")");
                sqlCmd.CommandText = strconn.ToString();
                sqlCmd.ExecuteNonQuery();
                strconn.Remove(0, strconn.Length);
            }


            sqlConn.Close();
            oleDr.Close();
            oleConn.Close();
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
                return "文件导入成功";
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
                CalenderToSQLServer(identity);
                return "文件导入成功";
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
                return "文件导入成功";
            }
            else
            {
                return "选择的Excel文件中的内容与数据与数据库中的要求不匹配，请确认！";
            }
        }
        /// <summary>
        /// 将课程表Dataset上传到Sqlserver
        /// </summary>
        /// <param name="identity">数据库表名</param>
        public static void CoursesTOSQLServer(string identity)
        {
            string str1 = ConfigurationManager.ConnectionStrings["SdbiAttentionSystemConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(str1);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            StringBuilder strconn = new StringBuilder();
            List<string> str = new List<string>();

            for (int i = 0; i < ds.Tables["ExcelInfo"].Rows.Count; i++)
            {
                str = SplitTeacherIDAndTeacherName(ds.Tables["ExcelInfo"].Rows[i].ItemArray[1].ToString());
                strconn.Append("insert into TabAllCourses(TeacherDepartment,TeacherID,TeacherName,TimeAndArea,Course,t1,t2,t3,Class,StudentDepartment,StudentID,StudentName,t4,t5,t6,t7)values(");
                strconn.Append("'" + ds.Tables["ExcelInfo"].Rows[i].ItemArray[0].ToString() + "','" + str[0] + "','" + str[1] + "'");
                for (int j = 2; j <= 14; j++)
                {
                    strconn.Append(",'" + ds.Tables["ExcelInfo"].Rows[i].ItemArray[j].ToString() + "'");
                }
                strconn.Append(")");
                string str2 = strconn.ToString();
                cmd.CommandText = str2;
                str2 = string.Empty;
                cmd.ExecuteNonQuery();
                strconn.Remove(0, strconn.Length);
                System.GC.Collect();
            }
            conn.Close();
            conn.Dispose();
        }
        /// <summary>
        /// 根据[]拆分教师Excel第二列教师ID和教师名
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static List<string> SplitTeacherIDAndTeacherName(string str)
        {
            List<string> strSplit = new List<string>();
            string[] newStr = str.Split(new char[]
                { '[',']'}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < newStr.Length; i++)
            {
                strSplit.Add(newStr[i]);
            }
            return strSplit;
        }
        public static void CalenderToSQLServer(string identity)
        {
            string str1 = ConfigurationManager.ConnectionStrings["SdbiAttentionSystemConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(str1);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            StringBuilder strconn = new StringBuilder();
            for (int i = 0; i < ds.Tables["ExcelInfo"].Rows.Count; i++)
            {
                strconn.Append("insert into" + identity + "(WeekNumber,StartWeek,EndWeek)values(");
                for (int j = 0; j <= 1; j++)
                {
                    strconn.Append("'" + ds.Tables["ExcelInfo"].Rows[i].ItemArray[j].ToString() + "',");
                }
                strconn.Append("'" + ds.Tables["ExcelInfo"].Rows[i].ItemArray[2] + "')");
                string str2 = strconn.ToString();
                cmd.CommandText = str2;
                cmd.ExecuteNonQuery();
                strconn.Remove(0, strconn.Length);
            }
            conn.Close();
            conn.Dispose();
        }
        public static void TeachersToSQLServer(string identity)
        {
            string str1 = ConfigurationManager.ConnectionStrings["SdbiAttentionSystemConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(str1);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            StringBuilder strconn = new StringBuilder();
            for (int i = 0; i < ds.Tables["ExcelInfo"].Rows.Count; i++)
            {
                strconn.Append("insert into " + identity + "(Department,UserID,UserPWD,UserName,Sex,Role)values(");
                for (int j = 0; j <= 4; j++)
                {
                    strconn.Append("'" + ds.Tables["ExcelInfo"].Rows[i].ItemArray[j].ToString() + "',");
                }
                strconn.Append("'" + ds.Tables["ExcelInfo"].Rows[i].ItemArray[5] + "')");
                string str2 = strconn.ToString();
                cmd.CommandText = str2;
                cmd.ExecuteNonQuery();
                strconn.Remove(0, strconn.Length);
            }
            conn.Close();
            conn.Dispose();
        }
        /// <summary>
        /// 将dt导入数据库
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToSQLServer(DataTable dt)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SdbiAttentionSystemConnectionString"].ConnectionString;
            using (SqlConnection destinationConnection = new SqlConnection(connectionString))
            {
                destinationConnection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                {
                    try
                    {
                        bulkCopy.DestinationTableName = "AllTable";//要插入的表的表名
                        bulkCopy.BatchSize = 100;//每次传输的行数 
                        bulkCopy.NotifyAfter = 100;//进度提示的行数 
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

                        bulkCopy.ColumnMappings.Add(0, 0);//映射字段名 DataTable列名 ,数据库 对应的列名  
                        bulkCopy.ColumnMappings.Add(1, 1);
                        bulkCopy.ColumnMappings.Add(2, 2);
                        bulkCopy.ColumnMappings.Add(3, 3);
                        bulkCopy.ColumnMappings.Add(4, 4);
                        bulkCopy.ColumnMappings.Add(5, 5);
                        bulkCopy.ColumnMappings.Add(6, 6);
                        bulkCopy.ColumnMappings.Add(7, 7);
                        bulkCopy.ColumnMappings.Add(8, 8);
                        bulkCopy.ColumnMappings.Add(9, 9);
                        bulkCopy.ColumnMappings.Add(10, 10);
                        bulkCopy.ColumnMappings.Add(11, 11);
                        bulkCopy.ColumnMappings.Add(12, 12);
                        bulkCopy.ColumnMappings.Add(13, 13);
                        bulkCopy.ColumnMappings.Add(14, 14);
                        bulkCopy.WriteToServer(dt);
                        return true.ToString();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    finally
                    {

                    }
                }
            }
        }
    }
}

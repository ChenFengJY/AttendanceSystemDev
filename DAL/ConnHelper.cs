using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class ConnHelper
    {

        /// <summary>
        /// 查询指定的表中的指定字段
        /// </summary>
        /// <param name="strSQL">查询的SQL语句</param>
        /// <param name="str1">字段名</param>
        /// <returns>返回一个list--string</returns>
        public static List<string> GetDistinceColoum(string strSQL, string str1)
        {
            DataTable dt = GetDataTable(strSQL);
            List<string> strList = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                string str = dr[str1].ToString();
                strList.Add(str);
            }
            return strList;
        }

        /// <summary>
        /// 根据sql语句查询表数据
        /// </summary>
        /// <param name="strSQL">sql语句</param>
        /// <returns>返回一个datatable的数据表</returns>
        public static DataTable GetDistinceColoum(string strSQL)
        {
            DataTable dt = GetDataTable(strSQL);
            return dt;
        }

        /// <summary>
        /// 获取dataset集合
        /// 读取配置文件连接数据库
        /// </summary>
        /// <param name="strSQL">SQL查询语句</param>
        /// <returns>DT数据集</returns>
        public static DataSet GetDataSet(string strSQL)
        {
            string connString = ConfigurationManager.ConnectionStrings["SdbiAttentionSystemConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        /// <summary>
        /// 查询结果计数
        /// 执行查询SQL命令，并返回第一行第一列，忽略其他行和列
        /// 用于判断有无符合条件的条目
        /// </summary>
        /// <param name="strSQL">SQL查询语句</param>
        /// <returns>如果有---第一行第一列，如果没有---返回“0”</returns>
        public static int GetRecordCount(string strSQL)
        {
            string connString = ConfigurationManager.ConnectionStrings["SdbiAttentionSystemConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(strSQL, conn);
            string count = cmd.ExecuteScalar().ToString().Trim();
            if (count == "")
            {
                count = "0";
            }
            conn.Close();
            return Convert.ToInt32(count);
        }

        /// <summary>
        /// 执行增删改SQL命令,返回是否成功
        /// </summary>
        /// <param name="strSQL">SQL命令</param>
        /// <returns>是否成功(异常)</returns>
        public static bool ExecuteNoneQueryOperation(string strSQL)
        {
            string connString = ConfigurationManager.ConnectionStrings["SdbiAttentionSystemConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(strSQL, conn);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 获取一个DT
        /// </summary>
        /// <param name="strSQL">查询SQL的语句</param>
        /// <returns>返回一个DT</returns>
        public static DataTable GetDataTable(string strSQL)
        {
            DataSet ds = GetDataSet(strSQL);
            //字符串比较不区分大小写
            ds.CaseSensitive = false;
            return ds.Tables[0];
        }
        //public static int GetRecordCount(string strSql)
        //{
        //    string ConnectionString = ConfigurationManager.ConnectionStrings[""].ConnectionString;
        //    SqlConnection conn = new SqlConnection(ConnectionString);
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    string count = cmd.ExecuteScalar().ToString().Trim();
        //    if(count==""){
        //        count = "0";
        //        conn.Close();
        //        return Convert.ToInt32(count);

        //    }
        //}
    }
}
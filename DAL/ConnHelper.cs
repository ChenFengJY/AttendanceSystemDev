using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ConnHelper
    {
        public static DataTable getDT(string strSQL)
        {
            string connString = ConfigurationManager.ConnectionStrings["SdbiAttentionSystemConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            DataTable dt = new DataTable();
            da.Fill(dt); 
            conn.Close();
            return dt;
        }

    
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

        public static DataSet GetDataSet(string strSQL)
        {
            return null;
        }

        public static DataTable GetDataTable(string strSQL)
        {
            return null;
        }
    }
}

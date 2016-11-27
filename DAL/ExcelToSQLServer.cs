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

        /// <summary>
        /// 将dt导入数据库
        /// </summary>
        /// <param name="dt">要插入表的表名</param>
        /// <param name="insertTableName">数据库中的表名</param>
        /// <param name="columnCount">数据表中列数</param>
        /// <returns></returns>
        public static string DataTableToSQLServer(DataTable dt,string insertTableName, int columnCount)
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

                        for (int i = 0; i < columnCount; i++)
                        {
                            bulkCopy.ColumnMappings.Add(i, i);
                        }
                        bulkCopy.WriteToServer(dt);
                        return "导入成功";
                    }
                    catch (Exception ex)
                    {
                        return ex.ToString();
                    }
                }
            }
        }

       

    }
}

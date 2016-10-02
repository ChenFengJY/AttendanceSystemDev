using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    /// <summary>
    /// 中转层，用于执行DAL层的操作的数据库代码
    /// </summary>
    public class AddSQLStringToDAL
    {
        /// <summary>
        /// 执行DAL层查询语句，并返回dataTable
        /// </summary>
        /// <param name="strSQl">要执行的Select语句</param>
        /// <returns>查询回来的数据</returns>
        public static DataTable GetDtBySQL(string strSQl)
        {
            return ConnHelper.GetDataTable(strSQl);
        }
    }
}

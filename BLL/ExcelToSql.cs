using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ExcelToSql
    {
        public static string SetExcel(DataTable dt)
        {
            return ExcelToSQLServer.DataTableToSQLServer(dt);
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class DataAnalysis
    {
        public static DataTable CreateDateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Week");
            dt.Columns["Week"].SetOrdinal(0);
            dt.Columns.Add("Department");
            dt.Columns["Department"].SetOrdinal(1);
            dt.Columns.Add("Late");
            dt.Columns["Late"].SetOrdinal(2);
            dt.Columns.Add("Early");
            dt.Columns["Early"].SetOrdinal(3);
            dt.Columns.Add("Attendance");
            dt.Columns["Attendance"].SetOrdinal(4);
            dt.Columns.Add("Leave");
            dt.Columns["Leave"].SetOrdinal(5);
            return dt;
        }

        public static void CreateDataRow(DataTable dt,int i,string Department,int Late,int Early,int Attendance,int Leave)
        {

        }
    }
}

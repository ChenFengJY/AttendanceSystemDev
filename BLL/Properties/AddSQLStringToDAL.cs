using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using System.Web.UI.WebControls;

namespace BLL
{
    /// <summary>
    /// 中转层，用于执行DAL层的操作的数据库代码
    /// </summary>
    public class AddSQLStringToDAL
    {
        //public static bool UpdataTable(string TableName,string UserPWD,string UserID)
        //{

        //}
        /// <summary>
        /// 执行DAL层查询语句，并返回dataTable
        /// </summary>
        /// <param name="strSQl">要执行的Select语句</param>
        /// <returns>查询回来的数据</returns>
        public static DataTable GetDtBySQL(string strSQl)
        {
            return ConnHelper.GetDataTable(strSQl);
        }
        
        public static void FillTreeVMenu(TreeNodeEventArgs e, string menuName)
        {
            if (e.Node.ChildNodes.Count == 0)
            {
                switch (e.Node.Depth)
                {
                    case 0:
                        FillParentNode(e.Node,menuName);
                        break;
                    case 1:
                        FillChildNode(e.Node, menuName);
                        break;
                }
            }
        }

        public static void FillChildNode(TreeNode node, string menuName)
        {

            string sqlQuery = "Select * From " + menuName + "" +
            " Where Parent_Node = '" + node.Text + "'";
            DataTable dt = AddSQLStringToDAL.GetDtBySQL(sqlQuery);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    TreeNode NewNode = new
                        TreeNode(row["Child_Node"].ToString(), "", "", row["Navigate_Url"].ToString(), "");
                    NewNode.PopulateOnDemand = false;
                    node.ChildNodes.Add(NewNode);
                }
            }
        }

        private static void FillParentNode(TreeNode node, string menuName)
        {
            string sqlQuery = "Select DISTINCT Parent_Node From " + menuName + "";
            DataTable dt = AddSQLStringToDAL.GetDtBySQL(sqlQuery);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    TreeNode NewNode = new
                        TreeNode(row["Parent_Node"].ToString(), "ddad");
                    NewNode.PopulateOnDemand = true;
                    NewNode.SelectAction = TreeNodeSelectAction.Expand;
                    node.ChildNodes.Add(NewNode);
                }
            }
        }

        public static DataTable SetData(string strSql)
        {

            return ConnHelper.GetDistinceColoum(strSql);
        }
        public static DataTable GetDatatableBySQL(string str1,string str2,string str3)
        {
            string strTemp = BuidSQLSelectString(str1, str2, str3);
            return ConnHelper.GetDataTable(strTemp);
        }
        public static DataTable GetDatatableBySQL(string TableName,string str1,string str1Limit,string str2,string str2Limt)
        {
            string strSQL = BuidSQLSelectString(TableName, str1, str1Limit, str2, str2Limt);
            return ConnHelper.GetDataTable(strSQL);
                }
        public static DataTable GetDatatableBySQL(string TableName, string str1, string str1Limit, string str2, string str2Limt,string str3,string str3Limt)
        {
            string strSQL = BuidSQLSelectString(TableName, str1, str1Limit, str2, str2Limt,str3,str3Limt);
            return ConnHelper.GetDataTable(strSQL);
        }
        public static DataTable GetDatatableBySQL(string TableName, string str1, string str1Limit, string str2, string str2Limt, string str3, string str3Limt,string str4,string str4Limt,string str5,string str5Limt)
        {
            string strSQL = BuidSQLSelectString(TableName, str1, str1Limit, str2, str2Limt, str3, str3Limt,str4,str4Limt,str5,str5Limt);
            return ConnHelper.GetDataTable(strSQL);
        }
        private static string BuidSQLSelectString(string strTableName)
        {
            return "select * from" + strTableName;
        }
        private static string BuidSQLSelectString(string strTableName,string strddl,string strtxt)
        {
            return "select * from" + strTableName+"where"+strddl+"="+strtxt+"";
        }
        private static string BuidSQLSelectString(string TableName,string str1,string str1Limt,string str2,string str2Limt )
        {
            return "select * from" + TableName + "where" + str1 + "=" + str1Limt + "and" + str2 + "=" + str2Limt + "order by 1";
        }

        private static string BuidSQLSelectString(string ableName, string str1, string str1Limit, string str2, string str2Limt, string str3, string str3Limt, string str4, string str4Limt, string str5, string str5Limt)
        {
            throw new NotImplementedException();
        }

        private static string BuidSQLSelectString(string tableName, string str1, string str1Limit, string str2, string str2Limt, string str3, string str3Limt)
        {
            return "select * from" + tableName + "where" + str1 + "=" + str1Limit + "and" + str2 + "=" + "and" + str3 + "=" + str3Limt + "order by 1";
            throw new NotImplementedException();
        }
        public static List<string> GetDistinctString(string strTable,string str1)
        {
            string strSQL = BuildSQLDistinctString(strTable, str1);
            return ConnHelper.GetDistinceColoum(strSQL, str1);

        }
        private static string BuildSQLDistinctString(string strTableName,string str1)
        {
            return "select distinct"+str1+"from"+strTableName;
        }
        
    }
}
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
        public static bool UpdataTabTeachers(string TableName, string UserPWD, string UserID,string UserRole)
        {
            return true;

        }

        public static List<string> GetDistinctString(string v1, string v2, string v3, string v4)
        {
            throw new NotImplementedException();
        }

        //public static DataTable GetDatatableBySQL(string v)
        //{
        //    throw new NotImplementedException();
        //}

        //public static DataTable GetDatatableBySQL(string v)
        //{
        //    throw new NotImplementedException();
        //}

        //private static string BuildSQLUpdateString(string strTableName,string UserPWD,string UserID)
        //{
        //    //return "update" + strTableName + "setUserPWD" = "" + UserPWD + '"where UserID="' + UserID + "'";
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

        public static DataTable GetDatatableBySQL(string v1, object p, string v2)
        {
            throw new NotImplementedException();
        }

        public static void FillTreeVMenu(TreeNodeEventArgs e, string menuName)
        {
            if (e.Node.ChildNodes.Count == 0)
            {
                switch (e.Node.Depth)
                {
                    case 0:
                        FillParentNode(e.Node, menuName);
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

        public static bool DeleteTabTeachers(string TabTeachers, string UserID, string v3)
        {
            return false;
        }

        public static bool InsertTabTeachers(string teacherType, object replace, object sensitive, object p1, object p2, string v1, object p3, string v2, string teacherRole)
        {
            throw new NotImplementedException();
        }

        public static bool UpdataTabTeachers(string v1, string v2,string Course, string Count, string strUserRole, string TabStudentAttendance, string strUserID,string UserName, string CurrentCourse, string CurrentWeek,string Week, string Time,string cell)
        {
            throw new NotImplementedException();
        }

        public static bool InsertTabTeachers(string v1, string v2, string Course,string Count, string teacherType, object replaceSensitive, string strUserRole, string TabStudentAttendance, string strUserID, string UserName, string CurrentCourse, string CurrentWeek, string Week, string Time, string cell)
        {
            throw new NotImplementedException();
        }

        public static void InsertTabTeachers()
        {
            throw new NotImplementedException();
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
        /// <summary>
        /// 根据一个条件查询指定的表
        /// </summary>
        /// <param name="str1">查询的表名</param>
        /// <param name="str2">列名</param>
        /// <param name="str3">条件--值</param>
        /// <returns></returns>
        public static DataTable GetDatatableBySQL(string str1)
        {
            string strTemp = BuidSQLSelectString(str1);
            return ConnHelper.GetDataTable(strTemp);
        }
        /// <summary>
        /// 根据两个条件查询指定的表
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="str1">数据库列名1</param>
        /// <param name="str1Limit">满足的条件1</param>
        /// <param name="str2">数据库列名2</param>
        /// <param name="str2Limt"></param>
        /// <returns></returns>
        public static DataTable GetDatatableBySQL(string TableName, string str1, string str1Limit, string str2, string str2Limt)
        {
            string strSQL = BuidSQLSelectString(TableName, str1, str1Limit, str2, str2Limt);
            return ConnHelper.GetDataTable(strSQL);
        }

        public static bool DeleteTabTeachers(string tableName)
        {
            string strSql = "DELETE FROM " + tableName + " WHERE 1=1";
            return ConnHelper.ExecuteNoneQueryOperation(strSql);
        }

        /// <summary>
        /// 执行插入命令
        /// </summary>
        /// <param name="strSql">insert into 语句</param>
        /// <returns></returns>
        public static bool InsertData(string strSql)
        {
            return ConnHelper.ExecuteNoneQueryOperation(strSql);
        }
        /// <summary>
        /// 根据三个条件查询指定的表
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="str1"></param>
        /// <param name="str1Limit"></param>
        /// <param name="str2"></param>
        /// <param name="str2Limt"></param>
        /// <param name="str3"></param>
        /// <param name="str3Limt"></param>
        /// <returns></returns>
        public static DataTable GetDatatableBySQL(string TableName, string str1, string str1Limit, string str2, string str2Limt, string str3, string str3Limt)
        {
            string strSQL = BuidSQLSelectString(TableName, str1, str1Limit, str2, str2Limt, str3, str3Limt);
            return ConnHelper.GetDataTable(strSQL);
        }
        public static DataTable GetDatatableBySQL(string TableName, string str1, string str1Limit, string str2, string str2Limt, string str3, string str3Limt, string str4, string str4Limt, string str5, string str5Limt)
        {
            string strSQL = BuidSQLSelectString(TableName, str1, str1Limit, str2, str2Limt, str3, str3Limt, str4, str4Limt, str5, str5Limt);
            return ConnHelper.GetDataTable(strSQL);
        }
        private static string BuidSQLSelectString(string strTableName)
        {
            return "select * from  " + strTableName+"";
        }
        private static string BuidSQLSelectString(string strTableName, string strddl, string strtxt)
        {
            return "select * from " + strTableName + "where" + strddl + "=" + strtxt + "";
        }
        private static string BuidSQLSelectString(string TableName, string str1, string str1Limt, string str2, string str2Limt)
        {
            return "select * from" + TableName + "where" + str1 + "=" + str1Limt + "and" + str2 + "=" + str2Limt + "order by 1";
        }

        private static string BuidSQLSelectString(string ableName, string str1, string str1Limit, string str2, string str2Limt, string str3, string str3Limt, string str4, string str4Limt, string str5, string str5Limt)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 构建三个查询条件的SQL语句
        /// </summary>
        /// <param name="tableName"></param>表名
        /// <param name="str1">str=str1Limit</param>
        /// <param name="str1Limit"> str=str1Limit</param>
        /// <param name="str2"></param>
        /// <param name="str2Limt"></param>
        /// <param name="str3"></param>
        /// <param name="str3Limt"></param>
        /// <returns>返回构建的字符串</returns>
        private static string BuidSQLSelectString(string tableName, string str1, string str1Limit, string str2, string str2Limt, string str3, string str3Limt)
        {
            return "select * from" + tableName + "where" + str1 + "=" + str1Limit + "and" + str2 + "=" + "and" + str3 + "=" + str3Limt + "order by 1";
            throw new NotImplementedException();
        }

        public static bool InsertTabTeachers(string v1, string v2, string v3, string v4, string v5, string v6, string v7, string v8, string v9, string v10, string v11, string v12, string v13)
        {
            throw new NotImplementedException();
        }

        public static List<string> GetDistinctString(string strTable, string str1)
        {
            string strSQL = BuildSQLDistinctString(strTable, str1);
            return ConnHelper.GetDistinceColoum(strSQL, str1);

        }
        private static string BuildSQLDistinctString(string strTableName, string str1)
        {
            return "select distinct" + str1 + "from" + strTableName;
        }

        public static bool UpdataTabTeachers(string v1, string v2, string v3, string v4, string v5, string v6, string v7, string v8, string v9, string v10, string v11, string v12, string v13, string v14, string v15)
        {
            throw new NotImplementedException();
        }
    }
}
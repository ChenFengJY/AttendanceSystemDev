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
        /// <summary>
        /// 执行DAL层查询语句，并返回dataTable
        /// </summary>
        /// <param name="strSQl">要执行的Select语句</param>
        /// <returns>查询回来的数据</returns>
        public static DataTable GetDtBySQL(string strSQl)
        {
            return ConnHelper.GetDataTable(strSQl);
        }

        public static void FillTreeVMenu(TreeNodeEventArgs e)
        {
            if (e.Node.ChildNodes.Count == 0)
            {
                switch (e.Node.Depth)
                {
                    case 0:
                        FillParentNode(e.Node);
                        break;
                    case 1:
                        FillChildNode(e.Node);
                        break;
                }
            }
        }

        public static void FillChildNode(TreeNode node)
        {

            string sqlQuery = "Select * From Admin_Menu " +
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

        private static void FillParentNode(TreeNode node)
        {
            string sqlQuery = "Select DISTINCT Parent_Node From Admin_Menu";
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
    }
}

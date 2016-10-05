using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void TreeView1_TreeNodePopulate1(object sender, TreeNodeEventArgs e)
    {
        AddSQLStringToDAL.FillTreeVMenu(e);
    }

    private void FillChildNode(TreeNode node)
    {
        //SqlCommand sqlQuery = new SqlCommand();
        //sqlQuery.CommandText

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

    private void FillParentNode(TreeNode node)
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

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {

    }
}
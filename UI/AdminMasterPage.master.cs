using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void TreeView1_TreeNodePopulate1(object sender, TreeNodeEventArgs e)
    {
        if (e.Node.ChildNodes.Count == 0)
        {
            switch (e.Node.Depth)
            {
                case 0:
                    PopulateCategories(e.Node);
                    break;
                case 1:
                    PopulateProducts(e.Node);
                    break;
            }
        }
    }

    private void PopulateProducts(TreeNode node)
    {
        //SqlCommand sqlQuery = new SqlCommand();
        //sqlQuery.CommandText

        string sqlQuery = "Select * From Admin_Menu " +
        " Where Parent_Node = '" + node.Text + "'";

        //sqlQuery.Parameters.Add("@categoryid", SqlDbType.Int).Value =
        //    node.Value;
        DataSet ResultSet = RunQuery(sqlQuery);
        if (ResultSet.Tables.Count > 0)
        {
            foreach (DataRow row in ResultSet.Tables[0].Rows)
            {
                TreeNode NewNode = new
                    TreeNode(row["Child_Node"].ToString(),"","",row["Navigate_Url"].ToString(),"");
                NewNode.PopulateOnDemand = false;
                node.ChildNodes.Add(NewNode);
            }
        }
    }

    private void PopulateCategories(TreeNode node)
    {
        // SqlCommand sqlQuery = new SqlCommand(
        //"Select DISTINCT Parent From AdminMenu");
        string sqlQuery = "Select DISTINCT Parent_Node From Admin_Menu";
        DataSet resultSet;
        resultSet = RunQuery(sqlQuery);
        if (resultSet.Tables.Count > 0)
        {
            foreach (DataRow row in resultSet.Tables[0].Rows)
            {
                TreeNode NewNode = new
                    TreeNode(row["Parent_Node"].ToString(), "ddad");
                NewNode.PopulateOnDemand = true;
                NewNode.SelectAction = TreeNodeSelectAction.Expand;
                node.ChildNodes.Add(NewNode);
            }
        }
    }

    private DataSet RunQuery(string sqlQuery)
    {

        //string strConn = "data source=.;initial catalog=test;uid=sa;password=awsd123..";
        string strConn = "Data Source=.;Initial Catalog=SdbiAttentionSystem;Integrated Security=True";
        SqlConnection conn = new SqlConnection(strConn);

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conn);
        da.Fill(ds);
        conn.Close();
        return ds;
    }



}
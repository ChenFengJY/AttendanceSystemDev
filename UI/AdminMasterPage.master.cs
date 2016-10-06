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
        AddSQLStringToDAL.FillTreeVMenu(e, "Admin_Menu");
    }

}
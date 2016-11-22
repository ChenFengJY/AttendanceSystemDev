using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using BLL;
public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "当前在线" + Application["online"].ToString() + "人";
        Label2.Text = Session["UserName"].ToString()
            + "你好,你的权限为" + Session["Role"].ToString();
        Label5.Text = "当前周次为：" + Session["CurrentWeek"].ToString() ;

    }

    protected void TreeView1_TreeNodePopulate1(object sender, TreeNodeEventArgs e)
    {
        AddSQLStringToDAL.FillTreeVMenu(e, "Admin_Menu");
    }


    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
   
}
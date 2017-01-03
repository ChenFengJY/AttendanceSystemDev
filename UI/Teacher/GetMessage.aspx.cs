using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

public partial class Teacher_GetMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Repeater1.DataSourceID = "SqlDataSource1";
        }

    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Button label = (Button)e.Item.FindControl("tabLab");
            if (label.Text.Equals("未读"))
            {
                string time = ((Label)e.Item.FindControl("timeLab")).Text;
                string UID = Session["UserID"].ToString();
                string sql = "UPDATE [TabMessage] SET[MessageStatus] = '已读' WHERE[MessageTime] = '" + time + "' and [UserID] = '" + UID + "'";
                AddSQLStringToDAL.InsertData(sql);
                label.Text = "已读";
            }
            else
            {
                label.Enabled = false;
            }
        }
    }
}
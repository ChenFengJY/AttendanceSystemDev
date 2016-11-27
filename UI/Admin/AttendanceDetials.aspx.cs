using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AttendanceDetials : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Session["UserID"].ToString() +"  "+ Session["CourseWeek"].ToString() +"  "+ Session["CourseTime"].ToString(); 
    }


    protected void gvAttendanceDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //如果是绑定数据行
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //鼠标经过时，行背景色变
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#E6F5FA'");
            //鼠标移出时，行背景色变
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
    }
}
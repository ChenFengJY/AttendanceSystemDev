using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;

public partial class Admin_AdminSubmitAttendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserName"].ToString() == "")
            {
                //Response.Redirect("..\\Login.aspx");
            }
            else {
            }

            //string sql = "select * from [TabTeacherCourseWeek] where [TeacherID] = " + Session["UserID"] + " and CourseAllWeek = 12";
            //调试用↓
            string sql = "select * from [TabTeacherCourseWeek] where [TeacherID] = 2003013609 and CourseAllWeek = 12";
            this.thisRepeater.DataSource = DAL.ConnHelper.GetDataSet(sql).Tables[0];
            thisRepeater.DataBind();
            this.lastRepeater.DataSource = DAL.ConnHelper.GetDataSet(sql).Tables[0];
            lastRepeater.DataBind();

        }

    }


    protected void thisButton1_Click(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    protected void thisButton2_Click(object sender, EventArgs e)
    {

    }

    protected void thisRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label week = e.Item.FindControl("thisWeekLabel") as Label;
        Session["CourseWeek"] = week.Text.Trim();

        Label time = e.Item.FindControl("thisTimeLabel") as Label;
        Session["CourseTime"] = time.Text.Trim();

        Response.Redirect("AttendanceDetials.aspx");
    }
}
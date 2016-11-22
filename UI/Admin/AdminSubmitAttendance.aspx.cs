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
                Response.Redirect("~\\Default.aspx");
            }
            else {
            }
            string sql = "select * from [TabTeacherCourseWeek] where [TeacherID]= " + Session["UserID"] + " and CourseAllWeek = 12";

            this.rptCourse.DataSource = DAL.ConnHelper.GetDataSet(sql).Tables[0];
            rptCourse.DataBind();
        }

    }



    protected void BulletedList1_Click(object sender, BulletedListEventArgs e)
    {

    }

    protected void rptCourse_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}
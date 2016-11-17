using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminSubmitAttendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            string sql = "select * from [TabTeacherCourseWeek] where [TeacherID]= " + Session["UserID"] + " and CourseAllWeek = 12";
            this.Repeater1.DataSource = DAL.ConnHelper.GetDataSet(sql).Tables[0];
            Repeater1.DataBind();
        }

    }



    protected void BulletedList1_Click(object sender, BulletedListEventArgs e)
    {

    }
}
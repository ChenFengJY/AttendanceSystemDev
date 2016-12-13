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
        //IsPostBack 在第一次打开时是false
        if (!IsPostBack)
        {
            //第一次打开时执行
            //string sql = "select * from [TabTeacherCourseWeek] where [TeacherID] = " + Session["UserID"] + " and CourseAllWeek = "+Session["CourseWeek"] +" ";
            //调试用↓
            string sql = "select * from [TabTeacherCourseWeek] where [TeacherID] = 2003013609 and CourseAllWeek = " + Session["CurrentWeek"] + " ";
            DataTable dt = AddSQLStringToDAL.GetDtBySQL(sql);
            this.thisRepeater.DataSource = dt;
            thisRepeater.DataBind();
            string sql2 = "select * from [TabTeacherCourseWeek] where [TeacherID] = 2003013609 and CourseAllWeek = " + (Convert.ToInt32(Session["CurrentWeek"])-1) + " ";
            DataTable dt2 = AddSQLStringToDAL.GetDtBySQL(sql2);
            this.lastRepeater.DataSource = dt2;
            lastRepeater.DataBind();

        }
        else
        {
            //Response.Redirect("..\\Login.aspx");
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

        Label courseName = e.Item.FindControl("thisNameLabel") as Label;
        Session["CourseName"] = courseName.Text.Trim().ToString();
        
        if (CompareWeek())
        {
            if ((e.Item.FindControl("thisAttendanceLabel") as Label).Text.Trim() == "未考勤")
            {
                Response.Redirect("AttendanceDetials.aspx");
            }
            else
            {
                Page.RegisterStartupScript("ServiceManHistoryButtonClick", "<script>alert('您已经录入本次考勤记录,无法再次考勤！');</script>");
                //Response.Write("<script>alert('您已经录入本次考勤记录,无法再次考勤！')</script>");
            }
        }
        else
        {
            Page.RegisterStartupScript("ServiceManHistoryButtonClick", "<script>alert('本门课程尚未结束，请于课程结束后录入!');</script>");
            //Response.Write("<script>alert('本门课程尚未结束，请于课程结束后录入！')</script>");
        }
       
    }
    /// <summary>
    /// 当前时间与课程时间对比
    /// </summary>
    /// <returns></returns>
    private bool CompareWeek()
    {
        int Week = 0; //课程所在周
        int CurrentWeek = 0; //系统时间当前是周几
        switch (DateTime.Now.DayOfWeek.ToString())
        {
            case "Monday":
                CurrentWeek = 1;
                break;
            case "Tuesday":
                CurrentWeek = 2;
                break;
            case "Wednesday":
                CurrentWeek = 3;
                break;
            case "Thursday":
                CurrentWeek = 4;
                break;
            case "Friday":
                CurrentWeek = 5;
                break;
            case "Saturday":
                CurrentWeek = 6;
                break;
            case "Sunday":
                CurrentWeek = 7;
                break;
            default:
                CurrentWeek = 0;
                break;

        }
        switch (Session["CourseWeek"].ToString().Trim())
        {
            case "星期一":
                Week = 1;
                break;
            case "星期二":
                Week = 2;
                break;
            case "星期三":
                Week = 3;
                break;
            case "星期四":
                Week = 4;
                break;
            case "星期五":
                Week = 5;
                break;
            case "星期六":
                Week = 6;
                break;
            case "星期日":
                Week = 7;
                break;
            default:
                Week = 0;
                break;
        }
        if (CurrentWeek > Week)
        {
            return true;
        }
        else if (CurrentWeek == Week)
        {
            int time = 0;
            switch (Session["Time"].ToString())
            {
                case "1-2节":
                    time = 10;
                    break;
                case "2-4节":
                    time = 12;
                    break;
                case "5-6节":
                    time = 16;
                    break;
                case "7-8节":
                    time = 18;
                    break;
                case "9-10节":
                    time = 20;
                    break;
                default:
                    time = 0;
                    break;
            }
            if (DateTime.Now.Hour >= time)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
            
        }
    }


    protected void lastRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label week = e.Item.FindControl("lastWeekLabel") as Label;
        Session["CourseWeek"] = week.Text.Trim();

        Label time = e.Item.FindControl("lastTimeLabel") as Label;
        Session["CourseTime"] = time.Text.Trim();

        Label courseName = e.Item.FindControl("lastNameLabel") as Label;
        Session["CourseName"] = courseName.Text.Trim().ToString();

        if ((e.Item.FindControl("lastAttendanceLabel") as Label).Text.Trim() == "未考勤")
        {
            Response.Redirect("AttendanceDetials.aspx");
        }
        else
        {
            Page.RegisterStartupScript("ServiceManHistoryButtonClick", "<script>alert('您已经录入本次考勤记录,无法再次考勤！');</script>");
            //Response.Write("<script>alert('您已经录入本次考勤记录,无法再次考勤！')</script>");
        }
    }
}
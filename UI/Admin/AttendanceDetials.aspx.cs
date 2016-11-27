using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Drawing;
using System.Text;
using BLL;

public partial class Admin_AttendanceDetials : System.Web.UI.Page
{
   

    protected void Page_Load(object sender, EventArgs e)
    {
        lblAttendanceMessage.Text = Session["UserID"].ToString() + "  " + Session["CourseWeek"].ToString() + "  " + Session["CourseTime"].ToString();
        if (!IsPostBack)
        {
            if (Session["CurrentCourse"].ToString() != "")
            {
                InitialOperation();
                btnClose.Visible = true;
            }
            else
            {
                Response.Redirect("~//Default.aspx");
            }
            if (CheckIsRecords())
            {
                SetControlsVisibleFalse();
                lblResultMessage.Text = "您已经录入本次考勤记录！";
                btnClose.Visible = true;

            }
            else
            {
                string strCourse = Session["CurrentCourse"].ToString();
                lblMessage.Text = Session["Week"].ToString() + Session["Time"].ToString()
                    + "|" + strCourse.Substring(8, strCourse.Length - 11) + "|" + this.gvAttendanceDetails.Rows.Count.ToString() + "人";
                c = this.gvAttendanceDetails.BackColor;

            }
        }

        else
        {
            SetControlsVisibleFalse();
            lblResultMessage.Text = "本门课程尚未结束，请于课程结束后录入！";
            btnClose.Visible = true;
        }
    }
    private bool CompareWeek()
    {
        int Week = 0;
        int CurrentWeek = 0;
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
        switch (Session["Week"].ToString())
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
            int tt = 0;
            switch (Session["Time"].ToString())
            {
                case "1-2节":
                    tt = 10;
                    break;
                case "2-4节":
                    tt = 12;
                    break;
                case "5-6节":
                    tt = 16;
                    break;
                case "7-8节":
                    tt = 18;
                    break;
                case "9-10节":
                    tt = 20;
                    break;
                default:
                    tt = 0;
                    break;
            }
            if (DateTime.Now.Hour >= tt)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }

 
    private bool CheckIsRecords()
    {
        DataTable dt = AddSQLStringToDAL.GetDatatableBySQL("TabTeacherAttendance", "TeacherID", Session["UserID"].ToString(),
            "CurrentWeek", Session["CurrentWeek"].ToString(), "Course", Session["CurrentCourse"].ToString(), "Week", Session["Week"].ToString(),
            "Time", Session["Time"].ToString());
        if (dt.Rows[0]["IsAttendance"].ToString().Trim() == "未考勤")
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private void SetControlsVisibleFalse()
    {
        lblMessage.Visible = false;
        btnAtten.Visible = false;
        gvAttendanceDetails.Visible = false;
        btnUnNormal.Visible = false;
        

    }

    private void InitialOperation()
    {
        throw new NotImplementedException();
    }

    System.Drawing.Color c;
    protected void rdo_CheckChange(object sender,EventArgs e)
    {
        foreach(GridViewRow row in this.gvAttendanceDetails.Rows)
        {
            Control ctl1 = row.FindControl("rdoNormal");
            Control ctl2 = row.FindControl("rdoLate");
            Control ctl3 = row.FindControl("rdoAbsence");
            Control ctl4 = row.FindControl("rdoEarly");
            Control ctl5 = row.FindControl("rdoLeave");

            TableCellCollection cell = row.Cells;
            if((ctl1 as RadioButton).Checked)
            {
                this.gvAttendanceDetails.Rows[row.DataItemIndex].BackColor = c;
            }
            if((ctl2 as RadioButton).Checked)
            {
                this.gvAttendanceDetails.Rows[row.DataItemIndex].BackColor =
                    System.Drawing.Color.Yellow;
            }
            if((ctl3 as RadioButton).Checked)
            {
                this.gvAttendanceDetails.Rows[row.DataItemIndex].BackColor =
                    System.Drawing.Color.Red;
            }
            if ((ctl4 as RadioButton).Checked)
            {
                this.gvAttendanceDetails.Rows[row.DataItemIndex].BackColor =
                    System.Drawing.Color.Yellow;
            }
            if ((ctl5 as RadioButton).Checked)
            {
                this.gvAttendanceDetails.Rows[row.DataItemIndex].BackColor =
                    System.Drawing.Color.SkyBlue;
            }


        }
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

    protected void btnAtten_Click(object sender, EventArgs e)
    {
        StringBuilder strLate = new StringBuilder("迟到的名单");
        StringBuilder strAbsence = new StringBuilder("旷课名单");
        StringBuilder strEarly = new StringBuilder("早退名单");
        StringBuilder strLeave = new StringBuilder("请假名单");

        int sum = 0;
       foreach(GridViewRow row in this.gvAttendanceDetails.Rows)

        {
            

            Control ctl2 = row.FindControl("rodLate");
            Control ctl3 = row.FindControl("rdoAbsence");
            Control ctl4 = row.FindControl("rdoEarly");
            Control ctl5 = row.FindControl("rdoLeave");
            TableCellCollection cell = row.Cells;
            if((ctl2 as RadioButton).Checked)
            { 
            if (AddSQLStringToDAL.InsertTabTeachers("TabStudentAttendance",Session["UserID"].ToString(),Session["UserName"].ToString()
               ,Session["CurrentCourse"].ToString(),Session["CurrentWeek"].ToString(), Session["Week"].ToString(),Session["Time"].ToString(),
               cell[0].Text.ToString(),cell[1].Text.ToString(),cell[2].Text.ToString(),cell[3].Text.ToString(),"迟到",""))
            {
                sum++;
                    strLate.Append(cell[3].Text.ToString()+";");
               
            }
            }
            if ((ctl3 as RadioButton).Checked)
            {
                if (AddSQLStringToDAL.InsertTabTeachers("TabStudentAttendance", Session["UserID"].ToString(), Session["UserName"].ToString()
              , Session["CurrentCourse"].ToString(), Session["CurrentWeek"].ToString(), Session["Week"].ToString(), Session["Time"].ToString(),
              cell[0].Text.ToString(), cell[1].Text.ToString(), cell[2].Text.ToString(), cell[3].Text.ToString(), "旷课", ""))
                {
                    sum++;
                    strAbsence.Append(cell[3].Text.ToString()+";");

                }
            }
            if ((ctl4 as RadioButton).Checked)
            {
                if (AddSQLStringToDAL.InsertTabTeachers("TabStudentAttendance", Session["UserID"].ToString(), Session["UserName"].ToString()
              , Session["CurrentCourse"].ToString(), Session["CurrentWeek"].ToString(), Session["Week"].ToString(), Session["Time"].ToString(),
              cell[0].Text.ToString(), cell[1].Text.ToString(), cell[2].Text.ToString(), cell[3].Text.ToString(), "早退", ""))
                {
                    sum++;
                    strEarly.Append(cell[3].Text.ToString() + ";");

                }
            }
            if ((ctl5 as RadioButton).Checked)
            {
                if (AddSQLStringToDAL.InsertTabTeachers("TabStudentAttendance", Session["UserID"].ToString(), Session["UserName"].ToString()
              , Session["CurrentCourse"].ToString(), Session["CurrentWeek"].ToString(), Session["Week"].ToString(), Session["Time"].ToString(),
              cell[0].Text.ToString(), cell[1].Text.ToString(), cell[2].Text.ToString(), cell[3].Text.ToString(), "请假", ""))
                {
                    sum++;
                    strLeave.Append(cell[3].Text.ToString() + ";");

                }
            }
        }
        if (strLate.ToString() == "迟到名单：")
            strLate.Append("无");
        if (strEarly.ToString() == "早退名单")
            strEarly.Append("无");
        if (strAbsence.ToString() == "旷课名单")
            strAbsence.Append("无");
        if (strLeave.ToString() == "请假名单")
            strLeave.Append("无");
        if (AddSQLStringToDAL.UpdataTabTeachers("TabTeacherAttendance", "IsAttendance", "已考勤", "Count", Session["Homework"].ToString(), "TeacherID", Session["UserID"].ToString(), "Course",Session["CurrentCourse"].ToString(),
            "CurrentWeek", Session["CurrentWeek"].ToString(),"Week",Session["Week"].ToString(),"Time",Session["Time"].ToString()))
        {
            lblAttendanceMessage.Text = strAbsence.ToString();
            lblLateMessage.Text = strLate.ToString();
            lblEarlyMessage.Text = strEarly.ToString();
            lblLeaveMessage.Text = strLeave.ToString();
            strLate.Remove(0,strLate.Length);
            strAbsence.Remove(0,strAbsence.Length);
            strEarly.Remove(0, strEarly.Length);
            strLeave.Remove(0,strLeave.Length);
            SetControlsVisibleFalse();
            lblResultMessage.Text = "本次考勤记录已经上报成功！本次课您"+Session["Homework"].ToString()+",请返回主界面！";
            btnClose.Visible = true;
        }
           
        //{ }
    }
}
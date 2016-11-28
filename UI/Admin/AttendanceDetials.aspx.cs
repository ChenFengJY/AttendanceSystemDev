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
                //Response.Redirect("~//Default.aspx");
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
        int CurrentWeek = 0; //当前周次
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
        StringBuilder strLate = new StringBuilder("迟到名单：");
        StringBuilder strAbsence = new StringBuilder("旷课名单：");
        StringBuilder strEarly = new StringBuilder("早退名单：");
        StringBuilder strLeave = new StringBuilder("请假名单：");
        DataTable attendanceList = MakeTabStudentAttendance();
        attendanceList.Clear();
        DataRow attendanceRow = attendanceList.NewRow();
        int sum = 0;
        foreach(GridViewRow row in this.gvAttendanceDetails.Rows)
        {

            Control ctl2 = row.FindControl("rodLate");
            Control ctl3 = row.FindControl("rdoAbsence");
            Control ctl4 = row.FindControl("rdoEarly");
            Control ctl5 = row.FindControl("rdoLeave");
            TableCellCollection cell = row.Cells;//获取GridView本行中的值的集合
            if((ctl2 as RadioButton).Checked)   //ctl2被选中 迟到
            {
                attendanceRow[0] = Session["UserID"] ;//TeacherID;
                attendanceRow[1] = Session["UserName"];   //TeacherName
                attendanceRow[2] = Session["CourseName"];  //CourseName 课程名
                attendanceRow[3] = Session["CurrentWeek"];  //CourseAllWeek
                attendanceRow[4] = Session["CourseWeek"];  //CourseWeek
                attendanceRow[5] = Session["CourseTime"];  //CourseTime
                attendanceRow[6] = cell[0].Text.ToString();   //StudentDepartment
                attendanceRow[7] = cell[2].Text.ToString();    //StudentId
                attendanceRow[8] = cell[3].Text.ToString();    //studentName
                attendanceRow[9] = cell[1].Text.ToString();    //t4 班级名称
                attendanceRow[10] = "迟到";   //AttendanceType
                attendanceList.Rows.Add(attendanceRow);
                sum++;
                strLate.Append(cell[3].Text.ToString()+";");//学生姓名

            }
            if ((ctl3 as RadioButton).Checked)
            {
                attendanceRow[0] = Session["UserID"];//TeacherID;
                attendanceRow[1] = Session["UserName"];   //TeacherName
                attendanceRow[2] = Session["CourseName"];  //CourseName 课程名
                attendanceRow[3] = Session["CurrentWeek"];  //CourseAllWeek
                attendanceRow[4] = Session["CourseWeek"];  //CourseWeek
                attendanceRow[5] = Session["CourseTime"];  //CourseTime
                attendanceRow[6] = cell[0].Text.ToString();   //StudentDepartment
                attendanceRow[7] = cell[2].Text.ToString();    //StudentId
                attendanceRow[8] = cell[3].Text.ToString();    //studentName
                attendanceRow[9] = cell[1].Text.ToString();    //t4 班级名称
                attendanceRow[10] = "迟到";   //AttendanceType
                attendanceList.Rows.Add(attendanceRow);
                sum++;

                strAbsence.Append(cell[3].Text.ToString()+";");

            }
            if ((ctl4 as RadioButton).Checked)
            {
                attendanceRow[0] = Session["UserID"];//TeacherID;
                attendanceRow[1] = Session["UserName"];   //TeacherName
                attendanceRow[2] = Session["CourseName"];  //CourseName 课程名
                attendanceRow[3] = Session["CurrentWeek"];  //CourseAllWeek
                attendanceRow[4] = Session["CourseWeek"];  //CourseWeek
                attendanceRow[5] = Session["CourseTime"];  //CourseTime
                attendanceRow[6] = cell[0].Text.ToString();   //StudentDepartment
                attendanceRow[7] = cell[2].Text.ToString();    //StudentId
                attendanceRow[8] = cell[3].Text.ToString();    //studentName
                attendanceRow[9] = cell[1].Text.ToString();    //t4 班级名称
                attendanceRow[10] = "迟到";   //AttendanceType
                attendanceList.Rows.Add(attendanceRow);
                sum++;

                strEarly.Append(cell[3].Text.ToString() + ";");

            }
            if ((ctl5 as RadioButton).Checked)
            {
                attendanceRow[0] = Session["UserID"];//TeacherID;
                attendanceRow[1] = Session["UserName"];   //TeacherName
                attendanceRow[2] = Session["CourseName"];  //CourseName 课程名
                attendanceRow[3] = Session["CurrentWeek"];  //CourseAllWeek
                attendanceRow[4] = Session["CourseWeek"];  //CourseWeek
                attendanceRow[5] = Session["CourseTime"];  //CourseTime
                attendanceRow[6] = cell[0].Text.ToString();   //StudentDepartment
                attendanceRow[7] = cell[2].Text.ToString();    //StudentId
                attendanceRow[8] = cell[3].Text.ToString();    //studentName
                attendanceRow[9] = cell[1].Text.ToString();    //t4 班级名称
                attendanceRow[10] = "迟到";   //AttendanceType
                attendanceList.Rows.Add(attendanceRow);
                sum++;

                strLeave.Append(cell[3].Text.ToString() + ";");

            }
        }
        string result= AddSQLStringToDAL.InsertForSql(attendanceList, "TabStudentAttendance", 11);//异常学生导入
        string strsql = "update TabTeacherCourseWeek SET AttendanceInfo = 1 WHERE TeacherId = " + Session["UserID"] + " and CourseAllWeek = " + Session["CurrentWeek"] + " and CourseWeek = " + Session["CourseWeek"] + " and CourseTime = " + Session["CourseTime"] + " ";
        AddSQLStringToDAL.InsertData(strsql);
        if (result== "导入成功")
        {
            if (strLate.ToString() == "迟到名单：")
                strLate.Append("无");
            if (strEarly.ToString() == "早退名单：")
                strEarly.Append("无");
            if (strAbsence.ToString() == "旷课名单：")
                strAbsence.Append("无");
            if (strLeave.ToString() == "请假名单：")
                strLeave.Append("无");

            lblAttendanceMessage.Text = strAbsence.ToString();
            lblLateMessage.Text = strLate.ToString();
            lblEarlyMessage.Text = strEarly.ToString();
            lblLeaveMessage.Text = strLeave.ToString();
            strLate.Remove(0, strLate.Length);
            strAbsence.Remove(0, strAbsence.Length);
            strEarly.Remove(0, strEarly.Length);
            strLeave.Remove(0, strLeave.Length);
            SetControlsVisibleFalse();
            lblResultMessage.Text = "本次考勤记录已经上报成功！本次课您" + Session["Homework"].ToString() + ",请返回主界面！";
            btnClose.Visible = true;

        }


    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("AttendanceDetials.aspx");
    }

    private DataTable MakeTabStudentAttendance()
    {
        string strSql = "select * from [TabStudentAttendance] where 0 = 1";
        return AddSQLStringToDAL.GetDtBySQL(strSql);
    }
}
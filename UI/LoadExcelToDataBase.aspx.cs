using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;

public partial class LoadExcelToDataBase : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["uesrID"].ToString() == "")
            {
                Response.Redirect("~//Default.aspx");
            }

            else
            {
                btnClearPreData.Attributes.Add("onclick", "return confirm('本操作将清空所有数据表,确定要执行这个操作吗?');");
                btnPreOperation.Attributes.Add("onclick", "return confirm('本操作将颠覆原有数据,确定要执行这个操作吗?')");
                btnTeacherAttendance.Attributes.Add("onclick", "return confirm('本操作覆盖原有数据，确定要执行这个操作吗?')");
            }
        }
    }
    private void BtnImportTeacher_Click(object sender, EventArgs e)
    {
        Clear();
        string identity = "";
        if (rdoTeacher.Checked | rdoOther.Checked)
        {
            if (rdoTeacher.Checked)
                identity = "Tab Teacher";
            else
                identity = "TabOtherTeachers";
            lblMessage1.Text = ExcelToDataBase.CheckFile(fileexcel.Value.ToString(), identity);

        }
        else
        {
            lblMessage1.Text = "请选择导入的数据是"本地教师"或"外聘教师"";
        }
    }
    private void BtnImportCourse_Click(object sender, EventArgs e)
    {
        Clear();
        string department = "";
        department = ddlDepartmentName.SelectedItem.Tostring();
        lblMessage2.Text = ExcelToDatabase.CheckFile(filecourse.Value.Tostring(), department);
    }
    private void ddlDepartmentName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear();
    }
    private void rdo_CheckedChanged(object sender, EventArgs e)
    {
        Clear();
    }
    private void InsertTeacherStatus()
    {
        Clear();
        List<string> str = new List<string>();
        str = AddSQLStringToDAL.GetDistinctString("TabAllCourses", "TeacherID");
        for (int i = 0; i < str.Count; i++)
        {
            if (AddSQLStringToDAL.InsertTabTeachers("TabTeacherstatus", str[i].ToString(), "False"))
            {
                lblMessage3.Text = "正在进行第一步预处理!";
            }
            lblMessage3.Text = "第一步:教师信息对比完成！正在进行第二步...";
            InsertTeacherCourseSimpleMap(str);
            lblMessage3.Text = "所有信息核对无误！请对数据进行处理";
        }
    }
        private void InsertTeacherCourseSimpleMap(List<string> strDistinctTeacherID)
    {
        for (int i = 0; i < strDistinctTeacherID.Count; i++)
        {
            List<string> strDD = new List<string>(); 
            strDD = AddSQLStringToDAL.GetDistinctString("TabAllCourses", "TimeAndArea", "TeacherID", strDistinctTeacherID[i].ToString());
            for (int k = 0; k < strDD.Count; k++)
            {
                List<string> strReslt = new List<string> ();
                strReslt = SplitString.GetSplitCountAndDetails(strDD[k]);
                DataTable dt = AddSQLStringToDAL.GetDatatableBySQL("TabAllourses", "TeacherID", "strDistinctTeacher[i].ToString()", "TimeAndArea", strDD[k].ToString());
                for (int j = 0; j < (strResult.Count / 4); j++)
                {
                    String WeekRange = SplitString.GetWithoutWeek(strReslt[j * 4 + 0].ToString());
                    string Week = strReslt[j * 4 + 1].ToString();
                    string Time = strReslt[j * 4 + 2].ToString();
                    string Area = strReslt[j * 4 + 3].ToString();
                    string Course = strReslt[j * 4 + 4].ToString().Trim();
                    if (AddSQLStringToDAL.InsertTabTeacher("TabTeacherCourse SimpleMap", strDistinctTeacherID[i].ToString(), dt.Rows[0]["TeacherName"].ToString(), Course, WeekRange, Week, Time, strDD[k].ToString(), dt.Rows[0]["t4"].ToString(), dt.Rows.Count.ToString(), dt.Rows[0]["t1"].ToString(), dt.Rows[0].ToString(), dt.Rows[0]["StudentDepartment"].ToString(), Area))
                    {
                    }
                }
                dt.Clear();
            } 
        }
    }
    protected void btnClearPreData_Click(object sender, EventArgs e)
    {
        Clear();
        if(AddSQLStringToDAL.DeleteTabTeachers("TabTeacherstatus")&&AddSQLStringToDAL.Delete TabTeachers("TabTeacherCourseSimpleMap")&&AddSQLStringToDAL.DelectTabTeachers("TabTeacherAttendance"&&AddSQLStringToDAL.DelectTabTeachers("TabStudentAttendance")&&AddSQLStringToDAL.DelectTabTeachers("TabTeacherHome")))
            {
            lblMessage4.Text = "异常数据清空完毕！请对数据进行分析和处理";
        }
    }
    private void Clear()
    {
        lblMessage1.Text = "";
        lblMessage2.Text = "";
        lblMessage3.Text = "";
        lblMessage4.Text = "";
        lblMessage5.Text = "";
        lblMessage7.Text = "";

    }
}
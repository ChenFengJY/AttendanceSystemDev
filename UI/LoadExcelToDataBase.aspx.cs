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

    }
/*    protected void Page_Load(object sender, EventArgs e)
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
                List<string> strReslt = new List<string>();
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
        if (AddSQLStringToDAL.DeleteTabTeachers("TabTeacherstatus") && AddSQLStringToDAL.Delete TabTeachers("TabTeacherCourseSimpleMap") && AddSQLStringToDAL.DelectTabTeachers("TabTeacherAttendance" && AddSQLStringToDAL.DelectTabTeachers("TabStudentAttendance") && AddSQLStringToDAL.DelectTabTeachers("TabTeacherHome")))
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
    protected void BtnImportCalendar_Click(object sender, EventArgs e)
    {
        Clear();
        AddSQLStringToDAL.DelectTabTeachers("TabCalendar");
        lblMessage5.Text = "ExcalToDatabase.CheckFile(file1.Value.Tostring(),"TabCalendar");
    }
    protected void btnTeacherAttendance_Click(object sender, EventArgs e)
    {
        Clear();
        GetTeacherCourseSimpleMap();
    }
    private void GetTeacherCourseSimpleMap()
    {
        DataTable dt = AddSQLStringToDAL.GetDatatableBySQL("TabTeacherCourseSimpleMap");
        foreach (DataRow dr in dt.Rows)
        {
            string[] strT = dr["WeekRange"].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strT.Length; i++)
            {
                string WeekNumber = dr["TeacderDepartment"].ToString();
                String TeacherID = dr["TeacherID"].ToString();
                string TeacehrName = dr["TeacherName"].ToString();
                string Week = dr["Week"].ToString();
                switch (Week)
                {
                    case "星期一":
                        WeekNumber = "1";
                        break;
                    case "星期二":
                        WeekNumber = "2";
                        break;
                    case "星期三":
                        WeekNumber = "3";
                        break;
                    case "星期四":
                        WeekNumber = "4";
                        break;
                    case "星期五":
                        WeekNumber = "5";
                        break;
                    case "星期六":
                        WeekNumber = "6";
                        break;

                    case "星期天":
                        WeekNumber = "7";
                        break;
                }
                string Time = dr["Time"].ToString();
                string Course = dr["Course"].ToString();
                string Area = dr["Area"].ToString();
                if (strT[i].Length == 1)
                {
                    strT[i] = "0" + strT[i];
                    if (AddSQLStringToDAL.InsertTabTeacher("TabTeacherAttendance", "WeekNumber", "TeacherDepartment", "TeacherID", "TeacherName", strT[i].ToString, Week, Time, Course, Area, "未考勤", "", dr["WithoutWeek"].ToString(), "", ""))
                    {
                    }
                }
            }
            lblMessage7.Text = "数据处理完毕";
        }
protected void btnClearCalendar_Click(object sender, EventArgs e)
    {

    }
    protected void BtnDepartmentCount_Click(object sender, EventArgs e)
    {
        if (txtKJ.Text != "" && txtXX.Text != "" && txtJG.Text != "" && txtSP.Text != "" && txtJX.Text != "" && txtWY.Text != "" && txtJZ.Text != "")
        {
            string[] str = { "会计系", "信息工程系", "经济管理系", "食品工程系", "机械工程系", "商务外语系", "建筑工程系" };
            int[] sum = new int[str.Length];
            sum[0] = Convert.ToInt32(txtKJ.Text.Trim());
            sum[1] = Convert.ToInt32(txtXX.Text.Trim());
            sum[2] = Convert.ToInt32(txtJG.Text.Trim());
            sum[3] = Convert.ToInt32(txtSP.Text.Trim());
            sum[4] = Convert.ToInt32(txtJX.Text.Trim());
            sum[5] = Convert.ToInt32(txtWY.Text.Trim());
            sum[6] = Convert.ToInt32(txtJZ.Text.Trim());
        }
        if (AddSQLStringToDAL.DeleteTabTeachers("TabDepartment"))
        {

        }
        for (int i = 0; i < str.Length; i++)
        {
            if (AddSQLStringToDAL.InsertTabTeacher("TabDepartment", str[i], sum[i].ToString()))
            {
                label6.Text = "各系人数设置完毕";
            }
            else
            {
                label6.Text = "各系人数设置完毕";
            }
        }
    }*/
}
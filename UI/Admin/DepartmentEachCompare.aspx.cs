using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Owc11;

public partial class Admin_DepartmentEachCompare : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DataTable dt = AddSQLStringToDAL.GetDtBySQL(strSql);
            GridView1.DataSource = dt;
            GridView1.DataKeyNames = new string[] { "UserID" };
            GridView1.DataBind();

            GetDataAndCreateChartBySum();
        }
    }
    private void GetDataAndCreateChartBySum()
    {
        string strSql = "select * from TabDepartment";
        DataTable dtCount = AddSQLStringToDAL.GetDtBySQL(strSql);
        string[] AllCount = new string[dtCount.Rows.Count];
        for (int i = 0; i < dtCount.Rows.Count; i++)
        {
            AllCount[i] = dtCount.Rows[i]["sum"].ToString();
        }
        string[] AllDepartment = { "会计系", "信息工程系", "经济管理系", "食品管理系", "机械工程系", "商务外语系", "建筑工程系" };
        string[] AllData = new string[AllDepartment.Length];
        string[] AllLate = new string[AllDepartment.Length];
        string[] AllAttendance = new string[AllDepartment.Length];
        string[] AllEarly = new string[AllDepartment.Length];
        string[] AllLeave = new string[AllDepartment.Length];
        for (int i = 0; i < AllDepartment.Length; i++)
        {
            DataTable dt = InitialDataTable(AllDepartment[i]);
            AllData[i] = dt.Rows[dt.Rows.Count - 1]["合计"].ToString();
            AllLeave[i] = dt.Rows[dt.Rows.Count - 1]["请假人数"].ToString();
            AllAttendance[i] = dt.Rows[dt.Rows.Count - 1]["旷课人数"].ToString();
            AllEarly[i] = dt.Rows[dt.Rows.Count - 1]["早退人数"].ToString();
            AllLate[i] = dt.Rows[dt.Rows.Count - 1]["迟到人数"].ToString();
        }
        DataTable dt111 = DataAnalysis.CreateDataTableReplaceChart(AllDepartment, AllCount, AllAttendance, AllLate, AllEarly, AllLeave, AllData);

        string[] AllDataRate = new string[AllDepartment.Length];
        string[] AllAttendanceRate = new string[AllDepartment.Length];
        string[] AllLeaveRate = new string[AllDepartment.Length];
        string[] AllLateRange = new string[AllDepartment.Length];
        string[] AllEarlyRate = new string[AllDepartment.Length];
        for (int i = 0; i < dt111.Rows.Count; i++)
        {
            AllDataRate[i] = dt111.Rows[i]["总缺勤率"].ToString();
            AllAttendanceRate[i] = dt111.Rows[i]["旷课率"].ToString();
            AllLeaveRate[i] = dt111.Rows[i]["迟到率"].ToString();
            AllEarly[i] = dt111.Rows[i]["早退率"].ToString();
        }
        GridView1.DataSource = dt111;
        GridView1.DataBind();
        if (Session["CurrentWeek"].ToString() == "01")
        {
            //s1,2... html标签<img>
            string s1 = DrawChart("总缺勤率", AllDepartment, AllDataRate, Session["CurrentWeek"].ToString());
            this.phDepartmentEachCompare.Controls.Add(new LiteralControl(s1));
            string s2 = DrawChart("旷课率", AllDepartment, AllAttendanceRate, Session["CurrentWeek"].ToString());
            this.phDepartmentEachCompare.Controls.Add(new LiteralControl(s2));
            string s3 = DrawChart("请假率", AllDepartment, AllLeaveRate, Session["CurrentWeek"].ToString());
            this.phDepartmentEachCompare.Controls.Add(new LiteralControl(s3));
            string s4 = DrawChart("迟到率", AllDepartment, AllLeaveRate, Session["CurrentWeek"].ToString());
            this.phDepartmentEachCompare.Controls.Add(new LiteralControl(s4));
            string s5 = DrawChart("早退率", AllDepartment, AllLeaveRate, Session["CurrentWeek"].ToString());
            this.phDepartmentEachCompare.Controls.Add(new LiteralControl(s5));
        }
        else
        {
            string s1 = DrawChart("总缺勤率", AllDepartment, AllDataRate, "01-" + Session["CurrentWeek"].ToString());
            this.phDepartmentEachCompare.Controls.Add(new LiteralControl(s1));
            string s2 = DrawChart("旷课率", AllDepartment, AllDataRate, "01-" + Session["CurrentWeek"].ToString());
            this.phDepartmentEachCompare.Controls.Add(new LiteralControl(s2));
            string s3 = DrawChart("请假率", AllDepartment, AllDataRate, "01-" + Session["CurrentWeek"].ToString());
            this.phDepartmentEachCompare.Controls.Add(new LiteralControl(s3));
            string s4 = DrawChart("迟到率", AllDepartment, AllDataRate, "01-" + Session["CurrentWeek"].ToString());
            this.phDepartmentEachCompare.Controls.Add(new LiteralControl(s4));
            string s5 = DrawChart("早退率", AllDepartment, AllDataRate, "01-" + Session["CurrentWeek"].ToString());
            this.phDepartmentEachCompare.Controls.Add(new LiteralControl(s5));

        }

    }
    private DataTable InitialDataTable(string Department)
    {
        DataTable dt = DataAnalysis.CreateDateTable();
        //当前周次
        for (int i = Convert.ToInt32(Session["CurrentWeek"]); i > 0; i--)
        {
            string strLate = "SELECT COUNT(*) AS LateMount FROM TabStudentAttendance where StudentDepartment = '" + Department + "' and CourseAllWeek = " + i + " and AttendanceType = '迟到' ";
            int Late = Convert.ToInt32(AddSQLStringToDAL.GetDtBySQL(strLate).Rows[0][0]);//获取此系此周迟到的人数
            string strEarly = "SELECT COUNT(*) AS EarlyMount FROM TabStudentAttendance where StudentDepartment = '" + Department + "' and CourseAllWeek = " + i + " and AttendanceType = '早退' ";
            int Early = Convert.ToInt32(AddSQLStringToDAL.GetDtBySQL(strEarly).Rows[0][0]);//获取此系此周早退的人数
            string strAttendance = "SELECT COUNT(*) AS EarlyMount FROM TabStudentAttendance where StudentDepartment = '" + Department + "' and CourseAllWeek = " + i + " and AttendanceType = '旷课' ";
            int Attendance = Convert.ToInt32(AddSQLStringToDAL.GetDtBySQL(strAttendance).Rows[0][0]);//获取此系此周早退的人数

            string strLeave = "SELECT COUNT(*) AS EarlyMount FROM TabStudentAttendance where StudentDepartment = '" + Department + "' and CourseAllWeek = " + i + " and AttendanceType = '请假' ";
            int Leave = Convert.ToInt32(AddSQLStringToDAL.GetDtBySQL(strLeave).Rows[0][0]);//获取此系此周早退的人数

            
            DataRow dr = DataAnalysis.CreateDataRow(dt, i, Department, Late, Early, Attendance, Leave);
            dt.Rows.Add(dr);
        }
        DataRow drLast = DataAnalysis.InsertLatRow(dt);
        //添加总数
        dt.Rows.Add(drLast);
        return dt;
    }
    private void CreateDataRow()
    {

    }
    //生成图片,返回img标签
    protected string DrawChart(string DrawType, string[] AllDepartment, string[] AllDataRate, string Range)
    {
        //
        string strXdata = string.Empty;
        for (int i = 0; i < AllDepartment.Length; i++)
        {
            strXdata += AllDepartment[i] + "\r" + DrawType + AllDataRate[i] + "\t";
        }
        string strYdata = string.Empty;
        foreach (string strValue in AllDataRate)
        {
            strYdata += strValue + "\t";
        }
        ChartSpace laySpace = new ChartSpaceClass();
        ChChart InsertChart = laySpace.Charts.Add(0);
        InsertChart.Type = ChartChartTypeEnum.chChartTypeColumnClustered;
        InsertChart.HasLegend = false;
        InsertChart.HasTitle = true;
        InsertChart.Title.Caption = "第" + Range + "周各系部学生[" + DrawType + "]对比图";
        InsertChart.Axes[0].HasTitle = true;
        InsertChart.Axes[0].Title.Caption = "系部";
        InsertChart.Axes[1].HasTitle = true;
        InsertChart.Axes[1].Title.Caption = DrawType;
        InsertChart.SeriesCollection.Add(0);
        InsertChart.SeriesCollection[0].SetData(ChartDimensionsEnum.chDimSeriesNames, (int)ChartSpecialDataSourcesEnum.chDataLiteral, "图例1");
        InsertChart.SeriesCollection[0].SetData(ChartDimensionsEnum.chDimCategories, (int)ChartSpecialDataSourcesEnum.chDataLiteral, strXdata);
        InsertChart.SeriesCollection[0].SetData(ChartDimensionsEnum.chDimValues, (int)ChartSpecialDataSourcesEnum.chDataLiteral, strYdata);
        string strAbsoulutePath = (Server.MapPath(".")) + "\\" + DrawType + ".gif";
        laySpace.ExportPicture(strAbsoulutePath, "GIF", 850, 300);
        string strRelativePath = "./" + DrawType + ".gif";//img地址
        Random rd = new Random();
        string strImageTag = "<img src=" + strRelativePath + "?id=" + rd.Next(65500) + "/>";
        string url = "DepartmentEachCompare.aspx?ImageUrl=" + strImageTag;
        return strImageTag;
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
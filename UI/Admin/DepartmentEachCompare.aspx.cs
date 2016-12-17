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

            GetDataAndCreateChartBySum();
        }
    }
    private void GetDataAndCreateChartBySum()
    {
        string strSql = "select * from TabDepartment";//每个系部总人数
        DataTable dtCount = AddSQLStringToDAL.GetDtBySQL(strSql);
        string[] AllCount = new string[dtCount.Rows.Count];//保存每个系部总人数

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
        //储存每个系合计后的考勤情况
        for (int i = 0; i < AllDepartment.Length; i++)
        {
            DataTable dt = DataAnalysis.SumData(AllDepartment[i],Convert.ToInt32(Session["CurrentWeek"]));
            AllData[i] = dt.Rows[dt.Rows.Count - 1][6].ToString();//合计
            AllLeave[i] = dt.Rows[dt.Rows.Count - 1][5].ToString();//请假
            AllAttendance[i] = dt.Rows[dt.Rows.Count - 1][4].ToString();//旷课
            AllEarly[i] = dt.Rows[dt.Rows.Count - 1][3].ToString();//早退
            AllLate[i] = dt.Rows[dt.Rows.Count - 1][2].ToString();//迟到
        }
        //储存所有系
        DataTable gridViewDt = DataAnalysis.CreateDataTableReplaceChart(AllDepartment, AllCount, AllLate, AllEarly,AllAttendance, AllLeave, AllData);
        //需要：GridView中的数据
        string[] AllDataRate = new string[AllDepartment.Length];
        string[] AllAttendanceRate = new string[AllDepartment.Length];
        string[] AllLeaveRate = new string[AllDepartment.Length];
        string[] AllLateRate = new string[AllDepartment.Length];
        string[] AllEarlyRate = new string[AllDepartment.Length];
        for (int i = 0; i < gridViewDt.Rows.Count; i++)
        {
            AllDataRate[i] = gridViewDt.Rows[i]["SumRate"].ToString();
            AllLateRate[i]= gridViewDt.Rows[i]["LeaveRate"].ToString();//请假率
            AllAttendanceRate[i] = gridViewDt.Rows[i]["AttendanceRate"].ToString();//旷课率
            AllLeaveRate[i] = gridViewDt.Rows[i]["LateRate"].ToString();//迟到率
            AllEarlyRate[i] = gridViewDt.Rows[i]["EarlyRate"].ToString();//早退率
        }

        //
        GridView1.DataSource = gridViewDt;
        GridView1.DataBind();
        //插入图片（表）吧
        if (Session["CurrentWeek"].ToString() == "1")
        {
            //s1,2... html标签<img>
            string s1 = DrawChart("总缺勤率", AllDepartment, AllDataRate, Session["CurrentWeek"].ToString());
            this.phDepartmentEachCompare.Controls.Add(new LiteralControl(s1));
            string s2 = DrawChart("旷课率", AllDepartment, AllAttendanceRate, Session["CurrentWeek"].ToString());
            this.phDepartmentEachCompare.Controls.Add(new LiteralControl(s2));
            string s3 = DrawChart("请假率", AllDepartment, AllLateRate, Session["CurrentWeek"].ToString());
            this.phDepartmentEachCompare.Controls.Add(new LiteralControl(s3));
            string s4 = DrawChart("迟到率", AllDepartment, AllLeaveRate, Session["CurrentWeek"].ToString());
            this.phDepartmentEachCompare.Controls.Add(new LiteralControl(s4));
            string s5 = DrawChart("早退率", AllDepartment, AllEarlyRate, Session["CurrentWeek"].ToString());
            this.phDepartmentEachCompare.Controls.Add(new LiteralControl(s5));
        }
        else
        {
            string s1 = DrawChart("总缺勤率", AllDepartment, AllDataRate, "01-" + Session["CurrentWeek"].ToString());
            this.phDepartmentEachCompare.Controls.Add(new LiteralControl(s1));
            string s2 = DrawChart("旷课率", AllDepartment, AllAttendanceRate, "01-" + Session["CurrentWeek"].ToString());
            this.phDepartmentEachCompare.Controls.Add(new LiteralControl(s2));
            string s3 = DrawChart("请假率", AllDepartment, AllLateRate, "01-" + Session["CurrentWeek"].ToString());
            this.phDepartmentEachCompare.Controls.Add(new LiteralControl(s3));
            string s4 = DrawChart("迟到率", AllDepartment, AllLeaveRate, "01-" + Session["CurrentWeek"].ToString());
            this.phDepartmentEachCompare.Controls.Add(new LiteralControl(s4));
            string s5 = DrawChart("早退率", AllDepartment, AllEarlyRate, "01-" + Session["CurrentWeek"].ToString());
            this.phDepartmentEachCompare.Controls.Add(new LiteralControl(s5));

        }

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
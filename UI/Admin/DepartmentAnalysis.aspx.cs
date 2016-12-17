using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Office.Interop.Owc11;

using System.Data.SqlClient;
using System.Data;

public partial class Admin_DepartmentAnalysis : System.Web.UI.Page
{
 

    public object ChartDimensionsEnum { get; private set; }

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    private DataTable InitialDataTable(string Department)
    {
        DataTable dt = DataAnalysis.CreateDataTable();
        string cWeek = Session["CurrentWeek"].ToString();
        for (int i = Convert.ToInt32(cWeek); i > 0; i++)
        {
            string str1 = i.ToString();
            if (str1.Length == 1)
                str1 = "0" + str1;
            int Late = DataAnalysis.GetEveryAttendanceNumber(Department, str1, "迟到");
            int Early = DataAnalysis.GetEveryAttendanceNumber(Department, str1, "早退");
            int Attendance = DataAnalysis.GetEveryAttendanceNumber(Department, str1, "旷课");
            int Leave = DataAnalysis.GetEveryAttendanceNumber(Department, str1, "请假");
            DataRow dr = DataAnalysis.CreateDataRow(dt, str1, Department, Late, Early, Attendance, Leave);
            dt.Rows.Add(dr);
        }
        DataRow drLast = DataAnalysis.InsertLastRow(dt);
        dt.Rows.Add(drLast);
        return dt;
    }
    protected void btnKJ_Click(object sender, EventArgs e)
    {
        lblKJ.Text = "";
        DataTable dt = InitialDataTable("会计系");
        if (dt.Rows.Count > 0)
        {
            PreOperation("KJ");
            string strImageTag = DrawChart(dt);
            if (strImageTag != "")
            {
                this.phKJ.Controls.Add(new LiteralControl(strImageTag));
            }
            else
            {
                lblKJ.Text = "无法生成图表！";
            }
        }
        else
        {
            lblKJ.Text = "会计系目前没有缺勤学生信息，无法生成走势图！";

        }
        }

    private void PreOperation(string v)
    {
        throw new NotImplementedException();
    }

    private string DrawChart(DataTable dtTemp)
    {
        int zz = dtTemp.Rows.Count - 1;
        if (zz>0)
        {
            string[] AllWeek = new string[zz];
            string[] AllAttendanceNum = new string[zz];
            for (int i=0;i< dtTemp.Rows.Count - 1;i++)
            {
                zz--;
               
                AllWeek[i] = dtTemp.Rows[zz]["周次"].ToString();
                AllAttendanceNum[i] = dtTemp.Rows[zz]["合计"].ToString();
            }
            string strXdata = string.Empty;
            foreach (string strData in AllWeek)
            {
                strXdata += strData + "\t";

            }
            string strYdata = string.Empty;
            foreach (string strValue in AllAttendanceNum)
            {
                strYdata += strValue + "\t";
            }
           
      
        ChartSpace laySpace = new ChartSpaceClass();
        ChChart InsertChart = laySpace.Charts.Add(0);
        InsertChart.Type = ChartChartTypeEnum.chChartTypeLineStacked;
        InsertChart.HasLegend = false;
        InsertChart.HasTitle = true;
        InsertChart.Title.Caption = dtTemp.Rows[0]["系部"] + "学生" + AllWeek[0] + "-" + AllWeek[AllWeek.Length - 1] + "周缺勤情况走势图";
        InsertChart.Axes[0].HasTitle = true;
        InsertChart.Axes[0].Title.Caption = "周次";
        InsertChart.Axes[1].HasTitle = true;
        InsertChart.Axes[1].Title.Caption = "缺勤人数";
        InsertChart.SeriesCollection.Add(0);
        InsertChart.SeriesCollection[0].SetData(ChartDimensionsEnum.chDimSeriesNames, (int)ChartSpecialDataSourcesEnum.chDataLiteral,"图例1");
        InsertChart.SeriesCollection[0].SetData(ChartDimensionsEnum.chDimCategories, (int)ChartSpecialDataSourcesEnum.chDataLiteral.strXdata);
        InsertChart.SeriesCollection[0].SetData(ChartDimensionsEnum.chDimValues, (int)ChartSpecialDataSourcesEnum.chDataLiteral.strYdata);
        string strAbsolutePath = (Server.MapPath(".")+"\\ShowData.gif");
        laySpace.ExportPicture(strAbsolutePath,"GIF",500,250);
        string strRelativePath = "./ShowData.gif";
        Random rd = new Random();
        string strImageTag = "<img src='"+strRelativePath+"?id="+rd.Next(65500)+"'/>";
        return strImageTag;
    }
    else
    return "";
    }
    protected void gvKJ_RowDataBound(object sender,GridViewRowEventArgs e)
    {
        if (e.Row.Cells[6].Text=="0")
        {
            Control ct1 = e.Row.FindControl("btnDetail");
            (ct1 as Button).Enabled=false;
        }
        if (e.Row.Cells[1].Text=="缺勤人数")
        {
            Control ct1= e.Row.FindControl("btnDetail");
            (ct1 as Button).Visible = false;


        }
    }

    protected void btnXX_Click(object sender, EventArgs e)
    {

    }

    protected void btnDetail_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridViewRow dvr = btn.Parent.Parent as GridViewRow;
        string queryWeek = dvr.Cells[0].Text.ToString();
        string queryDepartment = dvr.Cells[1].Text.ToString();
        string url = "AttendanceStudentDetails.aspx?queryWeek=" + queryWeek + "&queryDepartment=" + Server.UrlEncode(queryDepartment);
        Page.RegisterStartupScript("ServiceManHistoryButtonClick", "<script>window.open('" + url + "','_blank')</script>");
    }
}



public class DataAnalysis
{
    internal static DataTable CreateDataTable()
    {
        throw new NotImplementedException();
    }

    internal static int GetEveryAttendanceNumber(string department, string str1, string v)
    {
        throw new NotImplementedException();
    }

    internal static DataRow InsertLastRow(DataTable dt)
    {
        throw new NotImplementedException();
    }
    

    }
  

    internal static DataRow CreateDataRow(DataTable dt, string str1, string department, int late, int early, int attendance, int leave)
    {
        throw new NotImplementedException();
    }


public class GridViewRowEventArge
{
}
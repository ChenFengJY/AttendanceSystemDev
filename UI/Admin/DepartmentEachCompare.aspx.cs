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
    public string getButtomTag = "new Array()";//返回""中的语句
    public string getClassName = "new Array()";
    public string getDataName1 = "new Array()";
    public string getDataName2 = "new Array('23','34','6','33','87','54','71')";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["CurrentWeek"] = 17;//调试用

            string[] AllDepartment = { "会计系", "信息工程系", "经济管理系", "食品工程系", "机械工程系", "商务外语系", "建筑工程系" };
            getButtomTag = BuildButtomTag(AllDepartment);
            //getButtomTag = "new Array('会计系','信息工程系','经济管理系','食品工程系','机械工程系','商务外语系','建筑工程系')";
            getClassName = "new Array('缺勤人数','缺勤率')";
            //获取缺勤人数，传入时间，返回各系总缺勤人数，缺勤率
            DataTable dt = DataAnalysis.GetDataAndCreateChartBySum(Convert.ToInt32(Session["CurrentWeek"]), 1);
            string[] dataname1 = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataname1[i] = dt.Rows[i]["Sum"].ToString();
            }
            getDataName1 = BuildButtomTag(dataname1);
            string[] dataname2 = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataname2[i] = dt.Rows[i]["SumRate"].ToString().TrimEnd('%');
            }
            getDataName2 = BuildButtomTag(dataname2);
            //getDataName2 = "new Array(" + dt.Rows[0]["SumRate"] + "," + dt.Rows[1]["SumRate"] + "," + dt.Rows[2]["SumRate"] + "," + dt.Rows[3]["SumRate"] + "," + dt.Rows[4]["SumRate"] + "," + dt.Rows[5]["SumRate"] + "," + dt.Rows[6]["SumRate"] + ")";
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        //开学至今
        string[] AllDepartment = { "会计系", "信息工程系", "经济管理系", "食品工程系", "机械工程系", "商务外语系", "建筑工程系" };
        getButtomTag = BuildButtomTag(AllDepartment);
        getClassName = "new Array('缺勤人数','缺勤率')";
        //获取缺勤人数，传入时间，返回各系总缺勤人数，缺勤率
        DataTable dt = DataAnalysis.GetDataAndCreateChartBySum(Convert.ToInt32(Session["CurrentWeek"]), 1);
        string[] dataname1=new string[dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dataname1[i] = dt.Rows[i]["Sum"].ToString();
        }
        getDataName1=BuildButtomTag(dataname1);
        
        getDataName2 ="new Array("+dt.Rows[0]["SumRate"] +","+dt.Rows[1]["SumRate"] +","+dt.Rows[2]["SumRate"] + "," + dt.Rows[3]["SumRate"] + "," + dt.Rows[4]["SumRate"] + "," + dt.Rows[5]["SumRate"] + "," + dt.Rows[6]["SumRate"] + ")";
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    private string BuildButtomTag(string[] buttomTag)
    {
        string buildButtomTag = "new Array('";
        for (int i = 0; i < buttomTag.Length; i++)
        {
            if (i == buttomTag.Length - 1)
            {
                buildButtomTag = buildButtomTag + buttomTag[i];
            }
            else
            {
                buildButtomTag = buildButtomTag +buttomTag[i]+"','";
            }
        }
        buildButtomTag = buildButtomTag + "')";
        return buildButtomTag;
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        //本月
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        //本周
        if (RadioButton3.Checked)
        {
            string[] AllDepartment = { "会计系", "信息工程系", "经济管理系", "食品工程系", "机械工程系", "商务外语系", "建筑工程系" };
            getButtomTag = BuildButtomTag(AllDepartment);
            getClassName = "new Array('缺勤人数','缺勤率')";
            //获取缺勤人数，传入时间，返回各系总缺勤人数，缺勤率
            DataTable dt = DataAnalysis.GetDataAndCreateChartBySum(Convert.ToInt32(Session["CurrentWeek"]), Convert.ToInt32(Session["CurrentWeek"]));
            string[] dataname1 = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataname1[i] = dt.Rows[i]["Sum"].ToString();
            }
            getDataName1 = BuildButtomTag(dataname1);
            string[] dataname2 = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataname2[i] = dt.Rows[i]["SumRate"].ToString().TrimEnd('%');
            }
            getDataName2 = BuildButtomTag(dataname2);
            //getDataName2 = "new Array(" + dt.Rows[0]["SumRate"] + "," + dt.Rows[1]["SumRate"] + "," + dt.Rows[2]["SumRate"] + "," + dt.Rows[3]["SumRate"] + "," + dt.Rows[4]["SumRate"] + "," + dt.Rows[5]["SumRate"] + "," + dt.Rows[6]["SumRate"] + ")";
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}
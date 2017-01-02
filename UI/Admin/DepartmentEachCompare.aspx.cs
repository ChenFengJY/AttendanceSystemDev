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
    public string getDataName1 = "new Array()";//缺勤人数
    public string getDataName2 = "new Array()";//缺勤率
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Session["CurrentWeek"] = 17;//调试用
            InitDropList(DropDownList1, Convert.ToInt32(Session["CurrentWeek"]));

            string[] AllDepartment = { "会计系", "信息工程系", "经济管理系", "食品工程系", "机械工程系", "商务外语系", "建筑工程系" };
            getButtomTag = BuildButtomTag(AllDepartment);
            getClassName = "new Array('缺勤人数','缺勤率')";

            //获取缺勤人数，传入时间，返回各系总缺勤人数，缺勤率
            DataTable dt = DataAnalysis.GetDataAndCreateChartBySum(1,Convert.ToInt32(Session["CurrentWeek"]));

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

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

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
    
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string[] AllDepartment = { "会计系", "信息工程系", "经济管理系", "食品工程系", "机械工程系", "商务外语系", "建筑工程系" };

        if (e.CommandName == "look")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            string item = row.Cells[0].Text;
            if (AllDepartment.Contains<string>(item.Trim()))
            {
                //Response.Redirect("");
            }
        }
    }

    /// <summary>
    /// 初始化DropDownList值
    /// </summary>
    /// <param name="ddl"></param>
    /// <param name="week"></param>
    private static void InitDropList(DropDownList ddl,int week)
    {
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("开学至今"));
        ddl.Items[0].Selected = true;
        for(int i = 1; i <= week; i++)
        {
            ddl.Items.Add(new ListItem("第 "+i + " 周"));
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string[] AllDepartment = { "会计系", "信息工程系", "经济管理系", "食品工程系", "机械工程系", "商务外语系", "建筑工程系" };
        getButtomTag = BuildButtomTag(AllDepartment);
        getClassName = "new Array('缺勤人数','缺勤率')";
        if (DropDownList1.SelectedItem.Text== "开学至今")
        {
            //开学至今
            
            //获取缺勤人数，传入时间，返回各系总缺勤人数，缺勤率
            DataTable dt = DataAnalysis.GetDataAndCreateChartBySum(1,Convert.ToInt32(Session["CurrentWeek"]));

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

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
        {
            //单个周次
            string dropSele = DropDownList1.SelectedItem.Text;
            int selectWeek = Convert.ToInt32(dropSele.Length==5?(dropSele.Substring(2, 1)):dropSele.Substring(2,2));//获取选择的周

            //获取缺勤人数，传入时间，返回各系总缺勤人数，缺勤率
            DataTable dt = DataAnalysis.GetDataAndCreateChartBySum(selectWeek,selectWeek);//

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

            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
    }
}
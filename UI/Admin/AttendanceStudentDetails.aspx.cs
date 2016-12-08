﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;


public partial class Admin_AttendanceStudentDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"].ToString() == "")
            {
                Response.Redirect ("~//Default.aspx");
            }
            else
            {
                Label1.Text = Server.UrlDecode(Request.QueryString["queryDepartment"]).ToString() + "第" + Request.QueryString["queryWeek"].ToString() + "周旷课名单:";
                GetDataTable();
            }
        }
    }

    private void GetDataTable()
    {
        string queryDepartment = Server.UrlDecode(Request.QueryString["queryDepartment"]).ToString();
        string queryWeek = Request.QueryString["queryWeek"].ToString();
        DataTable dt = AddSQLStringToDAL.GetDatatableBySQL("TabStudentAttendance", "StudentDepartment", DisinfectionOperation.ReplaceSensiiveStr(queryDepartment), "CurrentWeek", DisinfectionOperation.ReplaceSensitiveStr(queryWeek));
        dt.Columns.Add(new DataColumn("SumAttendance", typeof(int)));
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            int zz = dt.Rows[i]["Course"].ToString().Length;
            dt.Rows[i]["Course"] = dt.Rows[i]["Course"].ToString().Substring(8, zz - 11);
            int zzCount = AddSQLStringToDAL.GetRecordCount("TabStudentAttendance", "StudentID", dt.Rows[i]["StudentID"].ToString());
            dt.Rows[i]["SumAttendance"] = zzCount;
        }
        gvStudentAttendance.DataSource = dt;
        gvStudentAttendance.DataBind();
}
    protected void btnBackDetails_Click(object sender, EventArgs e) {
        ClientScript.RegisterStartupScript(Page.GetType(), "", "<script language=javascript>window.opener=null;window.open('_self');window.close();</script>");
    }
}
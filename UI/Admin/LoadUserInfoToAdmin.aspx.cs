using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Data;
using System.Configuration;
using System.Collections;


using BLL;

public partial class Admin_LoadUserInfoToAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"].ToString() == "")
            {
                Response.Redirect("~//Deefault.aspx");
            }
            else {
                DataTable dt = BLL.AddSQLStringToDAL.GetDatatableBySQL("TabTeacher");
                GridView2.DataSource = dt;
                GridView2.DataBind();
                Lable7.Visible = false;
                txtLimit.Visible = false;
                BindToGridView(dt);
                    }
        }
    }
    protected void Bind()
    {
        if (ddlLimit.SelectedIndex.ToString()=="所有记录")
        {
            DataTable dt = BLL.AddSQLStringToDAL.GetDatatableBySQL("TabTeachers");
        
            BindToGridView(dt);
        }
        else if (ddlLimit.SelectedIndex.ToString()!="所有记录"&&txtLimit.Text!="")

        {  
            //DataTable dt = BLL.AddSQLStringToDAL.GetDatatableBySQL("TabTeachers",DropDownListTransform.DDLToString(ddlLimit.SelectedIndex.ToString()),txtLimit.Text.Trim());
            //BindToGridView(dt);
        }
    }

    protected void gvTeachers_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void gvTeachers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTeachers.PageIndex = e.NewPageIndex;
        Bind();
        
    }
    protected void ddlLimit_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
    {
        if (ddlLimit.SelectedIndex.ToString() == "所有记录")
        {
            Lable7.Visible = false;
            txtLimit.Visible = false;

        }
        else
        {
            Lable7.Visible = true;
            txtLimit.Visible = true;
        }
    }

    protected void gvTeachers_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvTeachers.EditIndex = e.NewEditIndex;
        Bind();

    }

    protected void gvTeachers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (AddSQLStringToDAL.DeleteTabTeachers("TabTeachers","UserID",gvTeachers.DataKeys[e.RowIndex].Value.ToString()))
        {
            Bind();
        }
    }

    protected void gvTeachers_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strUserRole = ((TextBox)(gvTeachers.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim();
        string strUserID = gvTeachers.DataKeys[e.RowIndex].Value.ToString();
        //if (AddSQLStringToDAL.UpdataTabTeachers("TabTeachers","Role",strUserRole,"UserID",strUserID))

        //{
        //    gvTeachers.EditIndex = -1;
        //    Bind();

        //}
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        Bind();
    }
    protected void BindToGridView(DataTable dt)
    {
        gvTeachers.DataSource = dt;
        gvTeachers.DataKeyNames = new string[] { "UserID" };
        gvTeachers.DataBind();
    }
}
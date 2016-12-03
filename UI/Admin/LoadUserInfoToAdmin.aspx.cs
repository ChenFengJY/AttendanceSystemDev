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
            //if (Session["UserID"].ToString() == "")
            //{
            //    //Response.Redirect("~//Login.aspx");
            //}
            //else
            {
                string strSql = "select * from TabTeachers";
                BindToGridView(strSql);
                Lable7.Visible = false;
                txtLimit.Visible = false;
            }
        }
    }
    protected void Bind()
    {
        if (ddlLimit.SelectedIndex.ToString() != "所有记录" && txtLimit.Text != "")
        {
            string strSql2 = "select * from TabTeachers where " + DropDownListOption() + " = " + txtLimit.Text.Trim() + " ";
            BindToGridView(strSql2);
        }
        else
        {
            string strSql1 = "select * from TabTeachers";
            BindToGridView(strSql1);
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


    protected void gvTeachers_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvTeachers.EditIndex = e.NewEditIndex;
        Bind();

    }

    protected void gvTeachers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (AddSQLStringToDAL.DeleteTabTeachers("TabTeachers", "UserID", gvTeachers.DataKeys[e.RowIndex].Value.ToString()))
        {
            Bind();
        }
    }

    protected void gvTeachers_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strUserRole = ((TextBox)(gvTeachers.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim();
        string strUserID = gvTeachers.DataKeys[e.RowIndex].Value.ToString();
        //if (AddSQLStringToDAL.UpdataTabTeachers("TabTeachers", "Role", strUserRole, "UserID", strUserID))

        //{
        //    gvTeachers.EditIndex = -1;
        //    Bind();

        //}
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        Bind();
    }
    protected void BindToGridView(string strSql)
    {
        
        DataTable dt = AddSQLStringToDAL.GetDtBySQL(strSql);
        gvTeachers.DataSource = dt;
        gvTeachers.DataKeyNames = new string[] { "UserID" };
        gvTeachers.DataBind();
    }


    /// <summary>
    /// ddlLimit选项更改后执行事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlLimit_SelectedIndexChanged(object sender, EventArgs e)
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

    private string DropDownListOption()
    {
        string ddlswitch = "";
        switch (ddlLimit.SelectedIndex.ToString().Trim())
        {
            case "按部门查询":
                {
                    ddlswitch = "Department";
                    break;
                }
            case "按教师工号查询":
                {
                    ddlswitch = "UserID";
                    break;
                }
            case "按教师姓名查询":
                {
                    ddlswitch = "UserName";
                    break;
                }
            case "按权限查询":
                {
                    ddlswitch = "Role";
                    break;
                }
            default:
                {
                    ddlswitch = "1=1 or 1";
                    break;
                }
        }
        return ddlswitch;
    }
    /// <summary>
    /// 点击编辑时，取消后触发事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvTeachers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }
}
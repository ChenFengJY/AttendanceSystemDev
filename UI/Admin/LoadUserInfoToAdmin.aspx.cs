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
        //首先判断是否是数据行
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //当鼠标停留时更改背景色
            e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#00A9FF'");
            //当鼠标移开时还原背景色
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
        }
        //删除时弹出确认对话框
        //如果是绑定数据行
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[6].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：" + e.Row.Cells[2].Text + "吗?')");
            }
        }
    }
    //控制分页
    protected void gvTeachers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTeachers.PageIndex = e.NewPageIndex;
        Bind();

    }

    //编辑时发生
    protected void gvTeachers_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //获取编辑前权限的值
        string lab = ((Label)gvTeachers.Rows[e.NewEditIndex].Cells[4].FindControl("LabTeacherRole")).Text;
        gvTeachers.EditIndex = e.NewEditIndex;
        
        Bind();
        //下拉列表的默认值更改为编辑前的值
        DropDownList ddlSex = (DropDownList)gvTeachers.Rows[e.NewEditIndex].Cells[4].FindControl("ddlTeacherRole");
        ddlSex.SelectedIndex = ddlSex.Items.IndexOf(ddlSex.Items.FindByValue(lab));
    }
    //删除
    protected void gvTeachers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strSql = "delete from TabTeachers where UserID='" + gvTeachers.DataKeys[e.RowIndex].Value.ToString() + "'";

        AddSQLStringToDAL.InsertData(strSql);
        Bind();
    }
    //更改后提交发生
    protected void gvTeachers_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DropDownList ddlSex = (DropDownList)gvTeachers.Rows[e.RowIndex].Cells[4].FindControl("ddlTeacherRole");
        int strUserRole = Convert.ToInt32(ddlSex.SelectedValue);
        //string strUserRole = ((DropDownList)(gvTeachers.Rows[e.RowIndex].Cells[4].Controls[0])).SelectedItem.Text.ToString().Trim();//用户权限
        string strUserID = gvTeachers.DataKeys[e.RowIndex].Value.ToString();
        string strSql = "update TabTeachers set Role = " + strUserRole + " where UserID = '" + strUserID + "' ";

        AddSQLStringToDAL.InsertData(strSql);
        gvTeachers.EditIndex = -1;
        Bind();
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        Bind();
    }
    protected void BindToGridView(string strSql)
    {
        
        DataTable dt = AddSQLStringToDAL.GetDtBySQL(strSql);
        //dt.DefaultView.Sort = 
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
        gvTeachers.EditIndex = -1;
        Bind();
    }
}
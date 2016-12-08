using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;
using System.Web.Security;
using System.Collections;
using System.Configuration;
using System.Text.RegularExpressions;

public partial class Admin_AddNewTeacher : System.Web.UI.Page
{
    public object DisinfectionOperation { get; private set; }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"].ToString() != "")
            {

            }
            else
            {
                //Response.Redirect("~//Login.aspx");
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
    private void Clear()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
    }

    protected void btnOK_Click1(object sender, EventArgs e)
    {
        if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "")
        {
            string sql = "select * from TabTeachers where UserId = '" + TextBox1.Text.Trim() + "' ";
            string teacherType = "";
            string teacherRole = "";
            switch (ddlType.SelectedItem.ToString().Trim())
            {
                case "本校教师":
                    teacherType = "TabTeachers";
                    break;
                case "外聘教师":
                    teacherType = "TabOtherTeachers";
                    break;
                default:
                    break;
            }
            switch (Convert.ToInt32(ddlDepartmentName.SelectedIndex))
            {
                case 0:
                    teacherRole = "4";
                    break;
                case 1:
                    teacherRole = "3";
                    break;
                case 2:
                    teacherRole = "2";
                    break;
                case 3:
                    teacherRole = "1";
                    break;
                default:
                    break;
            }
            try

            {
                string strSql = "insert into " + teacherType + "(Department,UserID,UserPWD,UserName) values ('" + ddlDepartmentName.SelectedItem + "','" + TextBox1.Text + "','" + TextBox3.Text + "','" + TextBox2.Text + "')";
                DataTable dt = AddSQLStringToDAL.GetDtBySQL(sql);

                Regex reg = new Regex("[0-9]{10}"); //判断是不是数据，要不是就表示没有选择，则从隐藏域里读出来
                Match ma = reg.Match(TextBox1.Text.Trim());
                if (ma.Success)
                {
                    //是数字时的操作

                    if (dt.Rows.Count == 0)
                    {
                        if (TextBox3.Text.Trim().Length >= 6 && TextBox3.Text.Trim().Length <= 16)
                        {
                            if (AddSQLStringToDAL.InsertData(strSql))
                            {
                                Clear();
                                Response.Write("<script type='text/javascript'>alert('添加成功')</script>");
                            }
                            else
                            {
                                Response.Write("<script type='text/javascript'>alert('添加失败')</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script type='text/javascript'>alert('请输入密码')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script type='text/javascript'>alert('已存在该教师')</script>");
                    }
                }

                else
                {
                    Response.Write("<script type='text/javascript'>alert('教师工号须10位数字')</script>");
                }
            }
            catch
            {
                Clear();
                Response.Write("<script type='text/javascript'>alert('输入有误！请核对教师工号等信息！教师工号不能重复！')</script>");
            }

        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('输入有误！请核对教师工号等信息！教师工号不能重复！')</script>");
        }
    }
}


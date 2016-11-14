using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using BLL;
using System.Web.Security;
using System.Collections;
using System.Configuration;


public partial class Admin_AddNewTeacher : System.Web.UI.Page
{
    public object DisinfectionOperation { get; private set; }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"].ToString() != "")
            {

                Bind();
            }
            else
            {
                //Response.Redirect("~//Login.aspx");
            }
        }
    }
        protected void Bind()
    {
        List<string> str = new List<string>();
        str = AddSQLStringToDAL.GetDistinctString("TabTeachers", "Department");
        for (int i=0;i<str.Count;i++)
        {
            DropDownList1.Items.Add(str[i].ToString());
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
    private void Clear()
    {
        Label3.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
    }


  

  
    protected void btnOK_Click1(object sender, EventArgs e)
    {
        string teacherType = "";
        string teacherRole = "";
        switch (DropDownList2.SelectedItem.ToString())
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
        switch (Convert.ToInt32(DropDownList2.SelectedIndex))
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
            if (AddSQLStringToDAL.InsertTabTeachers(teacherType,DisinfectionOperation.ReplaceSensitiveStr(DropDownList1.SelectedItem.ToString()),DisinfectionOperation.ReplaceSensitiveStr(TextBox1.Text.Trim()),PWDProcess.MD5Encrypt(TextBox2.Text.Trim(),PWDProcess.CreatKey(TextBox3.Text.Trim())),DisinfectionOperation.ReplaceSensitiveStr(TextBox3.Text.Trim()),"",teacherRole))
            {
                Clear();
                Label3.Text = "添加成功!";
            }
        }
        catch
        {
            Clear();
            Label3.Text = "输入有误！请核对教师工号等信息！教师工号不能重复！";
        }
    }

}


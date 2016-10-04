using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

public partial class LoginSystem_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string strSql = "select * from TabTeachers where UserID=" + TextBox1.Text + "";
        DataTable dt = AddSQLStringToDAL.SetData(strSql);  
        if (dt.Rows.Count == 1)
        {
            if (dt.Rows[0][3].ToString() == TextBox2.Text)
            {
                TextBox3.Text = "登录成功";
            }
        }
    }
}
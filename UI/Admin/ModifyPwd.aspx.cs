using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_ModifyPwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label6.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string strConn = "data source=192.168.53.110;initial catalog=xgmm;uid=15soft03;password=1267;";
        if (TextBox1.Text == teaId) { 
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string strSQL = "update Teacher set teaPwd='" + TextBox3.Text + "'where teaPwd ='" + TextBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Label6.Visible = true;
            Label6.Text = "您的新密码设置成功";
        }
        else {
            Label6.Visible = true;
            Label6.Text = "您的用户名或者密码不正确 ！";
        }
    }
}
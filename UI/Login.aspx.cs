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
        // Button1.Attributes.Add("onclick", "validate()");
        string strSQL = "select * from TabTeachers where UserID =" + userName.Text.Trim() + " and UserPWD=" + password.Text.ToString() + "";
        DataTable dt;
        if (userName.Text != "" && password.Text != "")
        {
            dt = AddSQLStringToDAL.GetDtBySQL(strSQL);
            if (dt.Rows.Count == 1)
            {
                string Role = dt.Rows[0]["Role"].ToString();
                switch (Role)
                {
                    case "1":
                        Response.Redirect("Admin\\AdminSubmitAttendance.aspx");
                        break;
                    case "2":
                        Response.Redirect("Admin\\DepartmentEachCompare.aspx");
                        break;
                    case "3":
                        Response.Redirect("Admin\\.aspx");
                        break;
                    case "4":
                        Response.Redirect("Admin\\.aspx");
                        break;
                }

            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('用户名或密码错误')</script>");
            }
        }
        else Response.Write("<script type='text/javascript'>alert('请完善用户信息')</script>");

    }

}
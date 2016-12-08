using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;
using System.Data;

public partial class LoginSystem_Login : System.Web.UI.Page
{
    public object TextBox1 { get; private set; }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UserName"]="";
        Session["UserID"]="";
        Session["CurrentWeek"]="";
        Session["CurrentCourse"]="";
        Session["Week"]="";
        Session["Time"]= "";
        Session["WeekRange"]= "";
        Session["Role"]= "";
        Session["CurrentWeek"]="";
        CurrentWeek();
    }
    //判断当前周次
    private void CurrentWeek()
    {
        DataTable dt = AddSQLStringToDAL.GetDatatableBySQL("TabCalendar");
        foreach (DataRow row in dt.Rows)
        {
            if (Convert.ToDateTime(row["StartWeek"]) < DateTime.Now && Convert.ToDateTime(row["EndWeek"]) > DateTime.Now)
            {
                string strWeekNumber = row["WeekNumber"].ToString();
                Session["CurrentWeek"] = strWeekNumber;
                break;
            }
            else
            {
                Session["CurrentWeek"] = "0";//不满足所有周次，显示为0；
            }
        }
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
                Session["UserID"] = dt.Rows[0]["UserID"].ToString();
                Session["UserName"] = dt.Rows[0]["UserName"].ToString();
                Session["Role"] = dt.Rows[0]["Role"].ToString();
                switch (Role)
                {
                    case "1":
                        Response.Redirect("Admin\\AdminSubmitAttendance.aspx");
                        break;
                    case "2":
                        Response.Redirect("Leader\\DepartmentEachCompare.aspx");
                        break;
                    case "3":
                        Response.Redirect("Secretary\\TeacherSubmitAttendance.aspx");
                        break;
                    case "4":
                        Response.Redirect("Teacher\\GetMessage.aspx");
                        break;
                    default:
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;
using BLL;

public partial class Admin_SendMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Role"].ToString() != "系统管理员")
                Response.Redirect("~~Default.aspx"); 
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string item1 = "全校教师";
        string item2 = "所有系部教师";
        List<string> strSum = new List<string>();
        List<string> strID1 = new List<string>();
        List<string> strID2 = new List<string>();
        List<string> strID3 = new List<string>();
        List<string> strID4 = new List<string>();
        List<string> strID5 = new List<string>();
        if (item1==DropDownList1.SelectedItem.Text)  {
            strID1 = AddSQLStringToDAL.GetDistinctString("TabAllCourses", "TeacherID");

        }
        if (item2 == DropDownList1.SelectedItem.Text) {
            strID2= AddSQLStringToDAL.GetDistinctString("TabAllCourses", "TeacherID");
        }
        strSum.AddRange(strID1);
        strSum.AddRange(strID2);
        for (int i = 0; i < strSum.Count; i++)
        {
            for (int j = 0; j < strSum.Count; j++) {
               if( i!=j)
                    {
                    if (strSum[i] ==strSum[j])
                        strSum.RemoveAt(j);
                }
            }
        }
        if(strSum.Count>0)
        {
            for (int i = 0; i < strSum.Count; i++)
            {
                if (AddSQLStringToDAL.InsertTabTeachers("TabMessage", "System.DataTime.Now.ToString()", "txtMessage.Text", "strSum[i].ToString()", "false", "", ""))
                {
                }
            }
            Label3.Text = "信息发送成功";
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections;
using System.Data;
using System.Configuration;
using BLL;

public partial class Admin_SendMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    if (Session["Role"].ToString() != "1")
        //    {
        //        Response.Redirect("Default.aspx");
        //    }
        //}
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        if (TextBox1.Text.Equals(""))
            return;
        List<string> strSum = new List<string>();
        List<string> strID1 = new List<string>();
        List<string> strID2 = new List<string>();
        List<string> strID3 = new List<string>();
        List<string> strID4 = new List<string>();

        if (CheckBox1.Checked == true)
        {
            strID1 = AddSQLStringToDAL.GetDistinctString("TabTeachers", "UserID", "Role", "2");
        }
        if (CheckBox2.Checked == true)
        {
            strID2 = AddSQLStringToDAL.GetDistinctString("TabTeachers", "UserID", "Role", "3");
        }
        if (CheckBox3.Checked == true)
        {
            strID3 = AddSQLStringToDAL.GetDistinctString("TabTeachers", "UserID", "Role", "4");
        }
        strSum.AddRange(strID1);
        strSum.AddRange(strID2);
        strSum.AddRange(strID3);

        for (int i = 0; i < strSum.Count; i++)
        {
            for (int j = 0; j < strSum.Count; j++)
            {
                if (i != j)
                {
                    if (strSum[i] == strSum[j])
                    {
                        strSum.RemoveAt(j);
                    }
                }
            }
        }
        if (strSum.Count > 0)
        {
            for (int i = 0; i < strSum.Count; i++)
            {
                if (AddSQLStringToDAL.InsertData("insert into TabMessage([Message],[UserID],[MessageStatus]) values('" + TextBox1.Text + "','" + strSum[i] + "','" + false + "')"))
                {
                    Label6.Text = "信息发送成功！";
                }
                else
                {
                    Label6.Text = "信息发送失败！";
                }
            }
            TextBox1.Text = "";
        }
        else
        {
            Label6.Text = "没有选择发送单位";
        }
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}
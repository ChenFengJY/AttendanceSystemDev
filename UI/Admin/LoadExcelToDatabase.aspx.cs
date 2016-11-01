using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;
public partial class Admin_LoadExcelToDatabase : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(Session["UserID"].ToString()=="")
            {
                Response.Redirect("~//Default.aspx");

            }
            else
            {
                
            }
        }

    }
    protected void BtnImportTeachers_Click(object sender,EventArgs e)
    {
        

    }
}
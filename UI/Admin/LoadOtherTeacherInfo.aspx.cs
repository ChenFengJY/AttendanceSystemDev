using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using BLL;
using System.Web.UI.WebControls.WebParts;

public partial class Admin_LoadOtherTeacherInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack){
            if (Session["UserID"].ToString()=="")
            {
                Response.Redirect("//Default.aspx");
            }
            else {
            }
        }

    }
}
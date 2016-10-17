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


public partial class Admin_AddNewTeacher : System.Web.UI.Page
{
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
                Response.Redirect("~//Default.aspx");
            }
        }
    }
        protected void Bind()
    {
        List<string> str = new List<string>();
        str = AddSQLStringToDAL.GetDistinctString("TabTeachers", "Department");
        for (int i=0;i<str.Count;i++)
        {
            
            
        }
        
    }
        
    }


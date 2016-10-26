using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class Admin_LoadExcelToDatabase : System.Web.UI.Page
{
    string currFilePath = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string fileExt = string.Empty;//文件后缀
        
        if (FileUpload_xls.HasFile)//返回是否包含文件（是否选择）
        {
            fileExt = System.IO.Path.GetExtension(FileUpload_xls.FileName);//获取文件后缀
            
            if (fileExt == ".xls" || fileExt == ".xlsx")
            {
                DateTime time = DateTime.Now;
                string a = time.Year.ToString() + time.Month.ToString() + time.Day.ToString() + time.Hour.ToString() + time.Minute.ToString() + time.Second.ToString();
                
                try
                {
                    string newfileName = a + fileExt;
                    this.currFilePath = Server.MapPath("../") + "file\\" +newfileName;//服务器路径
                    FileUpload_xls.SaveAs(this.currFilePath);//上传

                    string eee = ExcelToSql.SetExcel(ReadExcelToTable(currFilePath));
                     
                    //Response.Write("<script>alert('"+ ReadExcelToTable(currFilePath).Columns[0].ColumnName + "')</script>");
                    Response.Write("<script>alert('"+eee+"')</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('发生错误：'"+ ex.Message.ToString() + ")</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('只允许上传xls、xlsx文件！')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('没有选择要上传的文件！')</script>");
        }

        
    }
    /// <summary>
    /// 将上传的excel表生成DataTable表
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns>excel表生成的dt</returns>
    private DataTable ReadExcelToTable(string filePath)
    {
        string connstring = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=Excel 8.0;";
        using(OleDbConnection conn = new OleDbConnection(connstring))
        {
            conn.Open();
            DataTable sheetsName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
            string firstSheetName = sheetsName.Rows[0][2].ToString();
            string sql = string.Format("select * from [{0}]", firstSheetName);
            OleDbDataAdapter ada = new OleDbDataAdapter(sql, connstring);
            DataSet set = new DataSet();
            ada.Fill(set);
            return set.Tables[0];

        }
        
    }

}
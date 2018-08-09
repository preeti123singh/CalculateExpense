using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Data.SQLite;

public partial class Expense : System.Web.UI.Page
{
    public SqlConnection connection;
  
   

    protected void Page_Load(object sender, EventArgs e)
    {
        connection = (SqlConnection)Session["connection"];
        if (!Page.IsPostBack)
        {
            PopulateDropdown();
        }
    }

    public void PopulateDropdown()
    {
        var value = Session["Value"];
        
        
        if (value != null)
        {
            string query;
            query = "insert into tbl_payments (Payment) values('" + value + "')" ;
            SqlCommand sqlcmd = new SqlCommand(query, connection);
            SqlDataReader MyReader2;
            connection.Open();
            MyReader2 = sqlcmd.ExecuteReader();
            connection.Close();
        }
            string query1;
            DataSet ds = new DataSet();
            connection.Open();
            query1 = "select distinct(payment) from tbl_payments";
            SqlCommand sqlcmd1 = new SqlCommand(query1, connection);
            SqlDataAdapter da1 = new SqlDataAdapter(sqlcmd1);
            da1.Fill(ds);
          
            dropdownlist.DataSource= ds.Tables[0];
            dropdownlist.DataTextField = "Payment";
          
            dropdownlist.DataBind();
            connection.Close();
    }

    
   
    string Filename;
    public string GetPhotos() {
        string Images = "";
        //string ext="";
        string ext = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName).ToLower();
        if (ViewState["Filename"]!=null)
        { string extension = ViewState["Filename"].ToString();
            ext = "."+ extension.Substring(extension.LastIndexOf(".") + 1).ToLower();
        }
       
        if (ext == ".jpg" || ext == ".png" || ext == ".gif" || ext == ".jpeg")
        {
            if (FileUpload1.HasFile)
            {
                Filename = FileUpload1.FileName.Replace(" ", "");
                FileUpload1.PostedFile.SaveAs(Server.MapPath(("~/Upload/" + Filename)));
                Images = "/Upload/" + Filename.ToString();
            }
            else
            {
                if (ViewState["File"] != null)
                {
                    Images = ViewState["File"].ToString();
                    Filename = ViewState["Filename"].ToString();
                }
                else
                {
                    Images = "/Upload/download.jpg";
                    Filename = "download.jpg";
                }
            }
        }
        else
        {
            Images = "/Upload/download.jpg";
            Filename = "download.jpg";
            lbl_image.Text = "Please upload image with .jpg,.jpeg,.png,.gif extensions.";
            lbl_image.ForeColor = System.Drawing.Color.Red;
        }
        return (Images);
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet("Expense");
          
            SqlCommand sqlcom = new SqlCommand("MasterInsertUpdateDelete", connection);
         
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Parameters.AddWithValue("@Money", txt_Money.Text);
            sqlcom.Parameters.AddWithValue("@Payment", dropdownlist.SelectedItem.Text);
            sqlcom.Parameters.AddWithValue("@Comment", txt_Comment.Text);
            sqlcom.Parameters.AddWithValue("@Description", txt_Description.Text);
            sqlcom.Parameters.AddWithValue("@Image", GetPhotos());
            sqlcom.Parameters.AddWithValue("@date", DateTime.Parse(TextBox1.Text));
            sqlcom.Parameters.AddWithValue("@Filename", Filename);
            sqlcom.Parameters.AddWithValue("@StatementType", "Insert");
            SqlDataAdapter da = new SqlDataAdapter(sqlcom);
            da.Fill(ds);
                               
            ClientScript.RegisterStartupScript( this.GetType(),"Alert", "alert('Data Submitted Sucessfully!')", true);
            Response.Redirect("Display.aspx");
        }
        catch(Exception es)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(),
                "MessageBox", "alert('" + es.Message + "');", true);
        }
    }


    protected void btn_reports_Click(object sender, EventArgs e)
    {
       
        Response.Redirect("~\\Report.aspx");
    }

    protected void btn_upload_Click(object sender, EventArgs e)
    {
        Image1.ImageUrl= GetPhotos();
        ViewState["File"] = Image1.ImageUrl;
        int pos = Image1.ImageUrl.LastIndexOf("/") + 1;
        Image1.ImageUrl.Substring(pos, Image1.ImageUrl.Length - pos);
        ViewState["Filename"]= Image1.ImageUrl.Substring(pos, Image1.ImageUrl.Length - pos);
    }


    protected void btnHidden_Click(object sender, EventArgs e)
    {
        PopulateDropdown();
    }

    protected void btn_payment_Click(object sender, EventArgs e)
    {
        string popupScript = "<script language='javascript'>" +
                           "window.open('Payment.aspx', 'ThisPopUp', " +
                           "'left = 300, top=150, width=400, height=300, " +
                           "menubar=no, scrollbars=no, resizable=no')" +
                           "</script>";
        Page.ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
    }

    
}
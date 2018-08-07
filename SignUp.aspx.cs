using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class SignUp : System.Web.UI.Page
{
    public SqlConnection con;
    public SqlDataAdapter adp;
    public DataSet ds;
    private static DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        con = (SqlConnection)Session["connection"];
    }


    protected void btn_submit_Click(object sender, EventArgs e)
    {

    }
}
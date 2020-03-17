using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = null;
        SqlDataAdapter adp = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlCon"].ToString());
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            adp = new SqlDataAdapter("sp_Login", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.AddWithValue("@userid", txtuserid.Text);
            adp.SelectCommand.Parameters.AddWithValue("@pwd", txtpwd.Text);       

            DataSet ds = new DataSet();
            adp.Fill(ds, "L");
            try
            {
                DataRow r = ds.Tables["L"].Rows[0];

                if (r[3].ToString() == "admin")
                {
                   
                    //creating cookie variable
                    Response.Cookies["username"].Value = r[1].ToString();
                    Response.Redirect("Admin.aspx");
                   
                }
                else if (r[3].ToString() == "associate")
                {
                    
                    //creating cookie variable
                    Response.Cookies["username"].Value = r[1].ToString();
                    Response.Redirect("Associate.aspx");

                }


            }
            catch(IndexOutOfRangeException E)
            {
                lblmessage.Text = "Invalid Credentials";
                txtuserid.Text = "";
                txtpwd.Text = "";
                txtuserid.Focus();
            }

    }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Master3 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["username"] == null)
                Response.Redirect("Login.aspx");
            else
                Label1.Text = "Welcome " + Request.Cookies["username"].Value;
        }
    }
}
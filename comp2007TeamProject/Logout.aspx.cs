using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//required for identity and owin
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
/**
 * Authors: Nathan Siu and Mike Meissner
 * File Description: Code behind file for logout page
 * */

namespace comp2007TeamProject
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //store session info and authentication methods in the authenticationManager object
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            //sign out
            authenticationManager.SignOut();
            Response.Redirect("~/Login.aspx");

        }
    }
}
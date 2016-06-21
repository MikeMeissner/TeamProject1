﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//required for identity and owin
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace comp2007TeamProject
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            //create new userStore and userManager Objects
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            //search for and create a new user object
            var user = userManager.Find(UserNameTextBox.Text, PasswordTextBox.Text);
            //if match is found for user
            if(user !=null)
            {
                //authenticate and sign in the user
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                //sign in
                authenticationManager.SignIn(new AuthenticationProperties() {IsPersistent= false }, userIdentity);

                //redirect to featured games
                Response.Redirect("~/Calendar.aspx");
            }
            else
            {
                //throw an error to the alertflsah div
                StatusLabel.Text = "Invalid username or password";
                AlertFlash.Visible = true;
            }
        }
    }
}
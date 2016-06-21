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

namespace comp2007TeamProject
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //redirect to homepage
            Response.Redirect("~/Default.aspx");

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            //create new userStore and userManager Objects
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            //create new user object
            var user = new IdentityUser()
            {
                UserName = UserNameTextBox.Text,
                PhoneNumber = PhoneNumberTextBox.Text,
                Email = EmailTextBox.Text

            };
            //create new user object in the db and store the result 
            IdentityResult result = userManager.Create(user,PasswordTextBox.Text);

            //check registered
            if(result.Succeeded)

            {
                //authenticate and login our new user
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                //sign in
                authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);

                //redirect to featured games
                Response.Redirect("~/Calendar.aspx");
            }

            else
            {
                //display error in teh AlertFlash Div
                StatusLabel.Text = result.Errors.FirstOrDefault();
                AlertFlash.Visible = true;

            }
        }
    }
}
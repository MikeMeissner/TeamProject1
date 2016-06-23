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
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetActivePage();
            if(!IsPostBack)
            {
                //check if a user is logged in
                if(HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    PublicPlaceHolder.Visible = false;
                    LogoutPlaceHolder.Visible = true;
                }
                else
                {
                    LogoutPlaceHolder.Visible = false;
                }
            }
        }

        private void SetActivePage()
        {
            switch (Page.Title)
            {
                case "Home":
                    home.Attributes.Add("class", "active");
                    break;
                case "Calendar":
                    calendar.Attributes.Add("class", "active");
                    break;
                case "Login":
                    login.Attributes.Add("class", "active");
                    break;
                case "Register":
                    register.Attributes.Add("class", "active");
                    break;
                case "UserProfile":
                    userProfile.Attributes.Add("class", "active");
                    break;
               

            }
        }
    }
}
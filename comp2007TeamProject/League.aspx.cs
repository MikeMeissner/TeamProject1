using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using comp2007TeamProject.Models;
using System.Web.ModelBinding;

namespace comp2007TeamProject
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the page is loading for the first time, populate the grid
            if (!IsPostBack)
            {

                //get csgo data
                this.GetLeagueData();


            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {

        }
        protected void GetLeagueData()
        {
            //connect to EF
            using (GameTrackerConnection db = new GameTrackerConnection())
            {
                //query the csgo table
                var League = (from allData in db.Leagues
                            select allData);

                //bind results to the gridview
                LeagueGridView.DataSource = League.ToList();
                LeagueGridView.DataBind();
            }
        }

        protected void LeagueGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int selectedRow = e.RowIndex; // store which row was called
            int gameID = Convert.ToInt32(LeagueGridView.DataKeys[selectedRow].Values["gameID"]);// get game ID

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //connect to db to remove row

                using (GameTrackerConnection db = new GameTrackerConnection())
                {
                    League removedGame = (from gameRecords in db.Leagues where gameRecords.gameID == gameID select gameRecords).FirstOrDefault();

                    db.Leagues.Remove(removedGame);

                    db.SaveChanges();

                    this.GetLeagueData();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}
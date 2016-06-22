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
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.getGameDetails();
            }
        }
        protected void getGameDetails()
        {
            // populate the form with existing data from the data base
            int gameID = Convert.ToInt32(Request.QueryString["gameID"]);

            //connect to db
            using (GameTrackerConnection db = new GameTrackerConnection())
            {
                Dota updatedDetails = (from gameRecords in db.Dotas where gameRecords.gameID == gameID select gameRecords).FirstOrDefault();

                //map the game properties to the form

                if (updatedDetails != null)
                {
                    Team1DotaTextBox.Text = updatedDetails.team1;
                    Team2DotaTextBox.Text = updatedDetails.team2;
                    KillsForTeam1TextBox.Text = updatedDetails.killsTeam1.ToString();
                    KillsForTeam2TextBox.Text = updatedDetails.killsTeam2.ToString();
                   ObjectivesForTeam1TextBox.Text = updatedDetails.objectivesTeam1.ToString();
                    ObjectivesForTeam2TextBox.Text = updatedDetails.objectivesTeam2.ToString();
                  
                    SpectatorsDotaTextBox.Text = updatedDetails.spectators.ToString();
                    WinnerDotaTextBox.Text = updatedDetails.winner;
                    //WeekTextBox.Text = updatedDetails.weekOfGame.ToString();

                }
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            using (GameTrackerConnection db = new GameTrackerConnection())
            {
                //creating new csgo object based on the model
                Dota dotaGameDetails = new Dota();


                int gameID = 0;

                if (Request.QueryString.Count > 0)// our url has a gameID in it
                {
                    gameID = Convert.ToInt32(Request.QueryString["gameID"]);

                    //get the current game from EF DB
                    dotaGameDetails = (from dota in db.Dotas where dota.gameID == gameID select dota).FirstOrDefault();


                }
                string week = weekNumber.Text;
                string[] weekArray = null;
                char[] splitChar = { 'W' };
                weekArray = week.Split(splitChar);
                string weekNum = weekArray[1];


                //add form data to the new game record
                dotaGameDetails.team1 = Team1DotaTextBox.Text;
                dotaGameDetails.team2 = Team2DotaTextBox.Text;
                dotaGameDetails.killsTeam1 = int.Parse(KillsForTeam1TextBox.Text);
                dotaGameDetails.killsTeam2 = int.Parse(KillsForTeam2TextBox.Text);
                dotaGameDetails.objectivesTeam1 = int.Parse(ObjectivesForTeam1TextBox.Text);
                dotaGameDetails.objectivesTeam2 = int.Parse(ObjectivesForTeam2TextBox.Text);
               
                dotaGameDetails.spectators = int.Parse(SpectatorsDotaTextBox.Text);
                dotaGameDetails.winner = WinnerDotaTextBox.Text;
               
                dotaGameDetails.weekOfGame = int.Parse(weekNum);

                //use LINQ to ADO.NET to insert record to DB
                if (gameID == 0)
                {
                    db.Dotas.Add(dotaGameDetails);
                }


                //save all changes in the DB
                db.SaveChanges();

                //redirect to dota stats page
                Response.Redirect("~/Dota.aspx");
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dota.aspx");
        }
    }
}
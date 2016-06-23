using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using comp2007TeamProject.Models;
using System.Web.ModelBinding;

/**
 * Authors: Nathan Siu and Mike Meissner
 * File Description: Code behind file for the League details page
 * */
namespace comp2007TeamProject
{
    public partial class WebForm7 : System.Web.UI.Page
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
                League updatedDetails = (from gameRecords in db.Leagues where gameRecords.gameID == gameID select gameRecords).FirstOrDefault();

                //map the game properties to the form

                if (updatedDetails != null)
                {
                    Team1LoLTextBox.Text = updatedDetails.team1;
                    Team2LoLTextBox.Text = updatedDetails.team2;
                    KillsForTeam1TextBox.Text = updatedDetails.killsTeam1.ToString();
                    KillsForTeam2TextBox.Text = updatedDetails.killsTeam2.ToString();
                    ObjectivesForTeam1TextBox.Text = updatedDetails.objectivesTeam1.ToString();
                    ObjectivesForTeam2TextBox.Text = updatedDetails.objectivesTeam2.ToString();
                    
                    SpectatorsLoLTextBox.Text = updatedDetails.spectators.ToString();
                    WinnerLoLTextBox.Text = updatedDetails.winner;
                    //WeekTextBox.Text = updatedDetails.weekOfGame.ToString();

                }
            }
        }


        /**
         * <summary>
         *  This method takes all the inputs on the league details page and inserts it to the fields in the table
         * </summary>
         * @method SaveButton_Click
         * @returns {void}
         * */
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            using (GameTrackerConnection db = new GameTrackerConnection())
            {
                //creating new  league object based on the model
                League leagueGameDetails = new League();


                int gameID = 0;

                if (Request.QueryString.Count > 0)// our url has a gameID in it
                {
                    gameID = Convert.ToInt32(Request.QueryString["gameID"]);

                    //get the current game from EF DB
                    leagueGameDetails = (from league in db.Leagues where league.gameID == gameID select league).FirstOrDefault();


                }
                string week = weekNumberLoL.Text;
                string[] weekArray = null;
                char[] splitChar = { 'W' };
                weekArray = week.Split(splitChar);
                string weekNum = weekArray[1];


                //add form data to the new game record
                leagueGameDetails.team1 = Team1LoLTextBox.Text;
                leagueGameDetails.team2 = Team2LoLTextBox.Text;
                leagueGameDetails.killsTeam1 = int.Parse(KillsForTeam1TextBox.Text);
                leagueGameDetails.killsTeam2 = int.Parse(KillsForTeam2TextBox.Text);
                leagueGameDetails.objectivesTeam1 = int.Parse(ObjectivesForTeam1TextBox.Text);
                leagueGameDetails.objectivesTeam2 = int.Parse(ObjectivesForTeam2TextBox.Text);
               
                leagueGameDetails.spectators = int.Parse(SpectatorsLoLTextBox.Text);
                leagueGameDetails.winner = WinnerLoLTextBox.Text;
                //csgoGameDetails.weekOfGame = int.Parse(WeekTextBox.Text);
                leagueGameDetails.weekOfGame = int.Parse(weekNum);

                //use LINQ to ADO.NET to insert record to DB
                if (gameID == 0)
                {
                    db.Leagues.Add(leagueGameDetails);
                }


                //save all changes in the DB
                db.SaveChanges();

             
                Response.Redirect("~/League.aspx");
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
          
            Response.Redirect("~/League.aspx");
        }
    }
}
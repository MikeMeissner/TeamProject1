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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if((!IsPostBack) && (Request.QueryString.Count >0))
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
                Csgo updatedDetails = (from gameRecords in db.Csgoes where gameRecords.gameID == gameID select gameRecords).FirstOrDefault();

                //map the game properties to the form

            if(updatedDetails != null)
                {
                    Team1TextBox.Text = updatedDetails.team1;
                    Team2TextBox.Text = updatedDetails.team2;
                    RoundsForTeam1TextBox.Text = updatedDetails.roundsWon.ToString();
                    RoundsForTeam2TextBox.Text = updatedDetails.roundsWonTeam2.ToString();
                    PointsForTeam1TextBox.Text = updatedDetails.totalPoints.ToString();
                    PointsForTeam2TextBox.Text = updatedDetails.totalPointsTeam2.ToString();
                    MapPlayedTexBox.Text = updatedDetails.mapPlayed;
                    SpectatorsTextBox.Text = updatedDetails.spectators.ToString();
                    WinnerTextBox.Text = updatedDetails.winner;
                    //WeekTextBox.Text = updatedDetails.weekOfGame.ToString();

                }
            }
        }

        /**
         * <summary>
         *  This method takes all the inputs on the csgo details page and inserts it to the fields in the table
         * </summary>
         * @method SaveButton_Click
         * @returns {void}
         * */

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            using (GameTrackerConnection db = new GameTrackerConnection())
            {
                //creating new csgo object based on the model
                Csgo csgoGameDetails = new Csgo();


                int gameID = 0;

                if(Request.QueryString.Count>0)// our url has a gameID in it
                {
                    gameID = Convert.ToInt32(Request.QueryString["gameID"]);

                    //get the current game from EF DB
                    csgoGameDetails = (from csgo in db.Csgoes where csgo.gameID == gameID select csgo).FirstOrDefault();

                
                }
                string week = weekNumber.Text;
                string[] weekArray = null;
                char[] splitChar = { 'W' };
                weekArray = week.Split(splitChar);
                string weekNum = weekArray[1];
                

                //add form data to the new game record
                csgoGameDetails.team1 = Team1TextBox.Text;
                csgoGameDetails.team2 = Team2TextBox.Text;
                csgoGameDetails.roundsWon = int.Parse(RoundsForTeam1TextBox.Text);
                csgoGameDetails.roundsWonTeam2 = int.Parse(RoundsForTeam2TextBox.Text);
                csgoGameDetails.totalPoints = int.Parse(PointsForTeam1TextBox.Text);
                csgoGameDetails.totalPointsTeam2 = int.Parse(PointsForTeam2TextBox.Text);
                csgoGameDetails.mapPlayed = MapPlayedTexBox.Text;
                csgoGameDetails.spectators = int.Parse(SpectatorsTextBox.Text);
                csgoGameDetails.winner = WinnerTextBox.Text;
                //csgoGameDetails.weekOfGame = int.Parse(WeekTextBox.Text);
                csgoGameDetails.weekOfGame = int.Parse(weekNum);

                //use LINQ to ADO.NET to insert record to DB
                if (gameID == 0)
                {
                    db.Csgoes.Add(csgoGameDetails);
                }
               

                //save all changes in the DB
                db.SaveChanges();

                //redirect to csgo stats page
                Response.Redirect("~/Csgo.aspx");
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Csgo.aspx");
        }
    }
}
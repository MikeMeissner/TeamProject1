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
 * File Description: Code behind file for the Smite details page
 * */
namespace comp2007TeamProject
{
    public partial class WebForm11 : System.Web.UI.Page
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
                Smite updatedDetails = (from gameRecords in db.Smites where gameRecords.gameID == gameID select gameRecords).FirstOrDefault();

                //map the game properties to the form

                if (updatedDetails != null)
                {
                    Team1SmiteTextBox.Text = updatedDetails.team1;
                    Team2SmiteTextBox.Text = updatedDetails.team2;
                    KillsForTeam1TextBox.Text = updatedDetails.killsTeam1.ToString();
                    KillsForTeam2TextBox.Text = updatedDetails.killsTeam2.ToString();
                    PointsSmiteForTeam1TextBox.Text = updatedDetails.pointsTeam1.ToString();
                    PointsSmiteForTeam2TextBox.Text = updatedDetails.pointsTeam2.ToString();
                    
                    SpectatorsSmiteTextBox.Text = updatedDetails.spectators.ToString();
                    WinnerSmiteTextBox.Text = updatedDetails.winner;
                    //WeekTextBox.Text = updatedDetails.weekOfGame.ToString();

                }
            }
        }

        /**
         * <summary>
         *  This method takes all the inputs on the smite details page and inserts it to the fields in the table
         * </summary>
         * @method SaveButton_Click
         * @returns {void}
         * */
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            using (GameTrackerConnection db = new GameTrackerConnection())
            {
                //creating new smite object based on the model
                Smite SmiteGameDetails = new Smite();


                int gameID = 0;

                if (Request.QueryString.Count > 0)// our url has a gameID in it
                {
                    gameID = Convert.ToInt32(Request.QueryString["gameID"]);

                    //get the current game from EF DB
                    SmiteGameDetails = (from smite in db.Smites where smite.gameID == gameID select smite).FirstOrDefault();


                }
                string week = weekNumberSmite.Text;
                string[] weekArray = null;
                char[] splitChar = { 'W' };
                weekArray = week.Split(splitChar);
                string weekNum = weekArray[1];


                //add form data to the new game record
                SmiteGameDetails.team1 = Team1SmiteTextBox.Text;
                SmiteGameDetails.team2 = Team2SmiteTextBox.Text;
                SmiteGameDetails.killsTeam1 = int.Parse(KillsForTeam1TextBox.Text);
                SmiteGameDetails.killsTeam2 = int.Parse(KillsForTeam2TextBox.Text);
                SmiteGameDetails.pointsTeam1 = int.Parse(PointsSmiteForTeam1TextBox.Text);
                SmiteGameDetails.pointsTeam2 = int.Parse(PointsSmiteForTeam2TextBox.Text);
                
                SmiteGameDetails.spectators = int.Parse(SpectatorsSmiteTextBox.Text);
                SmiteGameDetails.winner = WinnerSmiteTextBox.Text;
                //csgoGameDetails.weekOfGame = int.Parse(WeekTextBox.Text);
                SmiteGameDetails.weekOfGame = int.Parse(weekNum);

                //use LINQ to ADO.NET to insert record to DB
                if (gameID == 0)
                {
                    db.Smites.Add(SmiteGameDetails);
                }


                //save all changes in the DB
                db.SaveChanges();

                //redirect to smite stats page
                Response.Redirect("~/Smite.aspx");
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Smite.aspx");
        }
    }
}
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

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                //creating new csgo object based on the model
                Csgo csgoGameDetails = new Csgo();


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

                //use LINQ to ADO.NET to insert record to DB
                db.Csgoes.Add(csgoGameDetails);

                db.SaveChanges();
            }
        }
    }
}
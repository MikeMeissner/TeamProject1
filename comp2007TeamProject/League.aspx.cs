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
 * File Description: Code behind file for the League Of Legends gridview
 * */
namespace comp2007TeamProject
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the page is loading for the first time, populate the grid
            if (!IsPostBack)
            {

                //get league data
                this.GetLeagueData();


            }
        }

        /**
        * <summary>
        * This method sorts out the games played by week
        * </summary>
        * @method leagueSort
        * @returns {VOID}
        * */

        protected void leagueSort(object sender, EventArgs e)
        {
            if (weekNumberSort.Text == null)
            {
                Response.Redirect("~/League.aspx");
            }
            else
            {
                string week = weekNumberSort.Text;//store the input into a string
                string[] weekArray = null;
                char[] splitChar = { 'W' };//split the input into 2 parts the year will be stored in weekArray[0] and the week number is stored in the second index of the array
                weekArray = week.Split(splitChar);
                string weekNum = weekArray[1];// store just the week number into a string variable

                int weekSort = int.Parse(weekNum);// parse the number as an integer

                //connect to EF
                using (GameTrackerConnection db = new GameTrackerConnection())
                {
                    //query the csgo table
                    var League = (from allData in db.Leagues
                                where allData.weekOfGame == weekSort
                                select allData);

                    //bind results to the gridview
                    LeagueGridView.DataSource = League.ToList();
                    LeagueGridView.DataBind();
                }
            }
        }

        /**
             * 
             * <summary>
             * This method gets the dota data from the DB
             * </summary>
             * @method GetLeagueData
             * @returns {void}
             * */
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

        /**
        * <summary>
        * This method deletes record from the DB
        * </summary>
        * @method LeagueGridView_RowDeleting
        * @returns {VOID}
        * */

        protected void LeagueGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int selectedRow = e.RowIndex; // store which row was called
            int gameID = Convert.ToInt32(LeagueGridView.DataKeys[selectedRow].Values["gameID"]);// get game ID

            if (HttpContext.Current.User.Identity.IsAuthenticated)//check if user is logged in
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
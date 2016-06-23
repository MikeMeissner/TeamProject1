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
 * File Description: Code behind file for the Smite gridview
 * */
namespace comp2007TeamProject
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the page is loading for the first time, populate the grid
            if (!IsPostBack)
            {
                
                this.GetSmiteData();


            }

        }
        /**
            * 
            * <summary>
            * This method gets the dota data from the DB
            * </summary>
            * @method GetSmiteData
            * @returns {void}
            * */

        protected void GetSmiteData()
        {
            //connect to EF
            using (GameTrackerConnection db = new GameTrackerConnection())
            {
                //query the csgo table
                var Smite = (from allData in db.Smites
                            select allData);

                //bind results to the gridview
                SmiteGridView.DataSource = Smite.ToList();
                SmiteGridView.DataBind();
            }
        }
        /**
       * <summary>
       * This method sorts out the games played by week
       * </summary>
       * @method smiteSort
       * @returns {VOID}
       * */

        protected void smiteSort(object sender, EventArgs e)
        {
            if (weekNumberSort.Text == null)
            {
                Response.Redirect("~/Smite.aspx");
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
                    var Smite = (from allData in db.Smites
                                  where allData.weekOfGame == weekSort
                                  select allData);

                    //bind results to the gridview
                    SmiteGridView.DataSource = Smite.ToList();
                    SmiteGridView.DataBind();
                }
            }
        }

        /**
       * <summary>
       * This method deletes record from the DB
       * </summary>
       * @method LeagueGridView_RowDeleting
       * @returns {VOID}
       * */
        protected void SmiteGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int selectedRow = e.RowIndex; // store which row was called
            int gameID = Convert.ToInt32(SmiteGridView.DataKeys[selectedRow].Values["gameID"]);// get game ID

            if (HttpContext.Current.User.Identity.IsAuthenticated)//checks to see if user is logged in
            {
                //connect to db to remove row

                using (GameTrackerConnection db = new GameTrackerConnection())
                {
                    Smite removedGame = (from gameRecords in db.Smites where gameRecords.gameID == gameID select gameRecords).FirstOrDefault();

                    db.Smites.Remove(removedGame);

                    db.SaveChanges();

                    this.GetSmiteData();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

        }
    }
}
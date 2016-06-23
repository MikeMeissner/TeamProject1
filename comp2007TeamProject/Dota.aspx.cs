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
 * File Description: Code behind file for the DOTA2 gridview
 * */
namespace comp2007TeamProject
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the page is loading for the first time, populate the grid
            if (!IsPostBack)
            {

                //get dota data
                this.GetDotaData();


            }
        }
        /**
         * 
         * <summary>
         * This method gets the dota data from the DB
         * </summary>
         * @method GetDotaData
         * @returns {void}
         * */

        protected void GetDotaData()
        {
            //connect to EF
            using (GameTrackerConnection db = new GameTrackerConnection())
            {
                //query the csgo table
                var Dota = (from allData in db.Dotas
                            select allData);

                //bind results to the gridview
                DotaGridView.DataSource = Dota.ToList();
                DotaGridView.DataBind();
            }
        }
        /**
       * <summary>
       * This method sorts out the games played by week
       * </summary>
       * @method dotaSort
       * @returns {VOID}
       * */


        protected void dotaSort(object sender, EventArgs e)
        {
            if (weekNumberSort.Text == null)
            {
                Response.Redirect("~/Dota.aspx");
            }
            else
            {
                //store the input into a string
                string week = weekNumberSort.Text;
                string[] weekArray = null;
                char[] splitChar = { 'W' };//split the input into 2 parts the year will be stored in weekArray[0] and the week number is stored in the second index of the array
                weekArray = week.Split(splitChar);
                string weekNum = weekArray[1];// store just the week number into a string variable

                int weekSort = int.Parse(weekNum);// parse the number as an integer

                //connect to EF
                using (GameTrackerConnection db = new GameTrackerConnection())
                {
                    //query the csgo table
                    var Dota = (from allData in db.Dotas
                                where allData.weekOfGame == weekSort
                                select allData);

                    //bind results to the gridview
                    DotaGridView.DataSource = Dota.ToList();
                    DotaGridView.DataBind();
                }
            }
        }

        /**
         * <summary>
         * This method deletes record from the DB
         * </summary>
         * @method DotaGridView_RowDeleting
         * @returns {VOID}
         * */
        protected void DotaGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int selectedRow = e.RowIndex; // store which row was called
            int gameID = Convert.ToInt32(DotaGridView.DataKeys[selectedRow].Values["gameID"]);// get game ID

            //checks to see if user is logged in
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //connect to db to remove row

                using (GameTrackerConnection db = new GameTrackerConnection())
                {
                    Dota removedGame = (from gameRecords in db.Dotas where gameRecords.gameID == gameID select gameRecords).FirstOrDefault();

                    db.Dotas.Remove(removedGame);

                    db.SaveChanges();

                    this.GetDotaData();
                }
            }
            //send to login
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}
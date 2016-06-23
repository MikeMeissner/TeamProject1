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
 * File Description: Code behind file for the csgo gridview
 * */
namespace comp2007TeamProject
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the page is loading for the first time, populate the grid
            if(!IsPostBack)
            {
               
                    //get csgo data
                    this.GetCsgoData();
                
                
            }
           
        }
        /**
         * 
         * <summary>
         * This method gets the csgo data from the DB
         * </summary>
         * @method GetCsgoData
         * @returns {void}
         * */
        protected void GetCsgoData()
        {
            //connect to EF
            using (GameTrackerConnection db = new GameTrackerConnection())
            {
                //query the csgo table
                var Csgo = (from allData in db.Csgoes
                            select allData);

                //bind results to the gridview
                CsgoGridView.DataSource = Csgo.ToList();
                CsgoGridView.DataBind();
            }
        }

        /**
         * <summary>
         * This method deletes record from the DB
         * </summary>
         * @method CsgoGridView_RowDeleting
         * @returns {VOID}
         * */
        protected void CsgoGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int selectedRow = e.RowIndex; // store which row was called
            int gameID = Convert.ToInt32(CsgoGridView.DataKeys[selectedRow].Values["gameID"]);// get game ID

            if (HttpContext.Current.User.Identity.IsAuthenticated)// check to see if user is logged in
            {
                //connect to db to remove row

                using (GameTrackerConnection db = new GameTrackerConnection())
                {
                    Csgo removedGame = (from gameRecords in db.Csgoes where gameRecords.gameID == gameID select gameRecords).FirstOrDefault();

                    db.Csgoes.Remove(removedGame);

                    db.SaveChanges();

                    this.GetCsgoData();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

            
        }
        /**
        * <summary>
        * This method sorts out the games played by week
        * </summary>
        * @method csgoSort
        * @returns {VOID}
        * */

        protected void csgoSort(object sender, EventArgs e)
        {
            //checks to see if the week field is empty
            if (weekNumberSort.Text == null)
            {
                Response.Redirect("~/Csgo.aspx");
            } else { 
            string week = weekNumberSort.Text; //store the input into a string
            string[] weekArray = null;
            char[] splitChar = { 'W' }; //split the input into 2 parts the year will be stored in weekArray[0] and the week number is stored in the second index of the array
            weekArray = week.Split(splitChar);
            string weekNum = weekArray[1]; // store just the week number into a string variable

            int weekSort = int.Parse(weekNum);// parse the number as an integer

            //connect to EF
            using (GameTrackerConnection db = new GameTrackerConnection())
            {
                //query the csgo table
                var Csgo = (from allData in db.Csgoes where allData.weekOfGame == weekSort
                            select allData);

                //bind results to the gridview
                CsgoGridView.DataSource = Csgo.ToList();
                CsgoGridView.DataBind();
            }
        }
        }
    }
}
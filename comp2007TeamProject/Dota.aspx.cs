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
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the page is loading for the first time, populate the grid
            if (!IsPostBack)
            {

                //get csgo data
                this.GetDotaData();


            }
        }

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

        protected void dotaSort(object sender, EventArgs e)
        {
            if (weekNumberSort.Text == null)
            {
                Response.Redirect("~/Dota.aspx");
            }
            else
            {
                string week = weekNumberSort.Text;
                string[] weekArray = null;
                char[] splitChar = { 'W' };
                weekArray = week.Split(splitChar);
                string weekNum = weekArray[1];

                int weekSort = int.Parse(weekNum);

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
        protected void DotaGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int selectedRow = e.RowIndex; // store which row was called
            int gameID = Convert.ToInt32(DotaGridView.DataKeys[selectedRow].Values["gameID"]);// get game ID

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
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}
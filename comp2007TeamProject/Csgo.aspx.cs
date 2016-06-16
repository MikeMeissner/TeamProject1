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
            using (DefaultConnection db = new DefaultConnection())
            {
                //query the csgo table
                var Csgo = (from allData in db.Csgoes
                            select allData);

                //bind results to the gridview
                CsgoGridView.DataSource = Csgo.ToList();
                CsgoGridView.DataBind();
            }
        }

        protected void CsgoGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int selectedRow = e.RowIndex; // store which row was called
            int gameID = Convert.ToInt32(CsgoGridView.DataKeys[selectedRow].Values["gameID"]);// get game ID

            //connect to db to remove row

            using (DefaultConnection db = new DefaultConnection())
            {
                Csgo removedGame = (from gameRecords in db.Csgoes where gameRecords.gameID == gameID select gameRecords).FirstOrDefault();

                db.Csgoes.Remove(removedGame);

                db.SaveChanges();

                this.GetCsgoData();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CookDoor.DB_Layer;

using CookDoor.Service_Layer;
public partial class Backend_RemoveBranch : System.Web.UI.Page
{
    //Declaring our needed variables
    CityService LS;
    List<City> CitiesList;
    List<Branch> BranchesList;
    BranchService Bs;
    /// <summary>
    /// Page Load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        ctrl_Log1.reset();
        //Initializing the needed variables
        try
        {

           
                LS = new CityService();
                Bs = new BranchService();
                BranchesList = new List<Branch>();
                CitiesList = new List<City>();
                //Invoking DisplayTable function
                if (Session["Added"] != null)
                {
                    ctrl_Log1.set_Image(true);
                    ctrl_Log1.set_LogMsg("Branch Deleted");
                }

                DisplayTable();
                

            
            
               // Response.Redirect("~/default.aspx");
        }
        catch (Exception ee)
        {
            //Display Error Message
            ctrl_Log1.set_LogMsg("General Error , Please Contact System Administrator");
            ctrl_Log1.set_Image(false);
        }
    }


    protected void RemoveBezra(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            String x = (String)thegrid.Rows[e.RowIndex].Cells[0].Text;
            Bs.removeBranch(Int32.Parse(x));
            Session["Added"] = 2;
            Response.Redirect("RemoveBranch.aspx");
        }
        catch (Exception ee)
        {
            //Display Error Message
            ctrl_Log1.set_LogMsg("General Error , Please Contact System Administrator");
            ctrl_Log1.set_Image(false);
        }
    }


    /// <summary>
    /// This Function Displays all the countries existing in the DB 
    /// </summary>
    protected void DisplayTable()
    {

        //Clearing the grid
        thegrid.DataSource = null;
        thegrid.DataBind();
        //Declaring n initializing needed variable
        System.Data.DataTable dt = new System.Data.DataTable();

       

            BranchesList = Bs.GetBranches();
            //Adding Columns header to the Datatable
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Name_ar");
            dt.Columns.Add("City_Name");
            //dt.Columns.Add("Facebook");
            //dt.Columns.Add("Otlob");
            //dt.Columns.Add("Mail");
            //Filling in the Data

            for (int i = 0; i < BranchesList.Count; i++)
            {
                dt.Rows.Add(BranchesList[i].ID,BranchesList[i].Name,BranchesList[i].Name_ar,BranchesList[i].City_Name);//,BranchesList[i].Facebook,BranchesList[i].Otlob,BranchesList[i].Mail);
            }
            //Binding the DataTable to the GridView "TheGrid"
            thegrid.DataSource = dt;
            thegrid.DataBind();
        

    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CookDoor.DB_Layer;

using CookDoor.Service_Layer;
public partial class Backend_AddCity : System.Web.UI.Page
{
    //Declaring our needed variables
    CityService LS;
    List<City> CitiesList;
    
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
            CitiesList = new List<City>();
            //Invoking DisplayTable function

    
    
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



        CitiesList = LS.GetCities();
        //Adding Columns header to the Datatable
        dt.Columns.Add("Name");
        dt.Columns.Add("الأسم");
        //dt.Columns.Add("Facebook");
        //dt.Columns.Add("Otlob");
        //dt.Columns.Add("Mail");
        //Filling in the Data

        for (int i = 0; i < CitiesList.Count; i++)
        {
            dt.Rows.Add(CitiesList[i].Name, CitiesList[i].Name_ar);//,CitiesList[i].Facebook,CitiesList[i].Otlob,CitiesList[i].Mail);
        }
        //Binding the DataTable to the GridView "TheGrid"
        thegrid.DataSource = dt;
        thegrid.DataBind();


    }

    /// <summary>
    /// This Function adds a new City Record to the DB
    /// </summary>
    protected void InsertCity()
    {
        try
        {
            CitiesList = LS.GetCities();
            //Initializes Needed Variable
            City l = new City();
            //Getting input data

            l.Name = txt_city_name.Text;
            l.Name_ar = txt_city_name_ar.Text;
            //This next step is to check that the City doesnot exist already in the DB
            bool existsFlag = false;
            for (int i = 0; i < CitiesList.Count; i++)
            {
                if (CitiesList[i].Name == l.Name)
                    existsFlag = true;
            }
            //If City is new
            if (!existsFlag)
            {
                //Adds Country to the DB
                LS.addCity(l);
                DisplayTable();
                txt_city_name.Text = "";
                txt_city_name_ar.Text = "";
                ctrl_Log1.set_LogMsg("DataUpdatedSuccesfully");
                ctrl_Log1.set_Image(true);
            }
            else
            {
                //Display Error Message
                ctrl_Log1.set_LogMsg("City Name Exists");
                ctrl_Log1.set_Image(false);
            }
        }
        catch (Exception e)
        {
            //Handling Exception By Displaying Message to the user
            ctrl_Log1.set_LogMsg("Data Entry Error! Please Contact System Administrator");
            ctrl_Log1.set_Image(false);
        }
    }
    /// <summary>
    /// This Event is fired when user clicks Add Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Insert_Click(object sender, EventArgs e)
    {
        //Inserts a new City
        InsertCity();
    }
}
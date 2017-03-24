using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CookDoor.DB_Layer;

using CookDoor.Service_Layer;
public partial class Backend_AddBranch : System.Web.UI.Page
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

                if (!Page.IsPostBack)
                {

                    InitializeList();
                    DisplayTable();
                }

            
            
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
    /// Initialize the Countries list
    /// </summary>
    protected void InitializeList()
    {
        CitiesList=LS.GetCities();
        //Filling in the Data
        list_cities.Items.Clear();
        for (int i = 0; i < CitiesList.Count; i++)
        {
            list_cities.Items.Add(new ListItem(CitiesList[i].Name, "" + CitiesList[i].ID));
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
            dt.Columns.Add("Name");
            dt.Columns.Add("الأسم");
            dt.Columns.Add("City");
            //dt.Columns.Add("Facebook");
            //dt.Columns.Add("Otlob");
            //dt.Columns.Add("Mail");
            //Filling in the Data

            for (int i = 0; i < BranchesList.Count; i++)
            {
                dt.Rows.Add(BranchesList[i].Name,BranchesList[i].Name_ar,BranchesList[i].City_Name);//,BranchesList[i].Facebook,BranchesList[i].Otlob,BranchesList[i].Mail);
            }
            //Binding the DataTable to the GridView "TheGrid"
            thegrid.DataSource = dt;
            thegrid.DataBind();
        

    }

    /// <summary>
    /// This Function adds a new City Record to the DB
    /// </summary>
    protected void InsertBranch()
    {
        try
        {
            BranchesList = Bs.GetBranches();
            //Initializes Needed Variable
            Branch l = new Branch();
            //Getting input data
           
            l.Name = txt_city_name.Text;
            l.Name_ar = txt_city_name_ar.Text;
            l.Facebook = txt_facebook.Text;
            l.Otlob = txt_otlob.Text;
            l.Mail = txt_mail.Text;
            l.City_ID = Int32.Parse(list_cities.SelectedValue);
            //This next step is to check that the City doesnot exist already in the DB
            bool existsFlag = false;
            for (int i = 0; i < BranchesList.Count; i++)
            {
                if (BranchesList[i].Name == l.Name)
                    existsFlag = true;
            }
            //If City is new
            if (!existsFlag)
            {
                //Adds Country to the DB
                Bs.addBranch(l);
                DisplayTable();
                txt_facebook.Text = "";
                txt_mail.Text = "";
                txt_city_name.Text = "";
                txt_city_name_ar.Text = "";
                txt_otlob.Text = "";
                ctrl_Log1.set_LogMsg("DataUpdatedSuccesfully");
                ctrl_Log1.set_Image(true);
            }
            else
            {
                //Display Error Message
                ctrl_Log1.set_LogMsg("Branch Name Exists");
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
        InsertBranch();
    }
}
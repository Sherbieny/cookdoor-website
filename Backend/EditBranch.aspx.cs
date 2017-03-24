using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CookDoor.DB_Layer;

using CookDoor.Service_Layer;
public partial class Backend_EditBranch : System.Web.UI.Page
{
    //Declaring our needed variables
    CityService LS;
    List<City> CitiesList;
    List<Branch> BranchesList;
    BranchService Bs;
    Branch B;

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

            if (Session["BranchID"] != null && !Page.IsPostBack )
            {
                InitializeList();
                ShowBranchData();
                
            }
           
            DisplayTable();



            // Response.Redirect("~/default.aspx");
        }
        catch (Exception ee)
        {
            //Display Error Message
            ctrl_Log1.set_LogMsg("General Error 1 , Please Contact System Administrator");
            ctrl_Log1.set_Image(false);
        }
    }


  
    /// <summary>
    /// Initialize the Countries list
    /// </summary>
    protected void InitializeList()
    {
       
            CitiesList = LS.GetCities();
            //Filling in the Data
            list_cities.Items.Clear();
            for (int i = 0; i < CitiesList.Count; i++)
            {
                list_cities.Items.Add(new ListItem(CitiesList[i].Name, "" + CitiesList[i].ID));
            }
       
    }


    /// <summary>
    /// Selects A Branch
    /// </summary>
    protected void SelectBranch(object sender, GridViewEditEventArgs e)
    {
        try
        {
            String x = (String)thegrid.Rows[e.NewEditIndex].Cells[0].Text;
            
            Session["BranchID"] = Bs.GetBranchByID(Int32.Parse(x)).ID;
            
            Response.Redirect("EditBranch.aspx");
        }
        catch (Exception ee)
        {
            //Display Error Message
            ctrl_Log1.set_LogMsg("General Error 2 , Please Contact System Administrator");
            ctrl_Log1.set_Image(false);
        }
    }


    /// <summary>
    /// Edit A Branch
    /// </summary>
    protected void EditBranch()
    {
            
            //Initializes Needed Variable
            
        
            Branch l = new Branch();
            //Getting input data
            l.ID = (Int32.Parse(Session["BranchID"].ToString()));
            l.Name = txt_branch_name.Text;
            l.Name_ar = txt_branch_name_ar.Text;
            l.Facebook = txt_facebook.Text;
            l.Otlob = txt_otlob.Text;
            l.Mail = txt_mail.Text;
            l.City_ID = Int32.Parse(list_cities.SelectedValue);
            //This next step is to check that the City doesnot exist already in the DB
            
                //Edits Branch to the DB
                Bs.editBranch(l);
                DisplayTable();
                Panel1.Visible = false;
                ctrl_Log1.set_LogMsg("DataUpdatedSuccesfully");
                ctrl_Log1.set_Image(true);
                Session.Remove("BranchID");
          
     }

    
    /// <summary>
    /// Show A Branch data in editable Tabs
    /// </summary>
    protected void ShowBranchData()
    {
        /// Getting Data
        Branch l = new Branch();
        l = Bs.GetBranchByID(Int32.Parse(Session["BranchID"].ToString()));
        
        /// Showing editable Controls
        Panel1.Visible = true;
        
        /// Filling in the Data
        txt_branch_name.Text = l.Name;
        txt_branch_name_ar.Text  = l.Name_ar;
        txt_facebook.Text  = l.Facebook;
        txt_otlob.Text = l.Otlob;
        txt_mail.Text = l.Mail;
        list_cities.SelectedValue = ""+l.City_ID;
        
       
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
            dt.Rows.Add(BranchesList[i].ID, BranchesList[i].Name, BranchesList[i].Name_ar, BranchesList[i].City_Name);//,BranchesList[i].Facebook,BranchesList[i].Otlob,BranchesList[i].Mail);
        }
        //Binding the DataTable to the GridView "TheGrid"
        
        thegrid.DataSource = dt;
        thegrid.DataBind();


    }
  

    /// <summary>
    /// This Event is fired when user clicks Add Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Insert_Click(object sender, EventArgs e)
    {
        //Inserts a new City
        EditBranch();
    }
}
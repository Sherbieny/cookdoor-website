using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CookDoor.DB_Layer;

using CookDoor.Service_Layer;
public partial class Backend_RemoveCategory : System.Web.UI.Page
{
    //Declaring our needed variables
    
    
    List<Category> CategoriesList;
    CategoryService Bs;
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


            
            Bs = new CategoryService();
            CategoriesList = new List<Category>();
            
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


    protected void RemoveBezra(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            String x = (String)thegrid.Rows[e.RowIndex].Cells[1].Text;

            Bs.removeCategory(Bs.GetCategoryByName(x).ID);
            DisplayTable();
            ctrl_Log1.set_LogMsg("Category deleted");
            ctrl_Log1.set_Image(true);
        }
        catch (Exception ee)
        {
            //Display Error Message
            ctrl_Log1.set_LogMsg("General Error , Please Contact System Administrator");
            ctrl_Log1.set_Image(false);
        }
    }


    /// <summary>
    /// 
    /// This Function Displays all the countries existing in the DB 
    /// </summary>
    protected void DisplayTable()
    {

        //Clearing the grid
        thegrid.DataSource = null;
        thegrid.DataBind();
        //Declaring n initializing needed variable
        System.Data.DataTable dt = new System.Data.DataTable();
        


        CategoriesList = Bs.GetCategories();
        //Adding Columns header to the Datatable
        dt.Columns.Add("ID");
        dt.Columns.Add("Name");
        dt.Columns.Add("Name_ar");
        dt.Columns.Add("Path");
        //dt.Columns.Add("Facebook");
        //dt.Columns.Add("Otlob");
        //dt.Columns.Add("Mail");
        //Filling in the Data

        for (int i = 0; i < CategoriesList.Count; i++)
        {
            dt.Rows.Add(CategoriesList[i].ID, CategoriesList[i].Name, CategoriesList[i].Name_ar, CategoriesList[i].Path);//,CategoriesList[i].Facebook,CategoriesList[i].Otlob,CategoriesList[i].Mail);
        }
        //Binding the DataTable to the GridView "TheGrid"
        thegrid.DataSource = dt;
        thegrid.DataBind();


    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CookDoor.DB_Layer;

using CookDoor.Service_Layer;
public partial class Backend_EditCategory : System.Web.UI.Page
{
    //Declaring our needed variables
    List<Category> CategoriesList;
    Category C;
    CategoryService Cs;

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


            
            Cs = new CategoryService();
            CategoriesList = new List<Category>();
            C = new Category();
            //Invoking DisplayTable function

            if (Session["CategoryName"] != null && !Page.IsPostBack)
            {
               // InitializeList();
                ShowCategoryData();

            }

            DisplayTable();



            // Response.Redirect("~/default.aspx");
        }
        catch (Exception ee)
        {
            //Display Error Message
            ctrl_Log1.set_LogMsg("General Error 0 , Please Contact System Administrator");
            ctrl_Log1.set_Image(false);
        }
    }



    /// <summary>
    /// Initialize the Countries list
    /// </summary>
 /*   protected void InitializeList()
    {

        CategoriesList = Cs.GetCategories();
        //Filling in the Data
        list_categories.Items.Clear();
        for (int i = 0; i < CategoriesList.Count; i++)
        {
            list_categories.Items.Add(new ListItem(CategoriesList[i].Name, "" + CategoriesList[i].ID));
        }

    }*/


    /// <summary>
    /// Selects A Category
    /// </summary>
    protected void SelectCategory(object sender, GridViewEditEventArgs e)
    {
        try
        {
            String x = (String)thegrid.Rows[e.NewEditIndex].Cells[1].Text;

            Session["CategoryName"] = Cs.GetCategoryByName(x).Name;
          //  C.Name = Session["CategoryName"].ToString();
            Response.Redirect("EditCategory.aspx");
        }
        catch (Exception ee)
        {
            //Display Error Message
            ctrl_Log1.set_LogMsg("General Error 1 , Please Contact System Administrator");
            ctrl_Log1.set_Image(false);
        }
    }


    /// <summary>
    /// Edit A Category
    /// </summary>
    protected void EditCategory()
    {

        //Initializes Needed Variable

        try
        {
            Category l = new Category();
            l = Cs.GetCategoryByName(Session["CategoryName"].ToString());
            //Getting input data

            l.Name = txt_category_name.Text;
            l.Name_ar = txt_category_name_ar.Text;
            
            //Adds Image Path
            l.Path = saveFiles(upload_path);
            if (l.Path == "")
            {
                ctrl_Log1.set_LogMsg("Please Upload Image");
                ctrl_Log1.set_Image(false);
                return;
            }

            //Edits Category to the DB
            Cs.editCategory(l);
            DisplayTable();
            Panel1.Visible = false;
            ctrl_Log1.set_LogMsg("DataUpdatedSuccesfully");
            ctrl_Log1.set_Image(true);
            Session.Remove("CategoryName");
        }
        catch (Exception ee)
        {
            //Display Error Message
            ctrl_Log1.set_LogMsg("General Error 2 , Please Contact System Administrator");
            ctrl_Log1.set_Image(false);
        }

    }


    /// <summary>
    /// This function save the files to the File System
    /// </summary>
    /// <param name="ctr"></param>
    /// <param name="ToolName"></param>
    /// <param name="img"></param>
    /// <param name="check"></param>
    /// <returns></returns>
    public String saveFiles(FileUpload ctr)
    {
        if (String.IsNullOrEmpty(ctr.PostedFile.FileName))
            return "";
        try
        {
            //Attach a file
            //creating a timestamp for the ile
            String FinalPath = "";
            System.IO.FileInfo File;
            String FileName = "";

            //Getting the name of the files
            File = new System.IO.FileInfo(ctr.PostedFile.FileName);
            //Deciding the final path
            FinalPath = "Images/Categories/" + File.Name;
            if (ctr.HasFile || String.IsNullOrEmpty(ctr.PostedFile.FileName))
            {
                try
                {
                    //Check file size 
                    int FileSize = ctr.PostedFile.ContentLength;
                    int MaxFileSize = 5;
                    if (FileSize > (MaxFileSize * 1048576)) //5 MB file length
                    {
                        //MaxAttachmentSizeLabel.Text = "File Size is too large; Maximum file size permitted is 5 MB";
                        //MaxAttachmentSizeLabel.Visible = true;
                        ctrl_Log1.set_LogMsg("File Size is too large; Maximum file size permitted is 5 MB");
                        ctrl_Log1.set_Image(false);
                        return "";
                    }
                    else
                    {
                        ctr.SaveAs(Server.MapPath("~/" + FinalPath));
                        return File.Name;
                    }

                }
                catch (Exception er)
                {
                    ctrl_Log1.set_LogMsg("Error in Uploading Attachments ,please contact system administrator");
                    ctrl_Log1.set_Image(false);
                    return "";
                }
            }

        }

        catch (Exception er)
        {
            return "";
        }
        return "";
    }
    //}


    /// <summary>
    /// Show A Category data in editable Tabs
    /// </summary>
    protected void ShowCategoryData()
    {

        try
        {
        
            /// Getting Data
        Category l = new Category();
        l = Cs.GetCategoryByName(Session["CategoryName"].ToString());

        /// Showing editable Controls
        Panel1.Visible = true;

        /// Filling in the Data
        txt_category_name.Text = l.Name;
        txt_category_name_ar.Text = l.Name_ar;
        
        
        }
         catch (Exception ee)
        {
            //Display Error Message
            ctrl_Log1.set_LogMsg("General Error 3 , Please Contact System Administrator");
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



        CategoriesList = Cs.GetCategories();
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
            dt.Rows.Add(CategoriesList[i].ID,CategoriesList[i].Name, CategoriesList[i].Name_ar, CategoriesList[i].Path);//,BranchesList[i].Facebook,BranchesList[i].Otlob,BranchesList[i].Mail);
        }
        //Binding the DataTable to the GridView "TheGrid"
        thegrid.Columns[0].Visible = false;
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
        EditCategory();
    }

}
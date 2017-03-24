using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CookDoor.DB_Layer;

using CookDoor.Service_Layer;
public partial class Backend_AddCategory : System.Web.UI.Page
{
    //Declaring our needed variables
    CategoryService LS;
    List<Category> CategoriesList;
    String Path;    
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


            LS = new CategoryService();
            CategoriesList = new List<Category>();
            //Invoking DisplayTable function

            if (!Page.IsPostBack)
            {

               
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
    /// This Function Displays all the categories existing in the DB 
    /// </summary>
    protected void DisplayTable()
    {

        //Clearing the grid
        thegrid.DataSource = null;
        thegrid.DataBind();
        //Declaring n initializing needed variable
        System.Data.DataTable dt = new System.Data.DataTable();



        CategoriesList = LS.GetCategories();
        //Adding Columns header to the Datatable
        dt.Columns.Add("Name");
        dt.Columns.Add("الأسم");
        dt.Columns.Add("Path");
        //dt.Columns.Add("Facebook");
        //dt.Columns.Add("Otlob");
        //dt.Columns.Add("Mail");
        //Filling in the Data

        for (int i = 0; i < CategoriesList.Count; i++)
        {
            dt.Rows.Add(CategoriesList[i].Name, CategoriesList[i].Name_ar, CategoriesList[i].Path);//,BranchesList[i].Facebook,BranchesList[i].Otlob,BranchesList[i].Mail);
        }
        //Binding the DataTable to the GridView "TheGrid"
        thegrid.DataSource = dt;
        thegrid.DataBind();


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
                            ctr.SaveAs(Server.MapPath("~/"+FinalPath));
                            return  File.Name;
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
    /// This Function adds a new Category Record to the DB
    /// </summary>
    protected void InsertCategory()
    {
        try
        {
            CategoriesList = LS.GetCategories();
            //Initializes Needed Variable
            Category l = new Category();
            //Getting input data

            l.Name = txt_category_name.Text;
            l.Name_ar = txt_category_name_ar.Text;

            //This next step is to check that the Category doesnot exist already in the DB
            bool existsFlag = false;
            for (int i = 0; i < CategoriesList.Count; i++)
            {
                if (CategoriesList[i].Name == l.Name || ((CategoriesList[i].Name_ar == l.Name_ar) && l.Name_ar!="" ))
                    existsFlag = true;
            }
            //If Category is new
            if (!existsFlag)
            {
                //Adds Country to the DB
                l.Path = saveFiles(upload_path);
                if (l.Path == "")
                {
                    ctrl_Log1.set_LogMsg("Please Upload Image");
                    ctrl_Log1.set_Image(false);
                    return;
                }
                LS.addCategory(l);
                DisplayTable();
                ctrl_Log1.set_LogMsg("DataUpdatedSuccesfully");
                ctrl_Log1.set_Image(true);
                txt_category_name.Text="";
                txt_category_name_ar.Text="";
               
            }
            else
            {
                //Display Error Message
                ctrl_Log1.set_LogMsg("Category Name Exists");
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
        //Inserts a new Category
        InsertCategory();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CookDoor.DB_Layer;
using CookDoor.Service_Layer;
public partial class Backend_AddProduct : System.Web.UI.Page
{
    //Declaring our needed variables
    CategoryService LS;
    List<Category> CategoriesList;
    List<Product> ProductsList;
    ProductService Bs;
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
            Bs = new ProductService();
            ProductsList = new List<Product>();
            CategoriesList = new List<Category>();
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
    /// Initialize the Categories dropdown list
    /// </summary>
    protected void InitializeList()
    {
        CategoriesList = LS.GetCategories();
        //Filling in the Data
        list_categories.Items.Clear();
        for (int i = 0; i < CategoriesList.Count; i++)
        {
            list_categories.Items.Add(new ListItem(CategoriesList[i].Name, "" + CategoriesList[i].ID));
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



        ProductsList = Bs.GetProducts();
        //Adding Columns header to the Datatable
        dt.Columns.Add("Name");
        dt.Columns.Add("الأسم");
        dt.Columns.Add("Category");
        dt.Columns.Add("Path");
        //dt.Columns.Add("Facebook");
        //dt.Columns.Add("Otlob");
        //dt.Columns.Add("Mail");
        //Filling in the Data

        for (int i = 0; i < ProductsList.Count; i++)
        {
            dt.Rows.Add(ProductsList[i].Name, ProductsList[i].Name_ar, ProductsList[i].Category_ID, ProductsList[i].Path);//,ProductsList[i].Facebook,ProductsList[i].Otlob,ProductsList[i].Mail);
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
    public String saveFiles(FileUpload ctr,string category_name)
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
            FinalPath = "Images/Categories/"+ category_name + "/" + File.Name;
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
    /// This Function adds a new Product Record to the DB
    /// </summary>
    protected void InsertProduct()
    {
        try
        {
            ProductsList = Bs.GetProducts();
            //Initializes Needed Variable
            Product l = new Product();
            //Getting input data

            l.Name = txt_product_name.Text;
            l.Name_ar = txt_product_name_ar.Text;
            string category_name = list_categories.SelectedItem.Text;
            l.Category_ID = Int32.Parse(list_categories.SelectedValue);
            //This next step is to check that the Category doesnot exist already in the DB
            bool existsFlag = false;
            for (int i = 0; i < ProductsList.Count; i++)
            {
                if (ProductsList[i].Name == l.Name)
                    existsFlag = true;
            }
            //If Products is new
            if (!existsFlag)
            {
                //Adds Product to the DB

                l.Path = saveFiles(upload_path, category_name);
                if (l.Path == "")
                {
                    ctrl_Log1.set_LogMsg("Please Upload Image");
                    ctrl_Log1.set_Image(false);
                    return;
                }
                Bs.addProduct(l);
                DisplayTable();
                txt_product_name.Text = "";
                txt_product_name_ar.Text = "";
                ctrl_Log1.set_LogMsg("DataUpdatedSuccesfully");
                ctrl_Log1.set_Image(true);
            }
            else
            {
                //Display Error Message
                ctrl_Log1.set_LogMsg("Product Name Exists");
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
        InsertProduct();
    }
}
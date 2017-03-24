using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CookDoor.DB_Layer;
using CookDoor.Service_Layer;

public partial class Backend_EditProduct : System.Web.UI.Page
{
    //Declaring our needed variables
    CategoryService Cs;
    List<Category> CategoriesList;
   
    List<Product> ProductsList;
    ProductService Ps;
    Product B;

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
            Ps = new ProductService();
            ProductsList = new List<Product>();
            CategoriesList = new List<Category>();
            //Invoking DisplayTable function

            if (Session["ProductName"] != null && !Page.IsPostBack)
            {
                InitializeList();
                ShowProductData();

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
    protected void InitializeList()
    {
        try
        {

            CategoriesList = Cs.GetCategories();
            //Filling in the Data
            list_categories.Items.Clear();
            for (int i = 0; i < CategoriesList.Count; i++)
            {
                list_categories.Items.Add(new ListItem(CategoriesList[i].Name, "" + CategoriesList[i].ID));
            }
        }
        catch (Exception ee)
        {
            //Display Error Message
            ctrl_Log1.set_LogMsg("General Error 1 , Please Contact System Administrator");
            ctrl_Log1.set_Image(false);
        }
    }


    /// <summary>
    /// Selects A Product
    /// </summary>
    protected void SelectProduct(object sender, GridViewEditEventArgs e)
    {
        try
        {
            String x = (String)thegrid.Rows[e.NewEditIndex].Cells[1].Text;

            Session["ProductName"] = Ps.GetProductByName(x).Name;
            Response.Redirect("EditProduct.aspx");
        }
        catch (Exception ee)
        {
            //Display Error Message
            ctrl_Log1.set_LogMsg("General Error 2 , Please Contact System Administrator");
            ctrl_Log1.set_Image(false);
        }
    }


    /// <summary>
    /// Edit A Product
    /// </summary>
    protected void EditProduct()
    {

        //Initializes Needed Variable
        try
        {

            Product l = new Product();
            l = Ps.GetProductByName(Session["ProductName"].ToString());
            //Getting input data
            l.Name = txt_product_name.Text;
            l.Name_ar = txt_product_name_ar.Text;
            
            l.Category_ID = Int32.Parse(list_categories.SelectedValue);
        
            //Adds Image Path
                l.Path = saveFiles(upload_path, list_categories.SelectedItem.Text);
            //Edits Product to the DB
            Ps.editProduct(l);
            DisplayTable();
            Panel1.Visible = false;
            ctrl_Log1.set_LogMsg("DataUpdatedSuccesfully");
            ctrl_Log1.set_Image(true);
            Session.Remove("ProductName");
        }
        
        catch (Exception ee)
        {
            //Display Error Message
            ctrl_Log1.set_LogMsg(ee.ToString());
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
    public String saveFiles(FileUpload ctr, string category_name)
    {
        if (String.IsNullOrEmpty(ctr.PostedFile.FileName))
            return "";
            //Attach a file
            //creating a timestamp for the ile
            String FinalPath = "";
            System.IO.FileInfo File;
            
            //Getting the name of the files
            File = new System.IO.FileInfo(ctr.PostedFile.FileName);
            //Deciding the final path
            FinalPath = "Images/Categories/" + category_name + "/" + File.Name;
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
                catch (Exception ee)
                {
                    throw ee;
                    return "";

                }

            }

            return "";
     
    }

    /// <summary>
    /// Show A Product data in editable Tabs
    /// </summary>
    protected void ShowProductData()
    {

        try
        {
            /// Getting Data
            Product l = new Product();
            l = Ps.GetProductByName(Session["ProductName"].ToString());

            /// Showing editable Controls
            Panel1.Visible = true;
            
     
            /// Filling in the Data
            ///   l.Name = txt_product_name.Text;
            ///   txt_Account_name.Text = l.Name;
            
            
            txt_product_name.Text =l.Name;
            txt_product_name_ar.Text = l.Name_ar;
            
            list_categories.SelectedValue = "" + l.Category_ID;
            
        }
        catch (Exception ee)
        {
            //Display Error Message
            ctrl_Log1.set_LogMsg("General Error 4 , Please Contact System Administrator");
            ctrl_Log1.set_Image(false);
        }
    }

    /// <summary>
    /// This Function Displays all the countries existing in the DB 
    /// </summary>
    protected void DisplayTable()
    {
        try
        {
            //Clearing the grid
            thegrid.DataSource = null;
            thegrid.DataBind();
            //Declaring n initializing needed variable
            System.Data.DataTable dt = new System.Data.DataTable();



            ProductsList = Ps.GetProducts();
            //Adding Columns header to the Datatable
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Name_ar");
            dt.Columns.Add("Path");
            dt.Columns.Add("Category_ID");
            //dt.Columns.Add("Facebook");
            //dt.Columns.Add("Otlob");
            //dt.Columns.Add("Mail");
            //Filling in the Data

            for (int i = 0; i < ProductsList.Count; i++)
            {
                dt.Rows.Add(ProductsList[i].ID, ProductsList[i].Name, ProductsList[i].Name_ar, ProductsList[i].Path, ProductsList[i].Category_Name);//,ProductsList[i].Facebook,ProductsList[i].Otlob,ProductsList[i].Mail);
            }
            //Binding the DataTable to the GridView "TheGrid"
            thegrid.DataSource = dt;
            thegrid.DataBind();
        }
        catch (Exception ee)
        {
            //Display Error Message
            ctrl_Log1.set_LogMsg("General Error 5 , Please Contact System Administrator");
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
        EditProduct();
    }
}
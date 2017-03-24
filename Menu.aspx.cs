using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CookDoor.DB_Layer;
using CookDoor.Service_Layer;
public partial class Menu_lo : System.Web.UI.Page
{
    public ProductService PS;
    public CategoryService CS;
    public List<Category> CategoriesList;
    String CategoriesURL;
    String ProductsURL;
    public List<Product> ProductsList;
    public String category;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        CategoriesURL = "Images/Categories/";
        
        CS=new CategoryService();
        PS = new ProductService();
        CategoriesList = CS.GetCategories();
        ProductsList = new List<Product>();


        try
        {
            if (Request.QueryString["Category"] != null)
            {
                category = Request.QueryString["Category"];
                ProductsList = PS.GetProductsByCategoryName(category);
            }
            ProductsURL = "Images/Categories/" + ProductsList[0].Category_Name+"/";
            
            for (int i = 0; i < CategoriesList.Count; i++)
                CategoriesList[i].Path = CategoriesURL + CategoriesList[i].Path;
            for (int i = 0; i < ProductsList.Count; i++)
                ProductsList[i].Path =  ProductsURL + ProductsList[i].Path;
            //Binding Data
            Page.DataBind();
        }
        catch (Exception eqe)
        {
            Response.Redirect("Menu.aspx?category=Beef");
        }
    }
}
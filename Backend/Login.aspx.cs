using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CookDoor.DB_Layer;
using CookDoor.Service_Layer;
public partial class Backend_Login : System.Web.UI.Page
{
    AccountService AS;
    protected void Page_Load(object sender, EventArgs e)
    {
        AS=new AccountService(); 

        Session.Remove("Admin");
           
    }

    protected void btn_Insert_Click(object sender, EventArgs e)
    {
        
            Account x=AS.GetAccountByName(txt_user_name.Text);
            if (x.ID != 0 && x.Password==txt_pass.Text)
            {
                Session["Admin"] = x.Name;
                Response.Redirect("GetProducts.aspx");
            }
            else
            {
                ctrl_Log1.set_Image(false);
                ctrl_Log1.set_LogMsg("User Name or password are incorrect , please retype them and try again");
            }
            }
    

}
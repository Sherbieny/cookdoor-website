using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CookDoor.DB_Layer;

using CookDoor.Service_Layer;
public partial class Backend_AddAccount : System.Web.UI.Page
{
    //Declaring our needed variables
    AccountService As;
    List<Account> AccountsList;
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

           
                As = new AccountService();
                AccountsList = new List<Account>();
                //Invoking DisplayTable function
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
    /// This Function adds a new City Record to the DB
    /// </summary>
    protected void InsertAccount()
    {
        try
        {
            AccountsList = As.GetAccounts();
            //Initializes Needed Variable
            Account l = new Account();
            //Getting input data
           
            l.Name = txt_user_name.Text;
            l.Password=txt_pass_again.Text;

            if(txt_pass_again.Text!=txt_pass.Text)
            {
                                //Display Error Message
                ctrl_Log1.set_LogMsg("Passwords does Not Match");
                ctrl_Log1.set_Image(false);
                return;
            }

            if(txt_pass_again.Text.Length<6)
            {
                                //Display Error Message
                ctrl_Log1.set_LogMsg("Passwords must be at least 6 characters");
                ctrl_Log1.set_Image(false);
                return;
            }

            //This next step is to check that the City doesnot exist already in the DB
            bool existsFlag = false;
            for (int i = 0; i < AccountsList.Count; i++)
            {
                if (AccountsList[i].Name == l.Name)
                    existsFlag = true;
            }
            //If City is new
            if (!existsFlag)
            {
              
                As.addAccount(l);
                txt_pass.Text = "";
                txt_pass_again.Text = "";
                txt_user_name.Text = "";
                ctrl_Log1.set_LogMsg("DataUpdatedSuccesfully");
                ctrl_Log1.set_Image(true);
            }
            else
            {
                //Display Error Message
                ctrl_Log1.set_LogMsg("Account Name Exists");
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
        InsertAccount();
    }
}
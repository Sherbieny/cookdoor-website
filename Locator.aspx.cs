using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CookDoor.DB_Layer;
using CookDoor.Service_Layer;

public partial class Locator : System.Web.UI.Page
{
    BranchService BS;
    public List<Branch> BranchesList;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        BS = new BranchService();
        BranchesList = new List<Branch>();
        BranchesList = BS.GetBranches();
    }
}
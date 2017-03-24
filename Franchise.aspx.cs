using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Franchise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Download_PDF(object sender, EventArgs e)
    {
        Response.ContentType = "Application/doc";
        Response.AppendHeader("Content-Disposition", "attachment; filename=Franchise.doc");
        Response.TransmitFile(Server.MapPath("~/Files/Franchise_Application_Form cookdoor.doc"));
        Response.End();
    } 
}
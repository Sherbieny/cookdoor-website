using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Log : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void reset()
    {
        lb_error.Text = "";
        img_success.Visible = false;
        img_error.Visible = false;
    }
    public void set_LogMsg(string msg)
    {
        lb_error.Text = msg;
        lb_error.Visible = true;
    }
    public void set_Image(bool success)
    {
        if (success)
        {
            img_success.Visible = true;
            lb_error.ForeColor = System.Drawing.Color.Green;
            img_error.Visible = false;
        }
        else
        {
            img_success.Visible = false;
            lb_error.ForeColor = System.Drawing.Color.Red;
            img_error.Visible = true;
        }
    }
}
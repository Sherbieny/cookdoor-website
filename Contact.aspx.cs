using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       

    }

    public void sendMail( object sender , EventArgs e)
    {
        SmtpClient client = new SmtpClient();
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.EnableSsl = true;
        client.Host = "smtp.gmail.com";
        client.Port = 587;

        // setup Smtp authentication
        System.Net.NetworkCredential credentials =
            new System.Net.NetworkCredential("cookdoorwebsite@gmail.com", "Cookdoor52");
        client.UseDefaultCredentials = false;
        client.Credentials = credentials;

        MailMessage msg = new MailMessage();
        msg.From = new MailAddress("cookdoorwebsite@gmail.com");
        msg.To.Add(new MailAddress("info@cookdoor.com.eg"));

        msg.Subject = "Message from cookddoor.eg website user";
        msg.IsBodyHtml = true;
        msg.Body = string.Format(
                                 "<html><head></head><body><b> Mail From : "+String.Format("{0}", txt_email.Text)+
                                 "<br/> Name    : "+String.Format("{0}", txt_name.Text)+
                                 "<br/> Phone   :   " + String.Format("{0}", txt_phone.Text) +//Request.Form["txt_phone"]
                                 "<br/> Message :   "+String.Format("{0}", txt_message.Text)+
                                 "</b></body>"
                                 );

        
        try
        {
            client.Send(msg);
            ctrl_Log1.set_Image(true);
            ctrl_Log1.set_LogMsg("Mail sent");
        }
        catch (Exception ex)
        {
            ctrl_Log1.set_Image(false);
            ctrl_Log1.set_LogMsg("Error occured while sending your message." + ex.Message);
        }
    }
}
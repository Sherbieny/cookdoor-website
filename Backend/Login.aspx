<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Backend_Login" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Log.ascx" TagName="ctrl_Log" TagPrefix="uc1" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"> 
  <link href='https://fonts.googleapis.com/css?family=Archivo+Narrow' rel='stylesheet' type='text/css'>  
    <style type="text/css">
        .style1
        {
            width: 352px;
        }
    </style>


    <title></title>
    <link href="../App_Themes/CDThemes/back.css" rel='stylesheet' type='text/css' />
  <div id="header">

<table style="width:100%">

    <tr>
        <td style="width:80%">
            <ul id='menu'>
	            <li><a href="#" style="font-size:14px; font-weight:bold">Welcome to Cook Door&trade; Adminstration Portal</a>
                </li>
            </ul>
        </td>
        <td class="icon">
           <a href="../Home.html"><img src="../Images/logog.png" height="90px" style="float:center"  /></a>
        </td>


    </tr>
</table>
</div>

</head>
<body class="loginBody">
    <form id="form1" runat="server">

    <div id ="center">




   <table style="height:180px; vertical-align:top; margin:0 auto 0 auto">
        
        <tr>
            
            <td><uc1:ctrl_Log ID="ctrl_Log1" runat="server" /> </td>
        </tr>
    </table> 
    <asp:Panel ID="Panel1" CssClass="loginPanel" runat="server">
        <table  style="vertical-align:top; margin:0 auto 0 auto">
            <tr>
                <td>UserName : 
                <asp:TextBox ID="txt_user_name" MaxLength="100" runat="server" ToolTip=""></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="Req1" Enabled="true" Text="Required!" runat="server" ControlToValidate="txt_user_name"></asp:RequiredFieldValidator>
                    
                </td>
                <td>
                    <asp:Button ID="btn_Report"   
                    Text="Login" CssClass="button"  runat="server" onclick="btn_Insert_Click" />
                </td>
           </tr>
           <tr>
                   
                <td>
                Password : &nbsp;
                    <asp:TextBox TextMode="Password" ID="txt_pass"  MaxLength="100" runat="server" ToolTip="" ></asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" Enabled="true" Text="Required!" runat="server" ControlToValidate="txt_pass"></asp:RequiredFieldValidator>
              
                </td>
           </tr>
           
         
        </table>
   </asp:Panel>
   
   <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
   

    </div>
    <div id="footer" class="abyad">
    <br />
        All Copyrights 2013 © reserved to COOK DOOR Egypt
        <br />
        Powered By S&S&trade;
    </div>
    </form>
</body>
</html>


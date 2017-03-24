<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>
<%@ Register Src="~/Controls/Log.ascx" TagName="ctrl_Log" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html lang="en">
<head>
  	<title>Contact us</title>
			<script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false"></script>

        <script type="text/javascript">
            //That function is responsible for showing the panel (UpdateProgress) , notice the id of the panel is (UpdateProgress1)
            function ShowProgress() {
                document.getElementById('<% Response.Write(UpdateProgress1.ClientID); %>').style.display = "inline";
            }
            //This function is responsible for hiding the panel , after finishing processing
            function HideDiv() {
                document.getElementById('<% Response.Write(UpdateProgress1.ClientID); %>').style.display = "none";
            }


            var map;
            var geocoder;
            function InitializeMap() {
                var latlng = new google.maps.LatLng(30.179709, 31.466658);
                var myOptions =
        {
            zoom: 15,
            center: latlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            disableDefaultUI: true
        };
                map = new google.maps.Map(document.getElementById("map"), myOptions);

            }
            window.onload = InitializeMap;
        </script>

		<meta charset="utf-8">
		<meta name="description" content="Your description">
		<meta name="keywords" content="Your keywords">
		<meta name="author" content="Your name">
    <link rel="stylesheet" href="App_Themes/CDThemes/style.css">
<link href='http://fonts.googleapis.com/css?family=Archivo+Narrow' rel='stylesheet' type='text/css'>
<link href='http://fonts.googleapis.com/css?family=Share+Tech+Mono' rel='stylesheet' type='text/css'>
      <script src="js/jquery-1.7.1.min.js"></script>
    
</head>
<body class="contact">
<form method="post" runat="server" id="form2">
						
                        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
<!-- Header -->
<header>
	<div class="container_12">
    	<div>
        	<article class="grid_5">
                <div class="wrapper">
                    <h1><a class="rotate" href="home.html"></a></h1>
                </div>
            </article>
            <article class="grid_7" style="margin-left:120px;">
                <nav>
                    <ul class="menu4">
                        <li class="active"><a href="Home.html">Home</a></li>
                        <li><a href="About.html">About us</a></li>
                        <li><a href="Menu.aspx">Menu </a></li>
                        <li ><a class="whity"  href="contact.aspx">Contact us</a></li>
                    </ul>
                </nav>
            </article>
            <div class="clear"></div>
    </div>
</header>

<!-- Content -->
<div class="panela">
	<table style="width:95%;margin-left:30px;margin-top:30px;">
		<tr>
			<td width="40%">
					<table>
						<tr>
							<td>
							            <h3 style="color:rgb(61,134,38)">
                                        Contact Info
                                        </h3> 
								
							</td>
						</tr>
						<tr>
							<td>
								<table>
                                    <tr><td width="30%" class="fonth">Address</td><td class="fonta">31St.,Industrial zone, El-Obour Account Block 13014.</td></tr>
									<tr><td width="30%" class="fonth">Phone</td><td class="fonta">+2 02 461 41 890</td></tr>
									<tr><td width="30%" class="fonth">Fax</td><td class="fonta">+2 02 461 41 894</td></tr>
									<tr><td width="30%" class="fonth">Email</td><td class="fonta">info@cookdoor.com.eg</td></tr>
								</table>
                                <br />
							</td>
						</tr>
						<tr>
							<td>
								<figure class="figure-1 p1">
									<div  id="map" style="height:220px !important;width:350px"></div>
								</figure>
							</td>
						</tr>
					</table>
			</td>
			
            <td width="10%"></td>
					
			<td width="50%">
					<table>
					<tr>
						<td>
                              <h3 style="color:rgb(61,134,38)">
                                Customer Service
                              </h3>
						</td>
					</tr>
					<tr>
						<td>
							<p class="fonta">
								If you have any
								comments or suggestions you are more
								than welcome to contact mail us.
							</p>
                            
						</td>
						<td width="10%">
						</td>
					</tr>
                    <tr>
                        <td style="height:8px;vertical-align:top">
                            
                            <asp:UpdateProgress  ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                            <div id="theDiv" runat="server"><img  src="Images/load.gif" />&nbsp; <strong>Processing... Please wait </strong></div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        </td>
                    </tr>
					<tr>
						<td>
                        	<asp:TextBox runat="server" id="txt_name" name="txt_name" class="Box" style="height:30px;"  placeholder="NAME"/>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ErrorMessage="*" Font-Size="Medium" ForeColor="Red" ControlToValidate="txt_name" ></asp:RequiredFieldValidator> 
                            <br/><br/>
							<asp:TextBox runat="server" id="txt_email" name="txt_email" class="Box" style="height:30px;"  placeholder="EMAIL"/>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="*" Font-Size="Medium" ForeColor="Red" ControlToValidate="txt_email" ></asp:RequiredFieldValidator> 
                            <br/><br/>
							<asp:TextBox runat="server" id="txt_phone" name="txt_phone" class="Box" style="height:30px;" placeholder="PHONE"/>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ErrorMessage="*" Font-Size="Medium" ForeColor="Red" ControlToValidate="txt_phone" ></asp:RequiredFieldValidator> 
                            <cc1:FilteredTextBoxExtender FilterType="Numbers" runat="server" TargetControlID="txt_phone"></cc1:FilteredTextBoxExtender>
                            <br/><br/>
							<asp:TextBox runat="server" TextMode="MultiLine" id="txt_message" name="txt_message" class="Box" style="height:70px;" placeholder="MESSAGE"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ErrorMessage="*" ForeColor="Red" Font-Size="Medium" ControlToValidate="txt_message" ></asp:RequiredFieldValidator> 
						</td>
					</tr>
                    <tr>
                        <td>    
                            <table>
                                    <tr>
                                        <td style="width:50%;text-align:left">
                                             <uc1:ctrl_Log ID="ctrl_Log1" runat="server" /> 
                                        </td>
                                        <td style="width:50%;text-align:right">
                                            <asp:Button Text="Send Mail" OnClientClick="if(Page_ClientValidate())ShowProgress();" OnClick="sendMail" CssClass="button" runat="server" ID="btn" />
                                        </td>
                                    </tr>
                            </table>
                        </td>   
                    </tr>
					</table>
			</td>
			
		</tr>
	</table>
</div>

<!-- <section id="content" class="page1">
 -->
 <br/>
<table class="bottomMenu" >
<tr>
<td align="c*">
                <a href="https://www.facebook.com/pages/Cookdoor/118413855008108"><img class="rotate" style="width:32px;height:32px;margin-top:2px;" src="Images/face.png" alt=""></a>
            	&nbsp;
                <a href="http://www.youtube.com/watch?v=98HOeZy8c2E"><img class="rotate"  style="width:32px;height:32px; margin-top:2px;" src="Images/you.png" alt=""></a>
                <a href="http://www.otlob.com"><img class="rotate"  style="width:40px;height:40px;" src="Images/otlobBas.png" alt=""></a>
                
</td>
<td>
                    <ul class="menu3">
                        <li ><a  href="franchise.aspx">Franchise</a></li>
                        <li><a href="locator.aspx">Store Locator </a></li>
                        <li><a href="join.html">Join Our Team</a></li>
                    </ul>
</td>
</tr>
</table>

	    	
					<br />
	<div class="bottomMenu2">
    	   <table style="width:100%">
           <tr>
           <td style="width:40%;">
                   <img src="Images/dial.png"/>
           </td>
           <td style="width:60%;text-align:right;color:White;font-size:medium;font-weight:normal;">
                   All Copyrights 2013 © reserved to COOK DOOR Egypt
                   <br />
                   Powered by <strong><a href="http://www.cshark.co/" style="color:rgb(141,223,250);" title="CShark | Developments">CSHARK</a></strong> 
          </td>
           
          </tr>
          </table>
           
      </div> 
      </form>
						      
</body>
</html>

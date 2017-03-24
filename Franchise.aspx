<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Franchise.aspx.cs" Inherits="Franchise" %>
<!DOCTYPE html>
<html lang="en">
<head>
  	<title>Franchise</title>
	
  	<meta charset="utf-8">
    <meta name="description" content="Your description">
    <meta name="keywords" content="Your keywords">
    <meta name="author" content="Your name">
    <link rel="stylesheet" href="App_Themes/CDThemes/style.css">
    <link href='http://fonts.googleapis.com/css?family=Share+Tech+Mono' rel='stylesheet' type='text/css'>


    <link href='http://fonts.googleapis.com/css?family=Archivo+Narrow' rel='stylesheet' type='text/css'>

    <script src="js/jquery-1.7.1.min.js"></script>
    <script src="js/script.js"></script>

</head>
<body class="franchise">
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
                        <li  ><a href="Home.html">Home</a></li>
                        <li><a href="About.html">About us</a></li>
                        <li><a href="Menu.aspx">Menu </a></li>
                        <li ><a href="contact.aspx">Contact us</a></li>
                    </ul>
                </nav>
            </article>
            <div class="clear"></div>
    </div>
</header>

<!-- Content -->
<div class="panela">
	<table width="90%" style="margin-left:30px;margin-top:20px;">
		<tr>
			<td width="60%">
				<table>
						<tr>
							<td>
								Cook Door is an expanding business,
								offering a profitable opportunity to the right individuals.
								As a franchisee, you will step into the
								experienced shoes of these
								established companies. Not only will
								you be able to reduce the risks by
								using the system, but you will benefit
								from the services and products
								provided under an 
								established name.
                                <br /><br />
								We developed a
								comprehensive support system to
								help franchisees with everything
								from start-up and marketing,
								daily operations.
							</td>
						</tr>
                        <tr>
                            <td>
                               <br />
                                <form id="forma" runat="server"><img src="Images/pdf.png" /><asp:linkButton CssClass="blackyy bottomz"  ID="btn_download" Text="Download Application" OnClick="Download_PDF" runat="server"></asp:linkButton>
                                </form>
                            </td>
                        </tr>
				</table>
			</td>
			<td width="15%">
				
			</td>
			<td width="35%"  valign="top">
				<img src="Images/toto_min.jpg"/>
			</td>
		</tr>
	</table>
</div>

<!-- <section id="content" class="page1">
 -->
 <br/>
<table class="bottomMenu" >
<tr>
<td align="center">
                <a href="https://www.facebook.com/pages/Cookdoor/118413855008108"><img class="rotate" style="width:32px;height:32px;margin-top:2px;" src="Images/face.png" alt=""></a>
            	&nbsp;
                <a href="http://www.youtube.com/watch?v=98HOeZy8c2E"><img class="rotate"  style="width:32px;height:32px; margin-top:2px;" src="Images/you.png" alt=""></a>
                <a href="http://www.otlob.com"><img class="rotate"  style="width:40px;height:40px;" src="Images/otlobBas.png" alt=""></a>
                
</td>
<td>
                    <ul class="menu3">
                        <li ><a class="whity" href="franchise.aspx">Franchise</a></li>
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
      
 </body>
</html>

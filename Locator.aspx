<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Locator.aspx.cs" Inherits="Locator" %>

<!DOCTYPE html>
<html lang="en">
<head>
  	<title>Store Locator</title>
	
  	<meta charset="utf-8">
    <meta name="description" content="Your description">
    <meta name="keywords" content="Your keywords">
    <meta name="author" content="Your name">
    <link rel="stylesheet" href="App_Themes/CDThemes/style.css">
<link href='http://fonts.googleapis.com/css?family=Share+Tech+Mono' rel='stylesheet' type='text/css'>
<link href='http://fonts.googleapis.com/css?family=Archivo+Narrow' rel='stylesheet' type='text/css'>

    <script src="js/jquery-1.7.1.min.js"></script>

<script type="text/javascript">
    $('img').hover(function () {
        
        $(this).attr('src', 'Images/dot.png');
    }, function () {
        alert("brr");
        $(this).attr('src', 'Images/dotred.png');
    });
</script>
</head>
<body class="locator">
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
                        <li><a href="home.html">Menu </a></li>
                        <li ><a href="contact.aspx">Contact us</a></li>
                           
                    </ul>
                </nav>
            </article>
            <div class="clear"></div>
    </div>
</header>

<!-- Content -->
<div class="panela">
	<table  style="border-color:black;margin-left:30px;margin-top:30px;width:90%;height:90%;">
		<tr>
			<td width="40%">
            <br />
				<h2 style="color:rbg(61,33,26) !important;">Branch</h2>
			</td>
			<td width="23%">
            <br/>
			<h2 style="color:rbg(61,33,26) !important;">City</h2>
            </td>
			<td width="7%" style="vertical-align:middle;">
				<img src="Images/otlobBas.png" width="55px" height="55px"/>
			</td>
			<td width="15%">
				
			</td>
			<td style="vertical-align:middle;" align="left">
				<img src="Images/face.png" width="50px" height="50px"/>
			</td>
		</tr>

		


        <% 
            bool flag = true;
            
            for (int i = 0; i < BranchesList.Count; i++)
            {
               if (!flag)
               {
                 %>
		    <tr>
               <%}
               else
               {%>
               <tr style="background-color:rgb(230,230,230)" >
             <%}
                   flag = !flag;%>
			<td style="height: 30px;vertical-align:middle;" width="40%" class="fontcc" >
				<%= BranchesList[i].Name %> <br/>
			</td>
			<td width="23%" style="vertical-align:middle" class="fontcc" >
            <%= BranchesList[i].City_Name %>
			</td>
			<td width="7%" valign="bottom">
				&nbsp;&nbsp;<a href="<%= BranchesList[i].Otlob %>"><img class="imageid"  src="Images/dot.png" /></a>
			</td>
			<td width="15%">
				
			</td>
			<td width="17%" valign="bottom">
				&nbsp;&nbsp;<a href="https://www.facebook.com/CookDoorChain/app_444308208984853"><img src="Images/dot.png"/></a>
			</td>
		</tr>
        <% } %>
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
                        <li ><a  href="franchise.aspx">Franchise</a></li>
                        <li><a class="whity" href="locator.aspx">Store Locator </a></li>
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

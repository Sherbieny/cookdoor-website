<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Menu.aspx.cs" Inherits="Menu_lo" %>

<!DOCTYPE html>
<html  lang="en">
<head>



   	<title>Menu</title>
	
  	<meta charset="UTF-8">
    <meta name="description" content="Your description">
    <meta name="keywords" content="Your keywords">
    <meta name="author" content="Your name">
    <link rel="stylesheet" href="App_Themes/CDThemes/style.css">
<link href='http://fonts.googleapis.com/css?family=Share+Tech+Mono' rel='stylesheet' type='text/css'>
<link href='http://fonts.googleapis.com/css?family=Archivo+Narrow' rel='stylesheet' type='text/css'>



	<script type="text/javascript" src="js/jquery-1.7.1.min.js"></script>
	<script type="text/javascript" src="js/jquery-easing-1.3.pack.js"></script>
	<script type="text/javascript" src="js/jquery-easing-compatibility.1.2.pack.js"></script>
	<script type="text/javascript" src="js/coda-slider.1.1.1.pack.js"></script>
    <script type="text/javascript">
        function Togglezz(x) {
            window.location.href = "Menu.aspx?category=" + x;
        }

        var theInt = null;
        var $crosslink, $navthumb;
        var curclicked = 0;

        theInterval = function (cur) {
            clearInterval(theInt);

            if (typeof cur != 'undefined')
                curclicked = cur;

            $crosslink.removeClass("active-thumb");
            $navthumb.eq(curclicked).parent().addClass("active-thumb");
            $(".stripNav ul li a").eq(curclicked).trigger('click');

            theInt = setInterval(function () {
                $crosslink.removeClass("active-thumb");
                $navthumb.eq(curclicked).parent().addClass("active-thumb");
                $(".stripNav ul li a").eq(curclicked).trigger('click');
                //curclicked++;
                if (curclicked == 4 /** Change this dynamically acccording to the number of elements you want to view **/)
                    curclicked = 0;

            }, 3000);
        };

        $(function () {
            $("#main-photo-slider").codaSlider();

            $navthumb = $("#movers-row > ul > li > ul > li > div > a > span");
            $crosslink = $("#movers-row > ul > li > ul > li > div > a");

//            $navthumb
//			.click(function () {
//			    var $this = $(this);
//			    alert($this.parent().attr('href').slice(1) - 1);
//			    theInterval($this.parent().attr('href').slice(1) - 1);
//			    return false;
//			});

            //theInterval();
        });

        function sameer(s) {
            theInterval(s);
            return false;
        }
	</script>

</head>
<body class="menuuu">
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
                        <li><a class="whity" href="Menu.aspx">Menu </a></li>
                        <li ><a href="contact.aspx">Contact us</a></li>
                    </ul>
                </nav>
            </article>
            <div class="clear"></div>
    </div>
</header>

<!-- Content -->
<%--<div id="slideshow-wrap">
        <label for="button-1" class="arrows" id="arrow-1">></label>
        <label for="button-2" class="arrows" id="arrow-2">></label>
        <label for="button-3" class="arrows" id="arrow-3">></label>
        <label for="button-4" class="arrows" id="arrow-4">></label>
        <div id="slideshow-inner">
            <ul>
                <li id="slide1">
                    <img class="mohmoh" src="Images/44.jpg" />

                </li>
                <li id="slide2">
                    <img class="mohmoh" src="Images/44.jpg" />

                </li>
                <li id="slide3">
                    <img class="mohmoh" src="Images/44.jpg" />

                </li>
                <li id="slide4">
                    <img class="mohmoh" src="Images/44.jpg" />
                </li>

            </ul>
        </div>
    </div>	
--%>





		<div id="main-photo-slider">
			<div class="panelContainer">
					
     <% for (int i = 0; i < ProductsList.Count; i++)
       { 
         %>
         <div class="panel" title="Panel <%=i%>">
				
          <img class="rounded" src="<%=ProductsList[i].Path %>"  />
          </div>
    <% } %>
    </div>
  </div>
        
  
  







<br />
 

 <table class="menuTableUp">
    <tr>
    <% for (int i = 0; i < CategoriesList.Count; i++)
       { 
           %>
           <td class="menuTableCell">
           <%
            if (category == CategoriesList[i].Name)
            {
                %>
      
           <%=CategoriesList[i].Name %>
             <% } else{%>
              <%=CategoriesList[i].Name %>
             <% } %>
            </td>
    <% } %>
    </tr>
 </table>


  <div class="menuBar" id="mainHolder">

  <table class="menumenu" >
    <tr>
    <% 
        for (int i = 0; i < CategoriesList.Count; i++)
        
        {
            if (category == CategoriesList[i].Name)
            {
    %>
       
            <td onclick="Togglezz('<%=CategoriesList[i].Name %>');" class="theCellred"></td>
    <% }
            else
            {%>
            <td onclick="Togglezz('<%=CategoriesList[i].Name %>');"  class="theCell"></td>
     <% }
   }%>
    </tr>
 </table>
</div>
<br />

   <table class="menuTableDown">
    <tr>
    <% 
       for (int f = 0;f < CategoriesList.Count; f++)
       { 
    %>
            <td>
                <div id="movers-row" class="cxxmenu">
                     <% 
                       if (category == CategoriesList[f].Name)
                       {
                           %>
                      <ul >
                          <li><a href="Menu.aspx?Category=<%=CategoriesList[f].Name%>"><img src='<%= CategoriesList[f].Path %>' /></a>
                                
        	                   <ul >
                                   <%for (int j = 0; j < ProductsList.Count; j++)
                                     { 
                                   %>
                                        <li ><div><%--<label id="#<%=j+1%>" onclick="sameer(this)"><%=ProductsList[j].Name%></label>--%><a  onclick="sameer(<%=j%>);" ><span><%=ProductsList[j].Name%></span></a></div></li>
                                        
                                   <% }%>
                                       
                               </ul>
                               </div>
                          </li>
               
                      </ul>
            <% }
                else
            {%>
               <div class="categoryfader">
               <a href="Menu.aspx?Category=<%=CategoriesList[f].Name%>"><img  src='<%= CategoriesList[f].Path %>' /></a>
              </div>
          <%} %>
                 </div>
             </td>
    <% } %>
    </tr>
 </table>

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

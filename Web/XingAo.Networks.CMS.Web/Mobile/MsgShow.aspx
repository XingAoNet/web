<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MsgShow.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Mobiles.MsgShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title><%=title%></title>
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1.0,user-scalable=no;"/> 
    <link href="/Styles/css.css" rel="stylesheet" type="text/css" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
	<meta name="apple-touch-fullscreen" content="YES" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <link href="/Styles/WebSite/comm.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/Scripts/jquery.js"></script>
    <script src="/Scripts/Mobile/menu.js" type="text/javascript"></script>
    <script src="/Scripts/Mobile/WebSite.js" type="text/javascript"></script>
</head>
<body>
    <div id="header" class="bgcolor">
        <a id="return" class="left" href="<%=url%>"></a>
	    <span class="title"><%=title%></span>
    </div>
    <div style="display:none;" class="webAbstract"><%=model.Abstract%></div>
    <% if (model != null)
       { %>
        <div class="cardexplain">
            <ul class="round">
		        <li><h2><%=model.Title%></h2></li>
                <%if (model.IsShowTime == 1)
                  {%>
                <li><%=model.IDateTime%></li>
                <%} %>
            </ul>
        </div>
         <%if (model.IsShow == 1)
           { %>
         <div class="cardexplain">
            <ul class="round">
		        <li><div class="text"><img src="<%=model.PictuerAdress%>" alt="" /></div></li>
	        </ul>
        </div>
        <%} %>
        <div class="cardexplain">
            <ul class="round">
                <li><div class="text"><%=model.DetailedContent%></div></li>
	        </ul>
        </div>
        <%if (!string.IsNullOrEmpty(model.Url))
          { %>
        <div class="cardexplain">
            <ul class="round">
                <li><a href="<%=model.Url%>">原文地址</a></li>
	        </ul>
        </div>  
       <%}
       }
       else
       {%>
       <div class="cardexplain">
            <ul class="round">
                <li><div class="text">内容已经被删除或者参数错误！</div></li>
	        </ul>
        </div>
       <%} %>
       <script src="/Scripts/Mobile/OriginalPic.js" type="text/javascript"></script>
        <wmf:MobileFoot runat="server" ></wmf:MobileFoot>
        <mh:MobileHelp runat="server" ID="MobileHelp1"></mh:MobileHelp>        
</body>
</html>


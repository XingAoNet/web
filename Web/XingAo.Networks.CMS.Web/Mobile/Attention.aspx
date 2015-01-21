<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attention.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Mobile.Attention" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title><%=title%></title>
    <meta name="viewport" content="width=device-width,minimum-scale=1,user-scalable=no,maximum-scale=1,initial-scale=1" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
   <link href="/Styles/WebSite/comm.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/Scripts/jquery.js"></script>
    <script src="/Scripts/Mobile/menu.js" type="text/javascript"></script>
    <script src="/Scripts/Mobile/WebSite.js" type="text/javascript"></script>
</head>
<body>
    <div id="header" class="bgcolor">
		<span class="title"><%=Request.QueryString["title"]%></span>
        <a id="menu" href="/Mobile/Website/?wxid=<%=wxid %>" class="right"><img src="/images/list.png" alt="" /></a>
	</div>
      <% if (Model!=null)
       { %>
        <div class="cardexplain">
            <ul class="round">
		        <li><h2><%=Model.Title%></h2></li>
                <li><%=Model.IDateTime%></li>
	        </ul>
        </div>
         <%if (Model.IsShow==1)
           { %>
         <div class="cardexplain">
            <ul class="round">
		        <li><div class="text"><img src="<%=Model.PictuerAdress%>" alt="" /></div></li>
	        </ul>
        </div>
        <%} %>
        <div class="cardexplain">
            <ul class="round">
                <li><div class="text"><%=Model.DetailedContent%></div></li>
	        </ul>
        </div>
         
       <%}
       else
       {%>
       <div class="cardexplain">
            <ul class="round">
                <li><div class="text">内容已经被删除或者参数错误！</div></li>
	        </ul>
        </div>
       <%} %>
       <div class="cardexplain">© 星奥科技 </div>

</body>
</html>

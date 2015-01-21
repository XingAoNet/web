<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info_Img.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Mobile.Website.Info_Img" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        <a id="return" class="left"  href="<%=url%>"></a>
		<span class="title"><%=title%></span>
        <a id="menu" href="javascript:;" class="right"><img src="/images/list.png" alt="" /></a>
         <asp:Repeater ID="RpMemu" runat="server">
            <HeaderTemplate><ul id="menulist" class="dropdown-menu right-menu radius"></HeaderTemplate>
            <ItemTemplate>
                <li><a class="menu-item" title="" href="" _d="<%=wxid%>" data="({'ShowType':'<%#Eval("config.ShowType")%>','source':'<%#Eval("config.Source")%>','InfoID':'<%#Eval("config.InfoID")%>','Title':'<%#Eval("config.Title") %>'})"><i class="icon icon-1"></i><%#Eval("config.Title")%></a></li>
            </ItemTemplate>
            <FooterTemplate></ul></FooterTemplate>
         </asp:Repeater>
	</div>
    <div style="display:none;" class="webAbstract"><%=Abstract%></div>
    <% if (HasErr)
       { %>
        <div class="cardexplain">
            <ul class="round">
		        <li><h2><%=title%></h2></li>
                <%if (IsShowTime == "1")
                  {%>
                <li><%=IDateTime%></li>
                <%} %>
	        </ul>
        </div>
         <%if (IsShow)
           { %>
         <div class="cardexplain">
            <ul class="round">
		        <li><div class="text"><img src="<%=PictuerAdress%>" alt="" /></div></li>
	        </ul>
        </div>
        <%} %>
        <div class="cardexplain">
            <ul class="round">
                <li>
                <div class="text"><%=DetailedContent%></div>
                 <div id="CheckPraise" style="cursor:pointer;text-align:center;color:Blue;display:none;">赞 <%=Praise%></div>

                </li>
	        </ul>
        </div>
        <%if (!string.IsNullOrEmpty(Url))
          { %>
        <div class="cardexplain">
            <ul class="round">
                <li><a href="<%=Url%>">原文地址</a></li>
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
    <script type="text/javascript">
        $("#CheckPraise").click(function ()
        {
            $.post("CheckPraise.ashx", { keys: "<%=Keys %>",openid:"<%=Request.QueryString["openid"] %>" },
                function (result)
                {
                    $("#CheckPraise").html("赞 " + <%=Praise+1%>);
                }, "json");
        });
    </script>
    <script src="/Scripts/Mobile/OriginalPic.js" type="text/javascript"></script>
        <wmf:MobileFoot ID="MobileFoot1" runat="server" ></wmf:MobileFoot>
        <mh:MobileHelp runat="server" ID="MobileHelp1"></mh:MobileHelp>
</body>
</html>

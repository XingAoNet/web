<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationList.aspx.cs"
    Inherits="XingAo.Networks.CMS.Web.Mobile.Registration.RegistrationList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
    <title></title>
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
        <a id="return" class="left" href="javascript:history.go(-1);"></a>
		<span class="title"><%=Request.QueryString["title"]%></span>
        <a id="menu" href="javascript:;" class="right"><img src="/images/list.png" alt="" /></a>
        <asp:Repeater ID="RpMemu" runat="server">
            <HeaderTemplate><ul id="menulist" class="dropdown-menu right-menu radius"></HeaderTemplate>
            <ItemTemplate>
                <li><a class="menu-item" title="" href="" _d="<%=wxid%>" data="({'ShowType':'<%#Eval("config.ShowType")%>','source':'<%#Eval("config.Source")%>','InfoID':'<%#Eval("config.InfoID")%>','Title':'<%#Eval("config.Title") %>'})"><i class="icon icon-1"></i><%#Eval("config.Title")%></a></li>
            </ItemTemplate>
            <FooterTemplate></ul></FooterTemplate>
         </asp:Repeater>
	</div>

    <div id="mainmenu" class="fn-clear">
        <asp:Repeater ID="RegList" runat="server">
            <HeaderTemplate><ul></HeaderTemplate>
            <ItemTemplate>
                <li>
                    <a href="RegistrationHead.aspx?openid=<%=Request.QueryString["openid"]%>&aguid=<%#Eval("AGuid")%>" style="text-decoration:none">
                        <p class="title"><%#Eval("Title")%></p>
                        <p class="summary"><%#Eval("IDateTime").ToString()%></p>
                        <img src="<%#Eval("PictureAddress") %>" alt="France" class="ui-li-heading"></img>
                        <div class="right-arrow"></div>
                    </a>
                </li>
            </ItemTemplate>
            <FooterTemplate></ul></FooterTemplate>
        </asp:Repeater>
    </div>  
        <wmf:MobileFoot runat="server" ></wmf:MobileFoot>
        <mh:MobileHelp runat="server" ID="MobileHelp1"></mh:MobileHelp>
</body>
</html>

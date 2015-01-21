<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MsgList.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Mobiles.MsgList" %>
<%@ Import Namespace="XingAo.Core" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" /> 
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <script type="text/javascript" src="/Scripts/jquery.js"></script>
    <script src="/Scripts/Mobile/menu.js" type="text/javascript"></script>
    <script src="/Scripts/Mobile/WebSite.js" type="text/javascript"></script>
    <link href="/Styles/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
     <div id="header" class="bgcolor">
		<span class="title"><asp:Literal ID="LiTitle" runat="server"></asp:Literal></span>
	</div>
    <div id="mainmenu" class="fn-clear">
        <asp:Repeater ID="ListRp" runat="server">
            <HeaderTemplate><ul></HeaderTemplate>
            <ItemTemplate>
                <li>
                    <a href="MsgShow.aspx?id=<%#Eval("Id")%>" style="text-decoration:none;">
                        <p class="title"><%#Eval("Title")%></p>
                        <p class="summary"><%#Eval("IDateTime").ToString()%></p>
                        <img src="<%#Eval("PictuerAdress")%>" class="ui-li-heading"/>
                        <div class="right-arrow"></div>
                    </a>
                </li>
            </ItemTemplate>
            <FooterTemplate></ul></FooterTemplate>
        </asp:Repeater>
    </div>   
        <wmf:MobileFoot runat="server" ></wmf:MobileFoot>
        <mh:MobileHelp runat="server" ID="MobileHelp1"></mh:MobileHelp>
        <script type="text/javascript">
              var titles = "<%=title%>";
        </script>
        <script src="/Scripts/Mobile/wxhelp.js" type="text/javascript"></script>
</body>
</html>

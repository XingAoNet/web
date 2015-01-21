<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowTxt.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Mobile.ShowTxt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
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
    </div>
    <div class="cardexplain">
        <ul class="round">
            <li><div class="text"><%=count%></div></li>
        </ul>
    </div>
        <wmf:MobileFoot  runat="server" ></wmf:MobileFoot>
        <mh:MobileHelp runat="server" ID="MobileHelp1" ></mh:MobileHelp>
</body>
</html>

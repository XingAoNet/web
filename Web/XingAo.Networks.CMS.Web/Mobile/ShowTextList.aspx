<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowTextList.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Mobile.ShowTextList" %>
<%@ Import Namespace="XingAo.Core" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head id="Head1" runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" /> 
    <script type="text/javascript" src="/Scripts/jquery.js"></script>
    <link href="/Scripts/jquery.mobile.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/Scripts/jquery.mobile-1.1.0.min.js"></script>
</head>
<body>
    <div data-role="page">
        <div data-role="content">
            <asp:Repeater ID="ListRp" runat="server">
                <HeaderTemplate><ul data-role="listview" data-split-icon="gear"></HeaderTemplate>
                <ItemTemplate><li><a href="MsgShow.aspx?id=<%#Eval("Id")%>">
                <img src="<%#Eval("PictuerAdress")%>" class="ui-li-heading"/><h3><%#Eval("Title")%></h3>
                <p><%#Eval("IDateTime").ToString()%></p></a></li></ItemTemplate>
                <FooterTemplate></ul></FooterTemplate>
            </asp:Repeater>
        </div>
    </div>     
</body>
</html>
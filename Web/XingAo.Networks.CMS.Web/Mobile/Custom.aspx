<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Custom.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Mobile.Custom" %>
<%@ Import Namespace="XingAo.Core" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" /> 
    <script type="text/javascript" src="/Scripts/jquery.js"></script>
    <link href="/Scripts/jquery.mobile.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/Scripts/jquery.mobile-1.1.0.min.js"></script>
</head>
<body>
    <div data-role="page">
        <div data-role="header" data-position="fixed" class="sethead">
        </div>
     <div data-role="content">
        <div class="media text setid">
            
        </div>
        </div>
    </div>
    <script type="text/javascript">
        var EditJson = eval(<%=headjsons%>);
        for (i = 0; i < EditJson.length; i++)
        {
            var typeandcount = EditJson[i].ID.split("_");
            if(EditJson[i].ID=="<%=Request.QueryString["SetId"]%>")
            {          
            var configJson=EditJson[i].Config[0];
            $("<h1>"+(configJson == undefined ? "数据错误" : configJson.Title)+"</h1>").appendTo($(".sethead"));
            $("<p>"+(configJson == undefined ? "数据错误" : configJson.CustomInfo)+"</p>").appendTo($(".setid"));
            } 
        }
    </script>
</body>
</html>

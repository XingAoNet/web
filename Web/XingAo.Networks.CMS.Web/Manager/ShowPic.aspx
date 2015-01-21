<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowPic.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.ShowPic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>图片显示</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" overflow:scroll; width:600px; height:380px;">    
     <img src="<%=picurl %>" alt="" /></div>
    </form>
</body>
</html>

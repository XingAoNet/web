<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoAction.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Collect.DoAction" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head></head>
<body>
<form id="Form1" runat="server">
采集记录数：<asp:TextBox ID="TextNum" CssClass="digits" runat="server"></asp:TextBox>
<asp:Button ID="CollectBtn" runat="server" Text="开始采集" 
    onclick="CollectBtn_Click" />
<asp:Literal ID="LIInfo" runat="server"></asp:Literal>
</form>
</body>
</html>
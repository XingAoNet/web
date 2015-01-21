<%@ Page Language="C#" MasterPageFile="~/UserCenter/UcMaster.Master" AutoEventWireup="true" CodeBehind="EditPwd.aspx.cs" Inherits="XingAo.Networks.CMS.Web.UserCenter.EditPwd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    修改密码

     
        <br />
        旧密码：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        新密码：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        确认新密码：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />

    
</asp:Content>
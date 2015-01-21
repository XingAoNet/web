<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="XingAo.Networks.CMS.Web.UserCenter.ResetPassword" %>

<asp:literal runat="server" ID="Head"></asp:literal>
    <form id="form1" runat="server">
    <div class="Box">
    重置密码<br />
&nbsp;新密码： 
        <asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <br />
        确认密码：<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    </div>
    </form>
<asp:literal runat="server" ID="Foot"></asp:literal>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FindPwd.aspx.cs" Inherits="XingAo.Networks.CMS.Web.UserCenter.FindPwd" %>

<asp:literal runat="server" ID="Head"></asp:literal>
<div class="usercenter">
    <form id="form1" runat="server">
    <div class="container">
        <div class="header">
            <h3 class="logintext">密码找回</h3>
        </div>
        <div class="content">
            <span><label>* 注册邮箱：</label><asp:TextBox ID="txtRegEmail" runat="server"></asp:TextBox></span>
            <span><label>* 验证码：</label><asp:TextBox ID="txtImangeCode" runat="server"></asp:TextBox><img id="ImageCode" onclick="this.src='/ImageCode?r='+new Date()" style="cursor:pointer;" alt="看不清？点击刷新" title="看不清？点击刷新" src="/ImageCode" /></span>
            <span><label>&nbsp;</label><asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="找回密码" /></span>
        </div>
    </div>
    </form>
</div>
<asp:literal runat="server" ID="Foot"></asp:literal>
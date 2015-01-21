<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="XingAo.Networks.CMS.Web.UserCenter.LoginPage" ValidateRequest="false" ViewStateMode="Disabled" ViewStateEncryptionMode="Never" EnableViewStateMac="false" EnableEventValidation="false"%>

<asp:literal runat="server" ID="Head"></asp:literal>
<div class="usercenter">
    <form id="form1" runat="server">
    <div class="container">
        <div class="header">
            <span class="reg">
                <a href="/UserCenter/UserReg">没有帐号？</a>
                <a href="/UserCenter/UserReg">注册</a>
            </span>
            <h3 class="logintext">登录</h3>
        </div>
        <div class="content">
            <span><label>用户名：</label>
                <asp:TextBox ID="Login_User" runat="server"></asp:TextBox>
                <a href="/UserCenter/UserReg" style="color:Blue;">注册</a></span>
            <span><label>密码：</label>
                <asp:TextBox ID="Login_Password" runat="server" TextMode="Password"></asp:TextBox>
                <a href="/UserCenter/FindPwd" style="color:Blue;">找回密码</a></span>
            <span><label>验证码：</label><asp:TextBox ID="Login_VCode" runat="server"></asp:TextBox><img id="ImageCode" onclick="this.src='/ImageCode?r='+new Date()" style="cursor:pointer;" alt="看不清？点击刷新" title="看不清？点击刷新" src="/ImageCode" /> </span> 
            <span><label>&nbsp;</label><input type="checkbox" id="agreement" />自动登录</span>
            <span><label>&nbsp;</label><input id="Submit" class="submit" type="submit" value="登录" /></span>
        </div>
    </div>
    </form>
</div>
<asp:literal runat="server" ID="Foot"></asp:literal>
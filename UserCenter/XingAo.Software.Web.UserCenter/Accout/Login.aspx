<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="XingAo.Software.Web.UserCenter.Accout.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户登录-{@XA_网站标题}</title>
    <meta name="keywords" content="{$XingAo_网站关键字与描述$}"/>
    <meta name="description" content="{$XingAo_网站关键字与描述$}" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="header">
            <span class="reg">
            	<!--连接地址需要根据路由设置修改-->
                <a href="/Accout/Register.aspx">没有帐号？</a>
                <a href="/Accout/Register.aspx">注册</a>
            </span>
            <h3>登录</h3>
        </div>
        <div class="content">
            <span>
            	<label>用户名：</label>
                <input type="text" id="user_name" name="user_name" />
                <a href="/Accout/Register.aspx" style="color:Blue;">注册</a>
            </span>
            <span>
            	<label>密码：</label>
                <input type="password" id="password" name="password" />
                <a href="/Accout/FindPwd.aspx" style="color:Blue;">找回密码</a>
            </span>
            <span>
            	<label>验证码：</label>
                <input type="text" id="v_code" name="v_code" />
                <img id="ImageCode" onclick="this.src='/ImageCode?r='+new Date()" style="cursor:pointer;" alt="看不清？点击刷新" title="看不清？点击刷新" src="/ImageCode" /> 
            </span> 
            <span>
            	<label>&nbsp;</label>
                <input type="checkbox" id="agreement" />自动登录
            </span>
            <span>
            	<label>&nbsp;</label>
                <input id="Submit" class="submit" type="submit" value="登录" />
            </span>
        </div>
    </div>
    </form>
</body>
</html>

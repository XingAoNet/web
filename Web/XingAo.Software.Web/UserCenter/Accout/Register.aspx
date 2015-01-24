<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="XingAo.Software.Web.UserCenter.Accout.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="header">
            <h3 class="logintext">注册</h3>
        </div>
        <div class="content">
            <span>
            	<label>* 用户名：</label>
                <input type="text" id="user_name" name="user_name" />
            </span>
            <span>
            	<label>* 密码：</label>
                <input type="password" id="password" name="password" />
            </span>
            <span>
            	<label>* 确认密码：</label>
                <input type="password" id="password2" name="password2" />
            </span>
            <span>
            	<label>* 真实姓名：</label>
                <input type="text" id="real_name" name="real_name" />
            </span>
            <span>
            	<label>* 邮箱：</label>
                <input type="email" id="email" name="email" />
            </span>
            <span>
            	<label>* 手机：</label>
                <input type="tel" id="phone" name="phone" />
            </span>
            <span>
            	<label>&nbsp;</label>
                <input type="checkbox" id="read_reg" name="read_reg" />
                我已阅读【<a href="#" target="_blank">注册协议</a>】
                <input type="submit" id="submit" name="submit" value="注册" />
            </span>
        </div>
    </div>
    </form>
</body>
</html>

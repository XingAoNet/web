<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FindPwd.aspx.cs" Inherits="XingAo.Software.Web.UserCenter.Accout.FindPwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="header">
            <h3>密码找回</h3>
        </div>
        <div class="content">
            <span>
                <label>* 注册邮箱：</label>
                <input type="text" id="reg_email" name="reg_email" />
            </span>
            <span>
                <label>* 验证码：</label>
                <input type="text" id="image_code" name="image_code" />
                <img id="ImageCode" onclick="this.src='/ImageCode?r='+new Date()" style="cursor:pointer;" alt="看不清？点击刷新" title="看不清？点击刷新" src="/ImageCode" />
            </span>
            <span>
                <label>&nbsp;</label>
                <input type="submit" id="find_pwd" name="find_pwd" value="找回密码" />
            </span>
        </div>
    </div>
    </form>
</body>
</html>

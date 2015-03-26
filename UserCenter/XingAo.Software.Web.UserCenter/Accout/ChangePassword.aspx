<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="XingAo.Software.Web.UserCenter.Accout.ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="header">
        	<h3>修改密码</h3>
		</div>
     	<div class="content">
			<span>
        		<label>*旧密码：</label>
                <input type="password" id="old_pwd" name="old_pwd" />
            </span>
        	<span>
        		<label>新密码：</label>
                <input type="password" id="new_pwd" name="new_pwd" />
        	</span>
        	<span>
                <label>确认新密码：</label>
                <input type="password" id="new_pwd2" name="new_pwd2" />
        	</span>
            <span>
            	<label>&nbsp;</label>
                <input type="submit" id="submit" name="submit" value="提交" />
            </span>
        </div>
    </div>
    </form>
</body>
</html>

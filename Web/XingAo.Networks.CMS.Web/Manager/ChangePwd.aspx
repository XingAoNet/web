﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePwd.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.ChangePwd" ViewStateMode="Disabled" %>


<div class="pageContent">
	
	<form method="post" runat="server" action="ChangePwd.ashx" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone)">
		<div class="pageFormContent" layoutH="58">

			<div class="unit">
				<label>旧密码：</label>
                <asp:textbox runat="server" type="password" ID="oldPassword" size="30" 
                    minlength="3" maxlength="20" class="required" TextMode="Password"></asp:textbox>
			</div>
			<div class="unit">
				<label>新密码：</label>
				<asp:textbox runat="server" type="password" ID="newPassword" size="30" 
                    minlength="5" maxlength="20" class="required" TextMode="Password"></asp:textbox>
			</div>
			<div class="unit">
				<label>重复输入新密码：</label>
                <asp:textbox runat="server" type="password" ID="rnewPassword" size="30" 
                    minlength="5" maxlength="20" class="required alphanumeric" 
                    equalTo="#newPassword" TextMode="Password"></asp:textbox>
				
			</div>
			
		</div>
		<div class="formBar">
			<ul>
				<li><div class="buttonActive"><div class="buttonContent"><button type="submit">提交</button></div></div></li>
				<li><div class="button"><div class="buttonContent"><button type="button" class="close">取消</button></div></div></li>
			</ul>
		</div>
	</form>
	
</div>

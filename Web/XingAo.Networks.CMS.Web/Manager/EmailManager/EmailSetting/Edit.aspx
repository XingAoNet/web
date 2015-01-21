<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.EmailManager.EmailSetting.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, navTabAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<dl>
				<dt>SMTP服务器：</dt>
				<dd>
                    <asp:TextBox ID="txtSMPTServer" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
            <dl>
				<dt>发件人昵称：</dt>
				<dd>
                    <asp:TextBox ID="txtSendName" runat="server" CssClass="required" Width="40%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>邮箱账号：</dt>
				<dd>
                    <asp:TextBox ID="txtSendAccount" runat="server" CssClass="required email" Width="80%"  alt="请输入电子邮件账号"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>邮箱密码：</dt>
				<dd>
                    <asp:TextBox ID="txtSendPwd" runat="server" CssClass="required" Width="40%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>SMTP端口：</dt>
				<dd>
                    <asp:TextBox ID="txtSMTPPort" runat="server" CssClass="required" Width="20%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>身份验证：</dt>
				<dd>
                    <asp:RadioButtonList ID="ddlSmtpValidation" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                    </asp:RadioButtonList>
                </dd>
			</dl>
			
		</div>
		<div class="formBar">
			<ul>
				<li><div class="buttonActive"><div class="buttonContent"><button type="submit">保存</button></div></div></li>
				<li>
					<div class="button"><div class="buttonContent"><button type="button" class="close">取消</button></div></div>
				</li>
			</ul>
		</div>
	</form>
</div>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WXMenu.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.WXMenu" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, navTabAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<dl>
				<dt>微信账号：</dt>
				<dd>
                    <asp:TextBox ID="txtName" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
            <dl>
				<dt>微信密码：</dt>
				<dd>
                    <asp:TextBox ID="txtPwd" runat="server" TextModel="password"  Width="80%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>AppId：</dt>
				<dd>
                    <asp:TextBox ID="txtAppId" runat="server" Width="80%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>AppSecret：</dt>
				<dd>
                    <asp:TextBox ID="txtAppSecret" runat="server"  Width="80%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>使用：</dt>
				<dd>
                   <asp:checkbox runat="server" ID="ckIsUse" Value="1"></asp:checkbox>
                </dd>
			</dl>
            <dl>
				<dt>微信菜单：</dt>
				<dd>
                    <asp:TextBox ID="txtMenuJosn" runat="server" TextMode="MultiLine" 
                        Height="100px" Width="80%"></asp:TextBox>
                    <asp:checkbox runat="server" ID="sendMenu" Value="1"></asp:checkbox>
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
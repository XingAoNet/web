<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.EmailManager.EmailSend.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, navTabAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<dl>
				<dt>发送标题：</dt>
				<dd>
                    <asp:TextBox ID="txtSendTitle" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
            <dl>
				<dt>发送内容：</dt>
				<dd>
                    <asp:TextBox ID="txtSendContent" runat="server" CssClass="required editor" Width="730" TextMode="MultiLine" Height="100px"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>接收邮箱地址：</dt>
				<dd>
                    <asp:TextBox ID="txtReceiveEmailAddr" runat="server" TextMode="MultiLine" 
                        Height="100px" Width="80%"></asp:TextBox>
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
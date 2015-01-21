<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.EmailManager.EmailTemplate.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<dl>
				<dt>模板名称：</dt>
				<dd>
                    <asp:TextBox ID="txtName" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
			<dl>
				<dt>模板标题：</dt>
				<dd>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>模板内容：</dt>
				<dd>
                    <asp:TextBox ID="txtInfo" runat="server" CssClass="required editor" TextMode="MultiLine" Height="340px" Width="720px"></asp:TextBox>
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
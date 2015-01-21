<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.FriendLink.Group.Edit" %>
<%@ Import Namespace="XingAo.Core" %>
<div class="pageContent">
	
	<form id="Form1" method="post" runat="server" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone)">
		<div class="pageFormContent" layoutH="58">

			<div class="unit">
				<label>分组名称：</label>
                <asp:TextBox ID="txtGroupName" runat="server" CssClass="required"></asp:TextBox>
                    <asp:HiddenField ID="txtID" runat="server" />
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
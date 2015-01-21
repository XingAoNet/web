<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.MaterialFamily.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone)">
		<h2 class="contentTitle">添加栏目</h2>
        <div class="pageFormContent nowrap" layoutH="100">
            <div class="unit">
				<label>所属栏目：</label>
                <asp:dropdownlist ID="txtParentID" runat="server"></asp:dropdownlist>
                <asp:HiddenField ID="txtSelfID" runat="server" />
			</div>
			<div class="unit">
				<label>栏目名称：</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="required" Width="70%"></asp:TextBox>
                <asp:HiddenField ID="txtID" runat="server" />
			</div>
             <div class="unit">
				<label>显示顺序：</label>
                <asp:TextBox ID="txtOrderID" runat="server" CssClass="required"></asp:TextBox>
			</div>
            <div class="unit">
				<label>栏目描述：</label>
                <asp:TextBox ID="txtDescribe" runat="server"  CssClass="required" Width="70%" height="60" TextMode="MultiLine"></asp:TextBox>
			</div>
           
           
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
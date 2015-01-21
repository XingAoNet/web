<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Product.ProductClass.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<dl>
				<dt>所属类别：</dt>
				<dd>
                    <asp:dropdownlist ID="txtPID" runat="server" CssClass="required combox"></asp:dropdownlist>
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
            <dl>
				<dt>类别名称：</dt>
				<dd>
                    <asp:TextBox ID="txtClassName" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>类别图片：</dt>
				<dd>
                    <asp:TextBox ID="txtPic" runat="server" Width="80%" ToolTip="用图片作分类导航，为空则使用类别名称作为导航"></asp:TextBox><input id="uploadButton-txtPic" class="Pic_Upload_File" type="button" value="选择图片" />
                </dd>
			</dl>
            <dl>
				<dt>变换图片：</dt>
				<dd>
                    <asp:TextBox ID="txtPicHover" runat="server" Width="80%" ToolTip="采用图片作分类导航情况下，鼠标移上去时的变换图"></asp:TextBox><input id="uploadButton-txtPicHover" class="Pic_Upload_File" type="button" value="选择图片" />
                </dd>
			</dl>
            <dl>
				<dt>默认价格：</dt>
				<dd>
                    <asp:TextBox ID="txtDefaultPrice" runat="server" CssClass="required number" Width="80%"></asp:TextBox>
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
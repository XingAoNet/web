<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Product.ProductAttribute.AttributeSet.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<dl>
				<dt>属性组：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtGroupID" CssClass="combox">
                        
                    </asp:dropdownlist>
                </dd>
			</dl>
            <dl>
				<dt>属性名称：</dt>
				<dd>
                    <asp:TextBox ID="txtAttrName" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
            <dl>
				<dt>显示类型：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtFormControlType" CssClass="combox">
                        
                    </asp:dropdownlist>
                </dd>
			</dl>
            <dl>
				<dt>数据验证：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtDataValidation" CssClass="required combox"></asp:dropdownlist>
                </dd>
			</dl>
            <dl>
				<dt>排序：</dt>
				<dd>
                     <asp:TextBox ID="txtOrderNum" ToolTip="越大越靠前" runat="server" CssClass="required digits" Width="80%">0</asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>描述：</dt>
				<dd>
                    <asp:TextBox ID="txtDescriptions" runat="server" TextMode="MultiLine" 
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
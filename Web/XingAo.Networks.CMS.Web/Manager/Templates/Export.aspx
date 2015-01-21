<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Export.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Templates.Export" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="Templates/DoImport.ashx?Import=0" class="pageForm required-validate" onsubmit="return validateCallback(this, navTabAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<dl>
				<dt>导出到：</dt>
				<dd>                                       
                    <asp:dropdownlist runat="server" ID="txtID" CssClass="combox required">
                    </asp:dropdownlist>
                </dd>
			</dl>
            <dl>
				<dt>导出名称：</dt>
				<dd>                                       
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>说明备注：</dt>
				<dd>                                       
                    <asp:TextBox ID="txtDescriptions" runat="server" Width="80%" MaxLength="550" ></asp:TextBox>
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
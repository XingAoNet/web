<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Organizations.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="58">
			<dl>
				<dt style="Width:80px;">组织编码：</dt>
				<dd style="Width:500px;"><asp:TextBox ID="txtNo" runat="server" CssClass="required"></asp:TextBox>以3位为一个编号码
                    <asp:HiddenField ID="txtID" runat="server" />
                    <asp:HiddenField ID="txtElectId" runat="server" />
                </dd>
			</dl>
            <dl>
				<dt style="Width:80px;">组织名：</dt>
				<dd style="Width:500px;"><asp:TextBox ID="txtName" runat="server" CssClass="required"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt style="Width:80px;">描述：</dt>
				<dd style="Width:500px;"><asp:TextBox ID="txtDescription" CssClass="editor" runat="server" TextMode="MultiLine" 
                        Height="300px" Width="100%"></asp:TextBox>
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
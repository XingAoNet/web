<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.SysConfigs.SiteSetting.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, navTabAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<dl>
				<dt>网站名称：</dt>
				<dd>
                    <asp:TextBox ID="txtSiteName" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>网站域名：</dt>
				<dd>
                    <asp:TextBox ID="txtUrl" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                </dd>
			</dl>
            
			<dl>
				<dt>联系电话：</dt>
				<dd>
                    <asp:TextBox ID="txtTel" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>传真：</dt>
				<dd>
                    <asp:TextBox ID="txtFax" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>邮编：</dt>
				<dd>
                    <asp:TextBox ID="txtZIP" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>客服邮箱：</dt>
				<dd>
                    <asp:TextBox ID="txtServiceEmail" runat="server" CssClass="required email" Width="50%" alt="请输入企业客服邮箱" ></asp:TextBox>
                </dd>
			</dl>
			<dl>
				<dt>企业地址：</dt>
				<dd>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                </dd>
			</dl>

            <dl>
				<dt>网站版权信息：</dt>
				<dd>
                    <asp:TextBox ID="txtCopyright" runat="server"  TextMode="MultiLine"  Width="80%"></asp:TextBox>
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
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.LableDesign.SysLable.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<dl>
				<dt>标签名称：</dt>
				<dd>
                    <asp:TextBox ID="txtLabelName" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
            <dl>
				<dt>根命名空间：</dt>
				<dd>
                    <asp:TextBox ID="txtNameSpace" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                   <br />程序集命名空间(不包括文件目录名的顶级命名空间,一般情况下为dll文件名)
                </dd>
			</dl>
            <dl>
				<dt>类名：</dt>
				<dd>
                    <asp:TextBox ID="txtNameSpaceClass" runat="server" Width="80%"></asp:TextBox>
                    <br />格式：根命名空间.目录名.类名
                </dd>
			</dl>
			<dl>
				<dt>方法名：</dt>
				<dd>
                    <asp:TextBox ID="txtMethod" runat="server" Width="80%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>参数：</dt>
				<dd>
                    <asp:TextBox ID="txtParameters" runat="server" Width="80%"></asp:TextBox>
                    <br />无参保持为空，多个参数以英文半角逗号间隔
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
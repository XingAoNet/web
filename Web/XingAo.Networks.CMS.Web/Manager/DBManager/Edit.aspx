﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.DBManager.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<dl>
				<dt>字段名：</dt>
				<dd>
                    <asp:TextBox ID="txtTableName" runat="server" CssClass="required" Width="80%" value="XA_"></asp:TextBox>
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
            <dl>
				<dt>中文名：</dt>
				<dd>
                    <asp:TextBox ID="txtChineseName" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>系统表：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtIsSystemTable" CssClass="combox">
                        <asp:ListItem Value="0">扩展表</asp:ListItem>
                        <asp:ListItem Value="1">系统表</asp:ListItem>
                    </asp:dropdownlist>
                </dd>
			</dl>
            <dl>
				<dt>描述：</dt>
				<dd>
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" 
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
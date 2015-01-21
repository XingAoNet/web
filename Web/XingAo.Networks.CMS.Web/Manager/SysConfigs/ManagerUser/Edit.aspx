<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.SysConfigs.ManagerUser.Edit" %>
<%@ Import Namespace="XingAo.Core" %>
<style type="text/css">
#txtCanUse label{float:none;}
</style>
<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<dl style="display:none;">
				<dt>用户类型：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtUserType" CssClass="required combox">
                       <asp:ListItem Value="">--请选择--</asp:ListItem>
                        <asp:ListItem Value="1">高级管理员</asp:ListItem>
                        <asp:ListItem Value="2" Selected="True">普通管理员</asp:ListItem>
                    </asp:dropdownlist>
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
            <dl>
				<dt>登录名：</dt>
				<dd>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>姓名：</dt>
				<dd>
                    <asp:TextBox ID="txtRealName" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>密码：</dt>
				<dd>
                    <asp:TextBox ID="txtPwd" runat="server" Width="80%" 
                        TextMode="Password"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>确认密码：</dt>
				<dd>
                    <asp:TextBox ID="txtPwd2" runat="server" Width="80%" 
                        TextMode="Password"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>是否可用：</dt>
				<dd>
      <%--              <asp:dropdownlist runat="server" ID="txtCanUse" CssClass="required combox">
                        <asp:ListItem Selected="True" Value="">--请选择--</asp:ListItem>
                        <asp:ListItem Value="1">可用</asp:ListItem>
                        <asp:ListItem Value="0">禁用</asp:ListItem>
                    </asp:dropdownlist>--%>
                    <asp:radiobuttonlist runat="server" ID="txtCanUse" CssClass="required" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1" Selected="True">可用</asp:ListItem>
                        <asp:ListItem Value="0">禁用</asp:ListItem>
                    </asp:radiobuttonlist>
                </dd>
			</dl>
            <dl>
				<dt>所属组：</dt>
				<dd>
                    <asp:TextBox runat="server" ID="txtGroupIDs" lookFor="txtGroupIDs" style="display:none"></asp:TextBox>
                    <asp:TextBox ID="txtGroupIDs_text" runat="server" Width="80%" 
                        CssClass="required readonly" lookfor="txtGroupIDs" ReadOnly="True"></asp:TextBox>
                    <a class="btnLook" lookupgroup="txtGroupIDs" href="SysConfigs/ManagerUser/Groups/SimpleMain.aspx">查找带回</a>
                   <%-- [input name="{ID}" id="{ID}" lookFor="{ID}" type="hidden"/]
      [input class="required" name="{ID}_text" lookFor="{ID}" type="text" readonly="" {0}/]
      [a class="btnLook" href="{DataBind}" lookupGroup="{ID}"]查找带回[/a]--%>
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
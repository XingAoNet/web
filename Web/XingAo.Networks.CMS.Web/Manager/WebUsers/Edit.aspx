<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.WebUsers.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<dl>
				<dt>用户名：</dt>
				<dd>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="required" Width="35%"></asp:TextBox>
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
            <dl>
				<dt>真实姓名：</dt>
				<dd>
                    <asp:TextBox ID="txtRealName" runat="server" CssClass="required" Width="35%"></asp:TextBox>
                </dd>
			</dl>
            
            <asp:panel runat="server" ID="panelPassword">
            <dl>
				<dt>密码：</dt>
				<dd>
                    <asp:TextBox ID="txtPwd" runat="server" Width="35%" CssClass="required alphanumeric" TextMode="Password"  minlength="6" maxlength="20" alt="字母、数字、下划线 6-20位"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>密码确认：</dt>
				<dd>
                    <asp:TextBox ID="txtPwd2" runat="server" Width="35%" CssClass="required" TextMode="Password"  equalto="#txtPwd"></asp:TextBox>
                </dd>
			</dl>
            </asp:panel>

            <dl>
				<dt>积分：</dt>
				<dd>
                    <asp:TextBox ID="txtPoint" runat="server" Width="10%" Text="0"></asp:TextBox>
                </dd>
			</dl>
			<dl>
				<dt>会员等级：</dt>
				<dd>
                    <asp:TextBox ID="txtVipLevel" runat="server" Width="80%"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>邮箱：</dt>
				<dd>
                    <asp:TextBox ID="txtEmail" runat="server" Width="80%" CssClass="required email" alt="请输入会员的电子邮件"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>手机：</dt>
				<dd>
                    <asp:TextBox ID="txtMobile" runat="server" Width="80%" CssClass="required" class="phone" alt="请输入会员的电话"></asp:TextBox>
                </dd>
			</dl>
            <dl>
				<dt>是否可用：</dt>
				<dd>
                    <asp:radiobuttonlist runat="server" ID="txtCanUse" RepeatDirection="Horizontal" 
                        RepeatLayout="Flow">
                        <asp:ListItem Value="0">禁用</asp:ListItem>
                        <asp:ListItem Selected="True" Value="1">可用</asp:ListItem>
                    </asp:radiobuttonlist>
                </dd>
			</dl>
            <dl>
				<dt>审核状态：</dt>
				<dd>
                    <asp:radiobuttonlist runat="server" ID="txtAudit" RepeatDirection="Horizontal" 
                        RepeatLayout="Flow">
                        <asp:ListItem Value="0">未审核</asp:ListItem>
                        <asp:ListItem Selected="True" Value="1">已审核</asp:ListItem>
                    </asp:radiobuttonlist>
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
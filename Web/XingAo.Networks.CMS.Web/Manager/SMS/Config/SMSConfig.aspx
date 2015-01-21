<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMSConfig.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.SMS.Config.SMSConfig" %>


<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, navTabAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
            <dl>
				<dt>短信帐号：</dt>
				<dd width="80%">
                    <asp:TextBox ID="txtPhoneUsername" width="80%" runat="server"  CssClass="required"></asp:TextBox> 
                </dd>
			</dl>
            <dl>
				<dt>短信密码：</dt>
				<dd width="80%">
                    <asp:TextBox ID="txtPhonePassword" width="80%" runat="server"  CssClass="required"></asp:TextBox>
                </dd>
			</dl>
<%--            <dl>
				<dt>编辑时间：</dt>
				<dd>
                    <asp:TextBox ID="txtDescription" runat="server" MaxLength="100"></asp:TextBox>
                </dd>
			</dl>--%>
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
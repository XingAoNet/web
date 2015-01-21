<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUserInfo.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.WebUsers.ViewUserInfo" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
	    <div class="pageFormContent nowrap" layoutH="56">
			    <dl>
				    <dt>用户名：</dt>
				    <dd>
                        <asp:Label ID="txtUserName" runat="server"></asp:Label>
                        <asp:HiddenField ID="txtID" runat="server" />
                    </dd>
			    </dl>
                <dl>
				    <dt>真实姓名：</dt>
				    <dd>
                        <asp:Label ID="txtRealName" runat="server"></asp:Label>
                    </dd>
			    </dl>
                <dl>
				    <dt>积分：</dt>
				    <dd>
                        <asp:Label ID="txtPoint" runat="server"></asp:Label>
                    </dd>
			    </dl>
			    <dl>
				    <dt>会员等级：</dt>
				    <dd>
                        <asp:Label ID="txtVipLevel" runat="server"></asp:Label>
                    </dd>
			    </dl>
                <dl>
				    <dt>邮箱：</dt>
				    <dd>
                        <asp:Label ID="txtEmail" runat="server"></asp:Label>  <span style="color:Red;">==></span>
                        <a href="EmailManager/EmailSend/Edit.aspx?email=<%=emailAddr %>" target="dialog" width="900" height="440" title="发送邮件" rel="send_email">发送邮件</a>
                    </dd>
			    </dl>
                <dl>
				    <dt>手机：</dt>
				    <dd>
                        <asp:Label ID="txtMobile" runat="server"></asp:Label> <span style="color:Red;">==></span>
                        <a href="#"  target="dialog" width="760" height="340" title="发送短信" rel="send_SMS">发送短信</a>
                    </dd>
			    </dl>
                <dl>
				    <dt>是否可用：</dt>
				    <dd>
                        <asp:Label ID="txtCanUse" runat="server"></asp:Label>
                    </dd>
			    </dl>
                <dl>
				    <dt>审核状态：</dt>
				    <dd>
                        <asp:Label ID="txtAudit" runat="server"></asp:Label>
                    </dd>
			    </dl>
		    </div>
	    <div class="formBar">
		    <ul>
			    <li>
				    <div class="button"><div class="buttonContent"><button type="button" class="close">取消</button></div></div>
			    </li>
		    </ul>
	    </div>
    </form>
</div>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.SMS.SMSTemplate.Edit" %>

<style type="text/css">
            #txtTemplatesContent,#txtKeyType label{float:none;}
    </style>
<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
            <dl>
				<dt>短信模板名称：</dt>
				<dd width="80%">
                    <asp:TextBox ID="txtTemplatesName" width="80%" runat="server"  CssClass="required"></asp:TextBox>                    
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
            <dl>
				<dt>短信模板内容：</dt>
				<dd width="80%">
                    <asp:TextBox ID="txtTemplatesContent" width="80%" runat="server" 
                        CssClass="required" TextMode="MultiLine" height="100"></asp:TextBox>
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
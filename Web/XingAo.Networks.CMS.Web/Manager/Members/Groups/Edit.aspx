<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Members.Groups.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
     <div class="pageFormContent" layoutH="58">
            <dl>
				<dt style="width:90px;">会员组名：</dt>
                <dd>
				<asp:TextBox ID="txtTGroupName" runat="server" CssClass="required"  size="30" MaxLenth="30"></asp:TextBox>
                <asp:HiddenField ID="txtID" runat="server" />
                </dd>
            </dl>
            <dl>
				<label style="width:90px;">序号：</label>
				<dd><asp:TextBox ID="txtOrder" runat="server" CssClass="required"  size="30" MaxLenth="30"></asp:TextBox></dd>
            </dl>
			<dl>
				<dt style="width:90px;">描述：</dt>
				<dd><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" 
                        Height="100px" Width="400"></asp:TextBox></dd>
			</dl>
			
		</div>
		<div class="formBar">
			<ul>
				<li><div class="buttonActive"><div class="buttonContent"><button type="submit">提交</button></div></div></li>
				<li><div class="button"><div class="buttonContent"><button type="button" class="close">取消</button></div></div></li>
			</ul>
         </div>
	</form>
</div>
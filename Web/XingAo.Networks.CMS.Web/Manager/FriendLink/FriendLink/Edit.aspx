<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.FriendLink.FriendLink.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<dl>
				<dt>所属分组：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtGroupID" CssClass="required combox"></asp:dropdownlist>
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
            <dl>
				<dt>名　　称：</dt>
				<dd>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="required" Width="80%"></asp:TextBox>                    
                </dd>
			</dl>
            <dl>
				<dt>链接图片：</dt>
				<dd>
                    <asp:TextBox ID="txtPic" runat="server" Width="50%"></asp:TextBox>
                    <img src="" id="imgPic" style="display:none;margin:2px;" title="点击删除图片" alt="点击删除图片" />
                    <input id="uploadButton-txtPic-imgPic" class="Pic_Upload_File" type="button" value="选择图片" alt="100" />
                    *点击图片删除
                </dd>
			</dl>
            <dl>
				<dt>链接地址：</dt>
				<dd>
                    <asp:TextBox ID="txtLinkUrl" runat="server" Width="80%" Text="#"></asp:TextBox>
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
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.CustomMenu.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, navTabAjaxDone);">
    <h2 class="contentTitle">自定义菜单设置</h2>
		<div class="pageFormContent nowrap" layoutH="100">
           <div class="unit">
				<label>所属栏目：</label>
                 <asp:dropdownlist ID="txtPID" runat="server" CssClass="combox required">
                    <asp:ListItem Value="0" Text="主菜单"></asp:ListItem>
                 </asp:dropdownlist>
                 <asp:HiddenField ID="txtID" runat="server" />
            </div>
			 <div class="unit">
				<label>主菜单名称：</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="required" Width="70%"></asp:TextBox>
			</div>
             <div class="unit">
				<label>显示顺序：</label>
                 <asp:TextBox ID="txtOrderID" runat="server" CssClass="required" Width="70%"></asp:TextBox>               
			</div>
            <div class="unit">
				<label>菜单类型：</label>
                <input name="MenuType" id="ClickRadio" runat="server" type="radio" value="click" checked="true" />按钮
                <input name="MenuType" id="ViewRadio" runat="server" type="radio" value="view" />链接
			</div>
             <div class="unit">
				<label>关键词或链接地址：</label>
                <asp:hiddenfield runat="server" ID="txtKeys"></asp:hiddenfield>
                <asp:hiddenfield runat="server" ID="txtSource"></asp:hiddenfield>
                <asp:TextBox  runat="server" ID="txtKeys_text" CssClass="required" Width="70%" lookupGroup="txtKeys"></asp:TextBox>
				<a class="btnLook" href="/Manager/Wechat/Sources/main.aspx" lookupGroup="txtKeys">查找带回</a>	
			</div>
             <div class="unit">
				<label>状态：</label>
				<input id="IsUse" type="checkbox" runat="server" checked />启用 
			</div>
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
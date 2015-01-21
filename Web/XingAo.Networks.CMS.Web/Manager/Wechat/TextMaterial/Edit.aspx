<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.TextMaterial.Edit" %>
<%@ Import Namespace="XingAo.Core" %>


    <style type="text/css">
#KeyType label{float:none;}
    </style>


<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
           <h2 class="contentTitle">自定义文本回复信息</h2>
               <div class="unit">
                <label>关键词：</label>
                 <asp:TextBox ID="KeyValue" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                    <asp:HiddenField ID="txtID" runat="server" />
                    <asp:hiddenfield id="txtTGuid" runat="server" />
            </div>
            <div class="unit">
                <label>关键词类型：</label>
                <asp:radiobuttonlist ID="KeyType" runat="server">
                         <asp:ListItem Value="0" Selected="True">完全匹配，用户输入的和此关键词一样才会触发!</asp:ListItem>
                        <asp:ListItem Value="1">包含匹配 (只要用户输入的文字包含本关键词就触发！)</asp:ListItem>
                    </asp:radiobuttonlist>
            </div>
                        <div class="unit">
                <label>自动回复内容:</label>
                <asp:TextBox ID="txtReplyContent" runat="server" CssClass="required editor" TextMode="MultiLine" height="300" width="80%"></asp:TextBox>
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
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.DataShare.ParameterConf.Edit" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, dialogAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<dl>
				<dt>数据类型：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtDataType" CssClass="combox">
                        <asp:ListItem Value="int">数字</asp:ListItem>
                        <asp:ListItem Value="date">短日期</asp:ListItem>
                        <asp:ListItem Value="datetime">长日期</asp:ListItem>
                        <asp:ListItem Value="string">字符</asp:ListItem>
                    </asp:dropdownlist>
                </dd>
			</dl>
            <dl>
				<dt>空值处理：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtAllowEmpty" CssClass="combox">
                        <asp:ListItem Value="0">为空时忽略此条件</asp:ListItem>
                        <asp:ListItem Value="1">为空时也要加此条件</asp:ListItem>
                    </asp:dropdownlist>
                </dd>
			</dl>
            <dl>
				<dt>操作符：</dt>
				<dd>
                    <asp:dropdownlist runat="server" ID="txtOperators">
                        <asp:ListItem Value="&gt;{0}">大于</asp:ListItem>
                        <asp:ListItem Value="&gt;={0}">大于等于</asp:ListItem>
                        <asp:ListItem Value="&lt;{0}">小于</asp:ListItem>
                        <asp:ListItem Value="&lt;={0}">小于等于</asp:ListItem>
                        <asp:ListItem Value="={0}">等于</asp:ListItem>
                        <asp:ListItem Value="like '{0}%'">右模糊(like 'xx%')</asp:ListItem>
                        <asp:ListItem Value="like '%{0}'">左模糊(like '%xx')</asp:ListItem>
                        <asp:ListItem Value="like '%{0}%'">左右模糊(like '%xx%')</asp:ListItem>
                        <asp:ListItem Value="in({0})">包含(in(x,xx))</asp:ListItem>
                    </asp:dropdownlist>
                </dd>
			</dl>
            <dl>
				<dt>参数名：</dt>
				<dd>
                    <asp:TextBox ID="txtParameterName" runat="server" CssClass="required" Width="80%"></asp:TextBox>
                    <asp:HiddenField ID="txtDataShareID" runat="server" />
                    <asp:HiddenField ID="txtID" runat="server" />
                </dd>
			</dl>
            <dl>
				<dt>字段名：</dt>
				<dd>
                    <asp:TextBox ID="txtFieldName" runat="server" CssClass="required" Width="80%"></asp:TextBox>
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
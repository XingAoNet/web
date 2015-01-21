<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Import.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Templates.Import" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<form id="form1" runat="server" action="Templates/DoImport.ashx?Import=1" class="pageForm required-validate" onsubmit="return validateCallback(this, navTabAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<dl>
				<dt>模板：</dt>
				<dd>
                    <input name="txt_BakID" id="txt_BakID" lookFor="txt_BakID" type="hidden" />                    
                    <asp:TextBox ID="txt_BakID_Text" runat="server" CssClass="required" Width="80%" readonly  lookFor="txt_BakID"></asp:TextBox>
                    
                    <a class="btnLook" lookupgroup="txt_BakID" href="Templates/TemplateBakList.aspx"></a>
                    <br />
                    模板名称格式：ID_模板类型_模板名称.html<br />
                    说明：<br />
                    1.ID--数据库ID，如果新增时不知道ID，直接用0代替<br />
                    2.模板类型--0：公共模块 1：首页模板 2：列表页模板 3：详细页模板<br />
                    3.模板名称--可以使用中英文，但不允许出现各种符号</dd>
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
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TextEdit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.Attention.TextEdit" %>
<%@ Import Namespace="XingAo.Core" %>


<style type="text/css">
    #IsShow label,#txtKeyType label{float:none;}
</style>


<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, navTabAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
           <h2 class="contentTitle">关注时文本回复内容</h2>           
            <dl>
				<dt>回复内容：</dt>
				<dd>
                  <asp:TextBox ID="txtDetailedContent" runat="server" CssClass="required editor" TextMode="MultiLine" Height="80px" Width="427px"></asp:TextBox>
                  <asp:HiddenField ID="txtID" runat="server" />
                  <asp:HiddenField ID="TxtType" value="0" runat="server" />
                </dd>
			</dl>	
            <dl>
				<dt></dt>
				<dd>
                  <a href="/Wechat/Material/Attention/ImageEdit.aspx" target="navTab">切换图文模式</a>
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
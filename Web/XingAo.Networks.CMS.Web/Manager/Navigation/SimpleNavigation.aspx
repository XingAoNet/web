<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SimpleNavigation.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Navigation.SimpleNavigation" %>

<asp:panel runat="server" ID="p1">
<div class="pageContent">
	<div class="pageFormContent" layoutH="58">
		<asp:Literal runat="server" ID="List"></asp:Literal>
	</div>
	
	<div class="formBar">
		<ul>
			<li><div class="button"><div class="buttonContent"><button class="close" type="button">关闭</button></div></div></li>
		</ul>
	</div>
</div>
</asp:panel>
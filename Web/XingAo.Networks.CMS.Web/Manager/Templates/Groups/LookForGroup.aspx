<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LookForGroup.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Templates.Groups.LookForGroup" %>
<%@ Import Namespace="XingAo.Core" %>
<asp:panel runat="server" ID="p1">
<div class="pageContent">
	<div class="pageFormContent" layoutH="58">
		<ul class="tree expand">
			<li><a href="javascript:">会员组</a>
				<ul>
                <asp:repeater runat="server" ID="Rep_List">
                    <ItemTemplate>            
                    <li><a href="javascript:" onclick="$.CallBackSetFormValue(['<%#Eval("GroupId") %>','<%#Eval("GroupName")%>'])"><%#Eval("GroupName")%></a></li>
                </ItemTemplate>
                </asp:repeater>
				</ul>
			</li>
			
		</ul>
	</div>
	
	<div class="formBar">
		<ul>
			<li><div class="button"><div class="buttonContent"><button class="close" type="button">关闭</button></div></div></li>
		</ul>
	</div>
</div>
</asp:panel>
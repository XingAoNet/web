<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LookForMember.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Members.LookForMember" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<div class="pageFormContent" layoutH="58">
		<ul class="tree expand">
            <asp:repeater runat="server" ID="Rep_List">
                <ItemTemplate>            
                <li><a href="javascript:"><%#Eval("GroupName")%></a>
                <asp:repeater runat="server" DataSource='<%#Eval("Members") %>'>
                    <HeaderTemplate><ul></HeaderTemplate>
                    <ItemTemplate>            
                        <li><a href="javascript:;"  onclick="$.bringBack({'id':'<%#Eval("Id") %>', 'orgName':'<%#Eval("TName")%>'})"><%#Eval("TName")%></a>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate></ul></FooterTemplate>
                </asp:repeater>
                    
                </li>
            </ItemTemplate>
            </asp:repeater>
		</ul>
	</div>
	
	<div class="formBar">
		<ul>
			<li><div class="button"><div class="buttonContent"><button class="close" type="button">关闭</button></div></div></li>
		</ul>
	</div>
</div>
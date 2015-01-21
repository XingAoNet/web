<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Accounts.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.WeiXin.Accounts" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<table class="table">
		<thead>
			<tr>
				<th width="22"><input type="checkbox" group="ids" class="checkboxCtrl"></th>
				<th width="120">账号</th>
				<th width="100">备注</th>
			</tr>
		</thead>
		<tbody>
            <asp:repeater runat="server" ID="Rep_List">
                <ItemTemplate>            
			        <tr target="sid" rel="<%#Eval("ID") %>">
				        <td><input name="ids" value="<%#Eval("ID") %>" type="checkbox"></td>
				        <td><%#Eval("nick_name")%></td>
				        <td><%#Eval("remark_name")%></td>				
			        </tr>
                </ItemTemplate>
            </asp:repeater>
		</tbody>
	</table>
	<div class="panelBar">
        <asp:literal runat="server" Id="LiPager"></asp:literal>
	</div>
</div>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Organizations.Main" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageHeader">

</div>
<div class="pageContent">
	<div class="panelBar">
		<ul class="toolBar"> 
			<li><a class="add" href="<%=Request.GetPath() %>/Edit.aspx?MenuID=<%=Request.QueryString["MenuID"]%>" target="dialog"><span>添加</span></a></li>
			<li><a title="确实要删除这些记录吗?" target="selectedTodo" rel="ids" href="<%=Request.GetPath() %>/SaveDel.ashx" class="delete"><span>删除所选</span></a></li>
			<li><a class="edit" href="<%=Request.GetPath() %>/Edit.aspx?id={sid}" width="680" height="360" target="dialog" warn="请选择一条数据"><span>修改</span></a></li>
			
		</ul>
	</div>
	<table class="table" width="100%">
		<thead>
			<tr>
				<th width="22"><input type="checkbox" group="ids" class="checkboxCtrl" /></th>
                <th width="280">组织名</th>
				<th width="120">组织编号</th>
                <th width="60">成员</th>
				<th>描述</th>
                
			</tr>
		</thead>
		<tbody>
            <asp:repeater runat="server" ID="Rep_List">
            <ItemTemplate>            
			<tr target="sid" rel="<%#Eval("ID") %>">
				<td><input name="ids" value="<%#Eval("ID") %>" type="checkbox"></td>
                <td><%#Eval("OrgCode").ToString().Length > 3 ? "".PadRight(Eval("OrgCode").ToString().Length / 3 * 3, (char)0xA0) : ""%><%#Eval("OrgName")%></td>
                <td><%#Eval("OrgCode")%></td>
                 <td><a href="Organizations/OrgMembers/Main.aspx?OrgId=<%#Eval("Id") %>" target="navTab" rel="navTab_OrgMembers" title="<%#Eval("OrgName")%>"><%#Eval("OrgCode").ToString().Length > 3 ? "人员": ""%></a></td>
				<td><%#Eval("OrgDescribe")%></td>				
			</tr>
            </ItemTemplate>
            </asp:repeater>
		</tbody>
	</table>
	<div class="panelBar">
	</div>
</div>
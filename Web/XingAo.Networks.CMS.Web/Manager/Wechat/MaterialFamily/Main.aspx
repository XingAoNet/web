<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.MaterialFamily.Main" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<div class="panelBar">
		<ul class="toolBar">
			<li><a class="add" href="<%=Request.GetPath()%>/Edit.aspx" target="dialog" height="320"><span>添加</span></a></li>
			<li><a title="确实要删除这些记录吗?" target="selectedTodo" rel="ids" href="<%=Request.GetPath() %>/SaveDel.ashx" class="delete"><span>删除所选</span></a></li>
			<li><a class="edit" href="<%=Request.GetPath() %>/Edit.aspx?id={sid}" height="320" target="dialog" warn="请选择一条数据"><span>修改</span></a></li>
			
		</ul>
	</div>
	<table class="table" width="100%" layoutH="138">
		<thead>
			<tr>
				<th width="22"><input type="checkbox" group="ids" class="checkboxCtrl"></th>
				<th width="120">类别名称</th>
				<th width="280">说明</th>
				<th width="120">顺序</th>
			</tr>
		</thead>
		<tbody>
            <asp:repeater runat="server" ID="Rep_List">
            <ItemTemplate>            
			<tr target="sid" rel="<%#Eval("ID") %>">
				<td><input name="ids" value="<%#Eval("ID") %>" type="checkbox"></td>
				<td><%#Eval("Name")%></td>
				<td><%#Eval("Describe")%></td>
				<td><%#Eval("OrderID")%></td>			
			</tr>
            </ItemTemplate>
            </asp:repeater>
		</tbody>
	</table>
</div>

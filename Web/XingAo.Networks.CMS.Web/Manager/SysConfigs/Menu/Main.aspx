<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.SysConfigs.Menu.Main" %>
<%@ Import Namespace="XingAo.Core" %>
<form id="pagerForm" method="post" action="<%=Request.GetPath() %>/main.aspx">
    <input type="hidden" name="status" value="status" />
	<input type="hidden" name="keyString" value="<%=keyString %>" />
	<input type="hidden" name="pageNum" value="<% =PageNum %>" />
	<input type="hidden" name="numPerPage" value="<%=PageSize %>" />
	<input type="hidden" name="orderField" value="id" />
    <%--高级检索--%>
    <%--<input type="hidden" name="classID" value="<%=ClassID %>" />
    <input type="hidden" name="searchTitle" value="<%=SearchTitle %>" />
    <input type="hidden" name="startDate" value="<%=StartDate %>" />
    <input type="hidden" name="endDate" value="<%=EndDate %>" />
    <input type="hidden" name="setTop" value="<%=SetTop %>" />
    <input type="hidden" name="Pass" value="<%=Pass %>" />--%>
</form>


<div class="pageHeader">
	<form onsubmit="return navTabSearch(this);" action="<%=Request.GetPath() %>/main.aspx" method="post"><%--基于Manager目录开始的路径--%>
	<div class="searchBar">
		<table class="searchContent">
			<tr>
				<td>
					菜单名称：<input type="text" name="keyString" value="<%=keyString %>" />
				</td>
			</tr>
		</table>
		<div class="subBar">
			<ul>
				<li><div class="buttonActive"><div class="buttonContent"><button type="submit">查询</button></div></div></li>
			</ul>
		</div>
	</div>
	</form>
</div>
<div class="pageContent">
	<div class="panelBar">
		<ul class="toolBar"> 
			<li><a class="add" href="<%=Request.GetPath() %>/Edit.aspx?MenuID=<%=Request.QueryString["MenuID"]%>" target="dialog" width="1000" height="500" title="添加系统菜单" rel="menu_add"><span>添加</span></a></li>
			<li><a title="确实要删除这些记录吗?" target="selectedTodo" rel="ids" href="<%=Request.GetPath() %>/SaveDel.ashx" class="delete"><span>删除所选</span></a></li>
			<li><a class="edit" href="<%=Request.GetPath() %>/Edit.aspx?MenuID=<%=Request.QueryString["MenuID"]%>&id={sid}" target="dialog" width="1000" height="500" title="修改系统菜单" rel="menu_edit" warn="请选择一条数据"><span>修改</span></a></li>
			
		</ul>
	</div>
	<table class="table" width="100%" layoutH="138">
		<thead>
			<tr>
				<th width="22"><input type="checkbox" group="ids" class="checkboxCtrl"></th>
				<th width="100">菜单名</th>
				<th width="100">导航英文名</th>
                <th width="280">链接地址</th>
                <th width="100">新窗口标识</th>
                <th width="80">菜单排序号</th>
                <th width="80">打开窗口</th>
			</tr>
		</thead>
		<tbody>
            <asp:repeater runat="server" ID="Rep_List">
                <ItemTemplate>            
			        <tr target="sid" rel="<%#Eval("ID") %>">
				        <td><input name="ids" value="<%#Eval("ID") %>" type="checkbox"></td>
				        <td><%#"".PadRight(Eval("deep").ObjToInt() * 4, (char)0xA0) + "|--" + Eval("NavName")%></td>
				        <td><%#Eval("MenuID")%></td>
                        <td><%#Eval("Url")%></td>
                        <td><%#Eval("Rel")%></td>
                        <td><%#Eval("OrderNum")%></td>	
                        <td><%#Eval("Target")%></td>				
			        </tr>
                </ItemTemplate>
            </asp:repeater>
		</tbody>
	</table>
	<div class="panelBar">
    
	</div>
</div>
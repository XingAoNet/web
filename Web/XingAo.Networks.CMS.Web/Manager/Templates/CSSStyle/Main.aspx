<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Templates.CSSStyle.Main" %>
<%@ Import Namespace="XingAo.Core" %>
<form id="pagerForm" method="post" action="<%=Request.GetPath() %>/main.aspx">
    <input type="hidden" name="status" value="status">
	<input type="hidden" name="keywords" value="<%=keyString %>" />
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
					用户名：<input type="text" name="keyString" value="<%=keyString %>" />
				</td>
			</tr>
		</table>
		<div class="subBar">
			<ul>
				<li><div class="buttonActive"><div class="buttonContent"><button type="submit">检索</button></div></div></li>
			</ul>
		</div>
	</div>
	</form>
</div>
<div class="pageContent">
	<div class="panelBar">
		<ul class="toolBar">
			<li><a class="add" href="<%=Request.GetPath() %>/Edit.aspx"target="dialog" width="1000" height="500" title="添加样式信息" rel="template_css_add"><span>添加</span></a></li>
			<li><a title="确实要删除这些记录吗?" target="selectedTodo" rel="ids" href="<%=Request.GetPath() %>/SaveDel.ashx" class="delete"><span>删除所选</span></a></li>
			<li><a class="edit" href="<%=Request.GetPath() %>/Edit.aspx?id={sid}"target="dialog" width="1000" height="500" title="修改样式信息" rel="template_css_edit" warn="请选择一条数据"><span>修改</span></a></li>
			
		</ul>
	</div>
	<table class="table" width="100%" layoutH="138">
		<thead>
			<tr>
				<th width="22"><input type="checkbox" group="ids" class="checkboxCtrl"></th>
				<th width="150">文件名称</th>
				<th width="280">文件路径</th>
				<th width="60">文件类型</th>
				<th width="60">文件大小</th>
				<th width="120">创建人</th>
				<th width="22" style="display:none;">创建人编号</th>
				<th width="150">创建时间</th>
				<th width="120">修改人名称</th>
				<th width="22" style="display:none;">修改人编号</th>
				<th width="150">修改时间</th>
				<th width="40">版本信息</th>
				<th>文件描述</th>
			</tr>
		</thead>
		<tbody>
            <asp:repeater runat="server" ID="Rep_List">
            <ItemTemplate>            
			<tr target="sid" rel="<%#Eval("ID") %>">
				<td><input name="ids" value="<%#Eval("ID") %>" type="checkbox"></td>
				<td><%#Eval("FileName")%></td>
				<td><%#Eval("DirPath")%></td>
				<td><%#Eval("FileType")%></td>				
				<td><%#Eval("FileLength")%></td>
				<td><%#Eval("CreateUser")%></td>
				<td><%#Eval("CreateUserId")%></td>				
				<td><%#Eval("ModifyUser")%></td>
				<td><%#Eval("ModifyUserId")%></td>
				<td><%#Eval("CreateTime")%></td>				
				<td><%#Eval("ModifyTime")%></td>
				<td><%#Eval("HistoryVision")%></td>
				<td><%#Eval("FileDiscrption")%></td>				
			</tr>
            </ItemTemplate>
            </asp:repeater>
		</tbody>
	</table>
	<div class="panelBar">
		<div class="pages">
			<span>显示</span>
			<select class="combox" name="numPerPage" onchange="navTabPageBreak({numPerPage:this.value})">
				<option value="20">20</option>
				<option value="50">50</option>
				<option value="100">100</option>
				<option value="200">200</option>
			</select>
			<span>条，共<%=TotalCount%>条，每页<%=PageSize%>条，当前第<%=PageNum %>/<%=(TotalCount + PageSize-1)/PageSize%>页</span>

		</div>
	<div id="moveContent" style="position:absolute; width:600px; border:3px solid red; top:0; left:0; display:none; background:#FFF; padding:5px;"></div>	
		
        <div class="pagination" targetType="navTab" totalCount="<%=TotalCount %>" numPerPage="<%=PageSize %>" pageNumShown="<%=PageNumShown %>" currentPage="<%=PageNum %>"></div>
	</div>
</div>


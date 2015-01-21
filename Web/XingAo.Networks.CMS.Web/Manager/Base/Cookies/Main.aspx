<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Base.Cookies.Main" %>
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
					Cookie名称：<input type="text" name="keyString" value="<%=keyString %>" />
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
			<li><a title="确实要删除这些记录吗?" target="selectedTodo" rel="ids" href="<%=Request.GetPath() %>/SaveDel.ashx" class="delete"><span>删除所选</span></a></li>			
		</ul>
	</div>
	<table class="table" width="100%" layoutH="138">
		<thead>
			<tr>
				<th width="22"><input type="checkbox" group="ids" class="checkboxCtrl"></th>
				<th width="150">网站地址</th>
				<th>分割份数</th>
				<th>添加时间</th>
				<th>存放类型</th>
				<th>数据类型</th>
				<th>验证标记</th>
			</tr>
		</thead>
		<tbody>
            <asp:repeater runat="server" ID="Rep_List">
            <ItemTemplate>            
			<tr target="sid" rel="<%#Eval("ValuesType") %>">
				<td><input name="ids" value="<%#Eval("ValuesType") %>" type="checkbox"></td>
				<td><%#Eval("SiteUrl")%></td>
				<td align="center"><%#Eval("Count")%></td>				
				<td><%#Eval("AddTime")%></td>
				<td><%#Eval("CookiesType")%></td>				
				<td><%#Eval("ValuesType")%></td>
				<td><%#Eval("Sign")%></td>		
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


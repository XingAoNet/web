<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.CacheManager.Main" %>
<%@ Import Namespace="XingAo.Core" %>
<form id="pagerForm" method="post" action="<%=Request.GetPath() %>/main.aspx">
    <input type="hidden" name="status" value="status">
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
		<%--<table class="searchContent">
			<tr>
				<td>
					缓存名称：<input type="text" name="keyString" value="<%=keyString %>" />
				</td>
			</tr>
		</table>
		<div class="subBar">
			<ul>
				<li><div class="buttonActive"><div class="buttonContent"><button type="submit">查询</button></div></div></li>
			</ul>
		</div>--%>
	</div>
	</form>
</div>
<div class="pageContent">
	<div class="panelBar">
		<ul class="toolBar"> 			
			<li><a title="确实要删除这些记录吗?" target="selectedTodo" rel="ids" href="<%=Request.GetPath() %>/SaveDel.ashx" class="delete"><span>删除所选</span></a></li>
			<li><a class="edit" href="<%=Request.GetPath() %>/Edit.aspx?MenuID=<%=Request.QueryString["MenuID"]%>&id={sid}" target="navTab" warn="请选择一条数据"><span>修改</span></a></li>
			
		</ul>
	</div>
	<table class="table" width="100%" layoutH="123" cellspacing="2" id="myContentList">
		<thead>
			<tr>
            	<th width="5%" align="center"><input type="checkbox" group="ids" class="checkboxCtrl"></th>         
				<th width="30%">名称</th>	
                <th>值</th>	
			</tr>
		</thead>
		<tbody>
            <asp:repeater ID="Repeater1" runat="server">
            <ItemTemplate>
			<tr target="ItemId" rel="<%#Eval("CacheName") %>">
            <td align="center"><input name="ids" value="<%#Eval("CacheName") %>" type="checkbox"></td>          
				<td><%#Eval("CacheName")%></td>
                <td><a href="CacheManager/ShowCacheValue.aspx?v=<%#Eval("CacheName")%>" target="dialog" title="<%#Eval("CacheName")%>"><%#Server.HtmlEncode(Eval("Value").ToString())%></a></td>
			</tr>
            </ItemTemplate>
            </asp:repeater>
		</tbody>
	</table>
	
</div>


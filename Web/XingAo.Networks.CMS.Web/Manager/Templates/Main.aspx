<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Templates.Main" %>
<%@ Import Namespace="XingAo.Core" %>
<form id="pagerForm" method="post" action="<%=Request.GetPath() %>/main.aspx">
    <input type="hidden" name="status" value="status">
	<input type="hidden" name="keyString" value="<%=keyString %>" />
	<input type="hidden" name="pageNum" value="<% =PageNum %>" />
	<input type="hidden" name="numPerPage" value="<%=PageSize %>" />
    <input type="hidden" name="sTemplateType" value="<%=sTemplateType %>" />
	<input type="hidden" name="orderField" value="id" />
    <input type="hidden" name="GroupID" value="<%=Request["GroupID"]%>" />
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
					模板类型：
                    <select runat="server" ID="TemplateType">
                      <option Value="">不限</option>
                      <option Value="0">公共模块</option>
                      <option Value="1">首页模板</option>
                      <option Value="2">列表页模板</option>
                      <option Value="3">详细页模板</option>
                    </select>
                    所属分组：<asp:literal runat="server" ID="TempLateGroupID"></asp:literal>
                    名称：<input type="text" name="keyString" value="<%=keyString %>" />
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
			<li><a class="add" href="<%=Request.GetPath() %>/Edit.aspx?MenuID=<%=Request.QueryString["MenuID"]%>" target="dialog" width="1000" height="500" title="添加模板信息" rel="template_add"><span>添加</span></a></li>
			<li><a title="确实要删除这些记录吗?" target="selectedTodo" rel="ids" href="<%=Request.GetPath() %>/SaveDel.ashx" class="delete"><span>删除所选</span></a></li>
			<li><a class="edit" href="<%=Request.GetPath() %>/Edit.aspx?MenuID=<%=Request.QueryString["MenuID"]%>&id={sid}" target="dialog" width="1000" height="500" title="修改模板信息" rel="template_edit" warn="请选择一条数据"><span>修改</span></a></li>
			
		</ul>
	</div>
	<table class="table" width="100%" layoutH="138">
		<thead>
			<tr>
				<th width="22"><input type="checkbox" group="ids" class="checkboxCtrl"></th>
				<th width="220">模板名称</th>
				<th width="80">模板类型</th>
				<th>描述</th>
			</tr>
		</thead>
		<tbody>
            <asp:repeater runat="server" ID="Rep_List">
            <ItemTemplate>            
			<tr target="sid" rel="<%#Eval("ID") %>">
				<td><input name="ids" value="<%#Eval("ID") %>"<%#Eval("ID").ToString()=="1"?" disabled":"" %> type="checkbox"></td>
				<td><%#Eval("TemplateName")%></a></td>
				<td><%#GetTemplateType(Eval("TemplateType").ToString())%></td>
				<td><%#Eval("TemplateDescription")%></td>				
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
		
		
        <div class="pagination" targetType="navTab" totalCount="<%=TotalCount %>" numPerPage="<%=PageSize %>" pageNumShown="<%=PageNumShown %>" currentPage="<%=PageNum %>"></div>
	</div>
</div>


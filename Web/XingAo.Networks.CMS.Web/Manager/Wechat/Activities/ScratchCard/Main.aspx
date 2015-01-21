<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.Activities.ScratchCard.Main" %>

<%@ Import Namespace="XingAo.Core" %>
<form id="pagerForm" method="post" action="<%=Request.GetPath() %>/main.aspx">
    <input type="hidden" name="status" value="status">
	<input type="hidden" name="keywords" value="<%=keyString %>" />
	<input type="hidden" name="pageNum" value="<% =PageNum %>" />
	<input type="hidden" name="numPerPage" value="<%=PageSize %>" />
	<input type="hidden" name="orderField" value="id" />
</form>


<div class="pageHeader">
	<form onsubmit="return navTabSearch(this);" method="post">
	<div class="searchBar">
		<table class="searchContent">
			<tr>
				<td>
					关键字：<input type="text" name="keyString" value="<%=keyString%>" />
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
			<li><a class="add" href="<%=Request.GetPath() %>/Edit.aspx" target="navTab"><span>添加</span></a></li>
			<li><a title="确实要删除这些记录吗?" target="selectedTodo" rel="ids" href="<%=Request.GetPath() %>/SaveDel.ashx" class="delete"><span>删除所选</span></a></li>
			<li><a class="edit" href="<%=Request.GetPath() %>/Edit.aspx?id={sid}" target="navTab" warn="请选择一条数据"><span>修改</span></a></li>
			
		</ul>
	</div>
	<table class="table" width="100%" layoutH="138">
		<thead>
			<tr>
				<th width="22"><input type="checkbox" group="ids" class="checkboxCtrl"></th>
                <th width="200">活动标题</th>
				<th width="120">关键字</th>
                <th width="250">活动时间</th>
                <th width="50">排序号</th>
                <th width="60">状态</th>
                <th>奖品设置</th>
                <th>获奖名单</th>
			</tr>
		</thead>
		<tbody>
            <asp:repeater runat="server" ID="Rep_List">
                <ItemTemplate>            
			        <tr target="sid" rel="<%#Eval("ID") %>">
				        <td><input name="ids" value="<%#Eval("ID") %>" type="checkbox"/></td>
                        <td><%#Eval("Title")%></td>
				        <td><%#Eval("Keys")%></td>
                        <td class="pictureTd">开始时间：<%#Eval("StartTime")%> <br />截止时间：<%#Eval("EndTime")%></td>
				        <td><%#Eval("OrderID")%></td>
                        <td><%#Eval("CanUse")%></td>
                        <td><a href="/Manager/Wechat/Activities/ScratchCard/GoodsList.aspx?SGuid=<%#Eval("SGuid") %>" target="navTab" rel="navTab_GoodsList" style="color:blue;">编辑</a>
                        </td>
                        <td><a class="look" href="<%=Request.GetPath() %>/ShowPrize.aspx?SGuid=<%#Eval("SGuid") %>" target="dialog" height="350" style="color:blue;">查看</a>
                        </td>		
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
			<span>条，共<%=TotalCount%>条，每页<%=PageSize%>条，当前第<%=PageNum %>/<%=(TotalCount + PageSize - 1) / PageSize%>页</span>

		</div>

        <div class="pagination" targetType="navTab" totalCount="<%=TotalCount %>" numPerPage="<%=PageSize %>" pageNumShown="<%=PageNumShown %>" currentPage="<%=PageNum %>"></div>
	</div>
</div>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits=" XingAo.Networks.CMS.Web.Manager.SMS.SMSSend.Main" %>
<%@ Import Namespace="XingAo.Core" %>
<style>
.grid .gridTbody td.pictureTd div{height:auto;}
</style>
<form id="pagerForm" method="post" action="<%=Request.GetPath() %>/main.aspx">
    <input type="hidden" name="status" value="status">
	<input type="hidden" name="keywords" value="<%=keyString %>" />
	<input type="hidden" name="keyResult" value="<%=keyResult %>" />
	<input type="hidden" name="pageNum" value="<% =PageNum %>" />
	<input type="hidden" name="numPerPage" value="<%=PageSize %>" />
	<input type="hidden" name="orderField" value="id" />
</form>


<div class="pageHeader">
	<form onsubmit="return navTabSearch(this);" action="<%=Request.GetPath() %>/main.aspx" method="post"><%--基于Manager目录开始的路径--%>
	<div class="searchBar">
		<table class="searchContent">
			<tr>
				<td>
					手机号码：<input type="text" name="keyString" value="<%=keyString %>" />
				</td>
                <td>
					发送结果：<select name="keyResult">
                    <option value="">--全部--</option>
                    <option value="发送成功"<%=keyResult=="发送成功"?" selected":"" %>>发送成功</option> 
                    <option <%=keyResult=="提交的号码中包含不符合格式的手机号码"?" selected":"" %>>提交的号码中包含不符合格式的手机号码</option>
                    <option <%=keyResult=="数据保存失败"?" selected":"" %>>数据保存失败</option>
                    <option <%=keyResult=="用户名或密码错误"?" selected":"" %>>用户名或密码错误</option>
                    <option <%=keyResult=="余额不足"?" selected":"" %>>余额不足</option>
                    <option <%=keyResult=="参数错误，请输入完整的参数"?" selected":"" %>>参数错误，请输入完整的参数</option>
                    <option <%=keyResult=="其他错误"?" selected":"" %>>其他错误</option>
                    <option <%=keyResult=="预约时间格式不正确"?" selected":"" %>>预约时间格式不正确</option>
                    </select>
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
			<li><a class="add" href="<%=Request.GetPath() %>/Send.aspx" target="navTab"><span>发送短信</span></a></li>
            <li><a class="add" href="<%=Request.GetPath() %>/SaveDel.ashx?action=resend&pagenum=<% =PageNum %>&pagesize=<%=PageSize %>"  rel="ids" title="您确定要重新发送?"   target="selectedTodo"><span>重发短信</span></a></li>
		</ul>
	</div>
	<table class="table" width="100%" layoutH="138">
		<thead>
			<tr>
				<th width="22"><input type="checkbox" group="ids" class="checkboxCtrl" /></th>
				<th width="90">手机号码</th>
                <th width="70">发送结果</th>
				<th width="100">发送人</th>
				<th width="120">时间</th>
                <th>内容</th>
			</tr>
		</thead>
		<tbody>
            <asp:repeater runat="server" ID="Rep_List">
            <ItemTemplate>            
			<tr target="sid" rel="<%#Eval("ID") %>">
				<td ><input name="ids" value="<%#Eval("ID") %>" type="checkbox"></td>
				<td><%#Eval("Mobiles")%></td>
                <td><%#Eval("SendResultMsg")%></td>
                <td><%#Eval("SendName")%></td>
                <td><%#Eval("SendDateTime")%></td>
                <td title="<%#Eval("MsgInfo")%>"><%#Eval("MsgInfo")%></td>			
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


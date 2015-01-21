<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowRegist.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.Activities.Registration.ShowRegist" %>
<%@ Import Namespace="XingAo.Core" %>
<div class="pageContent">
<div id="jbsxBox" class="unitBox">
<form id="pagerForm" method="post" action="<%=Request.GetPath() %>/ShowRegist.aspx?aguid=<%=Request.QueryString["aguid"]%>">
    <input type="hidden" name="status" value="status">
	<input type="hidden" name="keywords" value="<%=keyString %>" />
	<input type="hidden" name="pageNum" value="<% =PageNum %>" />
	<input type="hidden" name="numPerPage" value="<%=PageSize %>" />
	<input type="hidden" name="orderField" value="id" />
</form>


<div class="pageHeader">
	<form  onsubmit="return divSearch(this, 'jbsxBox');" action="<%=Request.GetPath() %>/ShowRegist.aspx?aguid=<%=Request.QueryString["aguid"]%>" method="post">
	<div class="searchBar">
		<table class="searchContent">
			<tr>
				<td>
					姓名：<input type="text" name="keyString" value="<%=keyString%>" />
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
	<table class="table" layoutH="118" targetType="dialog" width="100%">
		<thead>
			<tr>
				<th width="120">姓名</th>
				<th width="280">手机号码</th>
                <%=GetTdHead(TdHead,0)%>
			</tr>
		</thead>
		<tbody>
            <asp:repeater runat="server" ID="Rep_List">
                <ItemTemplate>            
			        <tr target="sid" rel="<%#Eval("ID") %>">
				        <td><%#Eval("Name")%></td>
				        <td><%#Eval("TelPhone")%></td>
                        <%#GetTdHead(Eval("Address").ToString(),1)%>
			        </tr>
                </ItemTemplate>
            </asp:repeater>
		</tbody>
	</table>
	<div class="panelBar">
		<div class="pages">
			<span>共<%=TotalCount%>条，每页<%=PageSize%>条，当前第<%=PageNum %>/<%=(TotalCount + PageSize - 1) / PageSize%>页</span>

		</div>

        <div class="pagination" rel="jbsxBox" targetType="dialog" totalCount="<%=TotalCount %>" numPerPage="<%=PageSize %>" pageNumShown="<%=PageNumShown %>" currentPage="<%=PageNum %>"></div>
	</div>
</div>
</div>
</div>
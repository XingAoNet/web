<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountsGet.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.WeiXin.AccountsGet" %>
<%@ Import Namespace="XingAo.Core" %>
<asp:panel runat="server" ID="p1">

<div class="pageHeader">
	<form id="pagerForm" rel="pagerForm" method="post" action="Wechat/WeiXin/AccountsGet.aspx"  runat="server"  onsubmit="return dwzSearch(this, 'dialog');">
	  <div class="searchBar">
		<table class="searchContent">
			<tr>
				<td>
					微友分组：
				</td>
				<td>
					 <asp:dropdownlist runat="server" CssClass="combox" id="groupid"></asp:dropdownlist>
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
				<th width="120">账号</th>
				<th width="100">备注</th>
			</tr>
		</thead>
		<tbody>
            <asp:repeater runat="server" ID="Rep_List">
                <ItemTemplate>            
			        <tr target="sid" rel="<%#Eval("ID") %>">
				        <td><a href="javascript:" onclick="$.CallBackSetFormValue(['<%#Eval("ID") %>','<%#Eval("ID")%>'])"><%#Eval("nick_name")%></a></td>
				        <td><%#Eval("remark_name")%></td>
                     
			        </tr>
                </ItemTemplate>
            </asp:repeater>
		</tbody>
	</table>
	<div class="panelBar">
		<div class="pages">
			<span>显示</span>
			<select class="combox" name="numPerPage" onchange="dwzPageBreak({targetType:dialog:this.value})">
				<option value="20">20</option>
				<option value="50">50</option>
				<option value="100">100</option>
				<option value="200">200</option>
			</select>
			<span>条，共<%=TotalCount%>条，每页<%=PageSize%>条，当前第<%=PageNum %>/<%=(TotalCount + PageSize-1)/PageSize%>页</span>

		</div>
		
		
        <div class="pagination" targetType="dialog" totalCount="<%=TotalCount %>" numPerPage="<%=PageSize %>" pageNumShown="<%=PageNumShown %>" currentPage="<%=PageNum %>"></div>
	</div>
</div>

</asp:panel>
﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScratchCardListPage.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.Sources.ScratchCardListPage" %>
<%@ Import Namespace="XingAo.Core" %>
<form id="pagerForm" method="post" action="<%=Request.GetPath() %>/main.aspx">
    <input type="hidden" name="status" value="status" />
	<input type="hidden" name="keywords" value="<%=keyString %>" />
	<input type="hidden" name="pageNum" value="<% =PageNum %>" />
	<input type="hidden" name="numPerPage" value="<%=PageSize %>" />
	<input type="hidden" name="orderField" value="id" />
</form>

<div class="pageHeader">
	<form id="Form1" onsubmit="return divSearch(this, 'jbsxBox');" action="<%=Request.GetPath() %>/ImageTextListPage.aspx" method="post">
	<div class="searchBar">
		<table class="searchContent">
			<tr>
				<td>
					关键字：<input type="text" name="keyString" value="<%=keyString %>" />
				</td>
                <td><div class="buttonActive"><div class="buttonContent"><button type="submit">查询</button></div></div></td>
				<td>返回最新记录数：<input type="text" id="LimitNum" value="" /></td>
                <td><div class="buttonActive"><div class="buttonContent"><button type="button" onclick="javascript:$.bringBack({txtKeys:'Limit_'+$('#LimitNum').val(), txtKeys_text:'最新刮刮卡','txtSource':'ScratchCard'})">确定</button></div></div></td>
			</tr>
		</table>
	</div>
	</form>
</div>
<div class="pageContent">
	 <table class="table" layoutH="118" targetType="dialog" width="100%">
	    <thead>
		    <tr>
			    <th width="30"></th>
                <th>关键字</th>
			    <th>标题</th>
		    </tr>
	    </thead>
            <asp:repeater runat="server" ID="Rep_List">
                <ItemTemplate> 
                    <tr>
                        <td>
					    <a class="btnSelect" href="javascript:$.bringBack({txtKeys:'<%#Eval("SGuid")%>', txtKeys_text:'<%#Eval("Keys")%>','txtSource':'ScratchCard','txtAutoId':'<%#Eval("ID")%>'})" title="查找带回">选择</a>
				        </td>
                        <td><%#Eval("Keys")%></td>
                        <td><%#Eval("Title")%></td>
                    </tr>  
                </ItemTemplate>
            </asp:repeater>
        </table>
	 <div class="panelBar">
		<div class="pages">
			<span>显示</span>
            <select class="combox" name="numPerPage" onchange="navTabPageBreak({numPerPage:this.value}, 'jbsxBox')">
				<option value="20">20</option>
				<option value="50">50</option>
				<option value="100">100</option>
				<option value="200">200</option>
			</select>
			<span>条，共<%=TotalCount%>条，每页<%=PageSize%>条，当前第<%=PageNum %>/<%=(TotalCount + PageSize - 1) / PageSize%>页</span>

		</div>

        <div class="pagination" rel="jbsxBox" targetType="dialog"  totalCount="<%=TotalCount %>" numPerPage="<%=PageSize %>" pageNumShown="<%=PageNumShown %>" currentPage="<%=PageNum %>"></div>
	</div>
</div>
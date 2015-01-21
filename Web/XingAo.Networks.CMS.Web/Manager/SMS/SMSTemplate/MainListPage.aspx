<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainListPage.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.SMS.SMSTemplate.MainListPage" %>
<%@ Import Namespace="XingAo.Core" %>

<form id="pagerForm" method="post" action="<%=Request.GetPath() %>/MainListPage.aspx">
    <input type="hidden" name="status" value="status">
	<input type="hidden" name="keyString" value="<%=keyString %>" />
	<input type="hidden" name="pageNum" value="<% =PageNum %>" />
	<input type="hidden" name="numPerPage" value="<%=PageSize %>" />
</form>

<div class="pageHeader">
	<form id="Form1" onsubmit="return dwzSearch(this, 'dialog');" action="<%=Request.GetPath() %>/MainListPage.aspx"  method="post">
	<div class="searchBar">
		<table class="searchContent">
			<tr>

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
                <th>短信模板名称</th>
                <th>短信模板内容</th>
                <th>添加时间</th>
                <th>编辑时间</th>
		    </tr>
	    </thead>
            <asp:repeater runat="server" ID="Rep_List">
                <ItemTemplate> 
                    <tr>
                        <td>
                         <a class="btnSelect" href="javascript:$.bringBack({'TextMessage':'<%#Eval("TempContent") %>'})" title="查找带回">选择</a>
				        </td>
				        <td><%#Eval("TemplatesName")%></td>
                        <td><%#Eval("TempContents")%></td>
                        <td><%#Eval("AddTime")%></td>
                        <td><%#Eval("EditTime")%></td>
                    </tr>  
                </ItemTemplate>
            </asp:repeater>
        </table>
	 <div class="panelBar">
		<div class="pages">
			<span>显示</span>
           <select name="numPerPage" onchange="dwzPageBreak({targetType:dialog, numPerPage:'<%=PageSize %>'})">
				<option value="20">20</option>
				<option value="50">50</option>
				<option value="100">100</option>
				<option value="200">200</option>
			</select>
			<span>条，共<%=TotalCount%>条，每页<%=PageSize%>条，当前第<%=PageNum %>/<%=(TotalCount + PageSize - 1) / PageSize%>页</span>

		</div>

        <div class="pagination" targetType="dialog"  totalCount="<%=TotalCount %>" numPerPage="<%=PageSize %>" pageNumShown="<%=PageNumShown %>" currentPage="<%=PageNum %>"></div>
	</div>
</div>
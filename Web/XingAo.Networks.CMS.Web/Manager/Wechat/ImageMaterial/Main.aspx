<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.ImageMaterial.Main" %>
<%@ Import Namespace="XingAo.Core" %>
<form id="pagerForm" method="post" action="<%=Request.GetPath() %>/main.aspx">
    <input type="hidden" name="status" value="status">
	<input type="hidden" name="keyString" value="<%=keyString %>" />
	<input type="hidden" name="pageNum" value="<% =PageNum %>" />
	<input type="hidden" name="numPerPage" value="<%=PageSize %>" />
	<input type="hidden" name="orderField" value="id" />
    <input type="hidden" name="kind" value="<%=txtParentID%>" />
</form>


<div class="pageHeader">
	<form onsubmit="return navTabSearch(this);" runat="server"  method="post">
	<div class="searchBar">
		<table class="searchContent">
			<tr>
				<td>
					关键字：<input type="text" name="keyString" value="<%=keyString %>" />
				</td>
                <td>
					分类：<asp:dropdownlist ID="txtParentID" runat="server"></asp:dropdownlist>
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
			<li><a class="add" href="<%=Request.GetPath() %>/Edit.aspx" target="dialog" width="1000" height="500" title="添加" rel="ImageMaterial_add"><span>添加</span></a></li>
			<li><a title="确实要删除这些记录吗?" target="selectedTodo" rel="ids" href="<%=Request.GetPath() %>/SaveDel.ashx" class="delete"><span>删除所选</span></a></li>
			<li><a class="edit" href="<%=Request.GetPath() %>/Edit.aspx?id={sid}"  target="dialog" width="1000" height="500" title="修改" rel="ImageMaterial_edit" warn="请选择一条数据"><span>修改</span></a></li>
			
		</ul>
	</div>
	<table class="table" width="100%" layoutH="138">
		<thead>
			<tr>
				<th width="22"><input type="checkbox" group="ids" class="checkboxCtrl"></th>
                <th width="100">类别</th>
				<th width="250">关键字</th>
				<th width="250">回答</th>
				<th width="60">匹配类型</th>
                <th width="50">排序号</th>                
                <th width="100" style="display:none;">链接地址</th>
                <th>时间</th>
			</tr>
		</thead>
		<tbody>
        <script type="text/javascript">
  var copydynamic,copydyn;</script>
            <asp:repeater runat="server" ID="Rep_List">
            <ItemTemplate>            
			<tr target="sid" rel="<%#Eval("ID") %>">
				<td><input name="ids" value="<%#Eval("ID") %>" type="checkbox"></td>
                <td><%#GetMaterialFamily(Eval("Name"))%></td>
				<td><%#Eval("Keys")%></td>
				<td><%#Eval("Title")%></td>
                <td><%#Eval("KeyType")%></td>
				<td><%#Eval("OrderID")%></td>                
                <td class="copydynamic" style="display:none;">  
                         <span class="copydyn" data="<%#Eval("CurrentUrl")%>">复制</span>   </td> 
                <td><%#StringOption.ObjToDate(Eval("EditTime").ToString(),DateTime.Now).ToString("yy年MM月dd日")%></td>	

			</tr>
            </ItemTemplate>
            </asp:repeater>

		</tbody>
	</table>
    <div id="sssss" style="display:none;"></div>
   
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
            
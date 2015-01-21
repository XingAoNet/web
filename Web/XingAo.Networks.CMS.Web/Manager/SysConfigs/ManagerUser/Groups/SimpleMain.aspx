<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SimpleMain.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.SysConfigs.ManagerUser.Groups.SimpleMain" %>
<div class="pageContent">
	<div class="pageFormContent" layoutH="58">
		<table class="table" layoutH="118" targetType="dialog" width="100%">
		<thead>
			<tr>
				<th width="30"><input type="checkbox" class="checkboxCtrl" group="orgId" /></th>
				<th>组名</th>
			</tr>
		</thead>
		<tbody>
			
            <asp:repeater runat="server" ID="Rep_List">
            <Itemtemplate>
			<tr>
            	<td><input type="checkbox" name="orgId" value="{'txtGroupIDs':'<%#Eval("ID")%>', 'txtGroupIDs_text':'<%#Eval("GroupName")%>'}"/></td>
				<td><%#Eval("GroupName")%></td>				
			</tr>
            </Itemtemplate>
            </asp:repeater>
		</tbody>
	</table>
	</div>
	
	<div class="formBar">
		<ul>
			<li><div class="button"><div class="buttonContent"><button type="button" multLookup="orgId" warn="至少要选择一项">确定</button></div></div></li>
            <li><div class="button"><div class="buttonContent"><button class="close" type="button">关闭</button></div></div></li>
		</ul>
	</div>
</div>



<%--
<div class="pageHeader">
	<form rel="pagerForm" method="post" action="demo/database/dwzOrgLookup2.html" onsubmit="return dwzSearch(this, 'dialog');">
	<div class="searchBar">		
		<div class="subBar">
			<ul>				
				<li><div class="button"><div class="buttonContent"><button type="button" multLookup="orgId" warn="请选择部门">选择带回</button></div></div></li>
			</ul>
		</div>
	</div>
	</form>
</div>


<div class="pageContent">

	<table class="table" layoutH="118" targetType="dialog" width="100%">
		<thead>
			<tr>
				<th width="30"><input type="checkbox" class="checkboxCtrl" group="orgId" /></th>
				<th orderfield="orgName">部门名称</th>
				<th orderfield="orgNum">部门编号</th>
				<th orderfield="leader">部门经理</th>
				<th orderfield="creator">创建人</th>
			</tr>
		</thead>
		<tbody>
			<tr>
				<td><input type="checkbox" name="orgId" value="{id:'1', orgName:'技术部', orgNum:'1001'}"/></td>
				<td>技术部</td>
				<td>1001</td>
				<td>leader</td>
				<td>administrator</td>
			</tr>
			<tr>
				<td><input type="checkbox" name="orgId" value="{id:'2', orgName:'人事部', orgNum:'1002'}"/></td>
				<td>人事部</td>
				<td>1002</td>
				<td>test</td>
				<td>administrator</td>
			</tr>
			<tr>
				<td><input type="checkbox" name="orgId" value="{id:'3', orgName:'销售部', orgNum:'1003'}"/></td>
				<td>人事部</td>
				<td>1002</td>
				<td>test</td>
				<td>administrator</td>
			</tr>
		</tbody>
	</table>
</div>--%>
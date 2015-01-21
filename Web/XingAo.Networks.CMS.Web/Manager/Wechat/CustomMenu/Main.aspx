<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.CustomMenu.Main" %>
<%@ Import Namespace="XingAo.Core" %>
<div class="pageContent">
	<div class="panelBar">
		<ul class="toolBar">
			<li><a class="add" href="<%=Request.GetPath() %>/Edit.aspx" target="dialog" width="1000" height="600" title="添加"  rel="CustomMenu_edit"><span>添加</span></a></li>
			<li><a title="确实要删除这些记录吗?" target="selectedTodo" rel="ids" href="<%=Request.GetPath() %>/SaveDel.aspx?action=del" class="delete"><span>删除所选</span></a></li>
			<li><a class="edit" href="<%=Request.GetPath() %>/Edit.aspx?id={sid}" target="dialog" width="1000" height="600" title="修改" rel="CustomMenu_edit" warn="请选择一条数据"><span>修改</span></a></li>
            <li><a class="add" title="确实要要生成菜单吗?" href="<%=Request.GetPath() %>/SaveDel.ashx?action=create" target="ajaxTodo"><span>生成自定义菜单</span></a></li>
			
		</ul>
	</div>
	<table class="table" layoutH="138">
		<thead>
			<tr>
                <th width="20"></th>
				<th width="380">主菜单名称</th>
				<th width="280">触发关键词或链接地址</th>
                <th width="120">显示顺序</th>
                <th width="80">启用</th>
			</tr>
		</thead>
		<tbody>
            <asp:repeater runat="server" ID="Rep_List">
                <ItemTemplate>            
			        <tr target="sid" rel="<%#Eval("ID") %>">
                        <td><input name="ids" value="<%#Eval("ID") %>" type="checkbox"></td>
				        <td><%#"".PadRight(Eval("deep").ObjToInt() * 8, (char)0xA0) + Eval("Name")%></td>
				        <td><%#Eval("Keys")%></td>
                        <td><%#Eval("OrderID")%></td>
                        <td><%#Eval("CanUse")%></td>				
			        </tr>
                </ItemTemplate>
            </asp:repeater>
		</tbody>
	</table>
</div>
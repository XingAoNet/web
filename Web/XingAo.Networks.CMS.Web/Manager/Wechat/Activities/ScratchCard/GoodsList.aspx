<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsList.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.Activities.ScratchCard.GoodsList" %>
<%@ Import Namespace="XingAo.Core" %>

<div class="pageContent">
	<div class="panelBar">
		<ul class="toolBar">
			<li><a class="add" href="<%=Request.GetPath() %>/GoodsEdit.aspx?SGuid=<%=SGuid%>" target="dialog" height="350"><span>添加</span></a></li>
			<li><a title="确实要删除这些记录吗?" target="selectedTodo" rel="ids" href="<%=Request.GetPath() %>/SaveDel.ashx" class="delete"><span>删除所选</span></a></li>
			<li><a class="edit" href="<%=Request.GetPath() %>/GoodsEdit.aspx?id={sid}&SGuid=<%=SGuid%>" target="dialog" height="350" warn="请选择一条数据"><span>修改</span></a></li>
			
		</ul>
	</div>
	<table class="table" layoutH="138">
		<thead>
			<tr>
				<th width="22"><input type="checkbox" group="ids" class="checkboxCtrl" /></th>
                <th width="200">奖品</th>
				<th width="120">数量</th>
                <th width="250">修改时间</th>
			</tr>
		</thead>
		<tbody>
            <asp:repeater runat="server" ID="Rep_List">
                <ItemTemplate>            
			        <tr target="sid" rel="<%#Eval("ID") %>">
				        <td><input name="ids" value="<%#Eval("ID") %>" type="checkbox"/></td>
                        <td><%#Eval("GoodsName")%></td>
				        <td><%#Eval("GoodsCount")%></td>
                        <td><%#Eval("EditTime")%></td>
			        </tr>
                </ItemTemplate>
            </asp:repeater>
		</tbody>
	</table>

</div>
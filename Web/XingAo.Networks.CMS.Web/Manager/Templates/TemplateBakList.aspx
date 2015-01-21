<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemplateBakList.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Templates.TemplateBakList" %>

<form id="form1" runat="server">
<div class="pageContent">

	<table class="table" layoutH="28" targetType="dialog" width="100%">
		<thead>
			<tr>
				<th>模板名称</th>
				<th width="70" align="center">创建时间</th>
                <th width="70" align="center">更新时间</th>
				<th>备注</th>				
			</tr>
		</thead>
		<tbody>
       

            <asp:repeater runat="server" ID="Rep_List">
                <ItemTemplate>
			<tr>
				<td style=" cursor:pointer" onclick="$.CallBackSetFormValue(['<%#Eval("ID") %>', '<%#Eval("Title") %>'])"><%#Eval("Title") %></td>
				<td align="center"><%#Eval("CreateTime","{0:yyyy-MM-dd}")%></td>
                <td align="center"><%#Eval("LastUpdateTime", "{0:yyyy-MM-dd}")%></td>
				<td><%#Eval("Descriptions")%></td>				
			</tr>
            </ItemTemplate>
            </asp:repeater>
			<tr style=" color:Red;">
				<td style=" cursor:pointer" onclick="$.CallBackSetFormValue(['0', '原始模板'])">原始模板</td>
				<td align="center">/</td>
				<td align="center">/</td>
				<td align="center">系统默认模板</td>
			</tr>
		</tbody>
	</table>	
</div>
</form>

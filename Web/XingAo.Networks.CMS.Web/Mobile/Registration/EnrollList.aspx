<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnrollList.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Mobile.Registration.EnrollList" %>

<table cellpadding="0" cellspacing="1">
<tr>
    <td>报名者</td>
    <td style="width:90px;">联系方式</td>
    <td style="width:110px;">报名时间</td>
</tr>
<asp:Repeater runat="server" ID="RegList">
    <ItemTemplate>
        <tr>
            <th><%#Eval("Name")%></th>
            <td><%#Eval("TelPhone")%></td>
            <td><%#Eval("IDateTime")%></td>
        </tr>
    </ItemTemplate>
</asp:Repeater>
</table>
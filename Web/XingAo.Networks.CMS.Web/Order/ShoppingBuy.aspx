<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingBuy.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Order.ShoppingBuy" %>


<%@ Import Namespace="XingAo.Core" %>
<asp:literal runat="server" ID="Head"></asp:literal>
    <form id="form1" runat="server" action="/ConformPay">
    <div class="Box">
    <table>
    <asp:repeater runat="server" ID="OrderBaseList"
            onitemdatabound="OrderBaseList_ItemDataBound">
        <ItemTemplate>
        <tr>
            <td><input type="checkbox" name="BID" value='<%#Eval("ID") %>' checked="checked" />订单号：<%#Eval("OrderCode")%>创建时间：<%#Eval("CreateTime")%><asp:HiddenField runat="server" id="HBid" value='<%#Eval("ID") %>'></asp:HiddenField></td>
        </tr>
        <tr>
        <td>
            <table>
            <tr>
                <th>商品名称</th>
                <th>购买数量</th>
                <th>单价</th>
                <th>小计</th>
                <th>可获积分</th>
                <th>抵价积分</th>
                <th>移除</th>
            </tr>
                <asp:repeater runat="server" ID="OrderInfoList" onitemcommand="OrderInfoList_ItemCommand">
                <ItemTemplate>
                <tr>
                <td><input type="checkbox" name="SID" Value='<%#Eval("ID") %>' checked="checked"/><%#Eval("ProductName") %></td>
                <td><input type="text" name="Count_<%#Eval("ID") %>" value="<%#Eval("BuyCount") %>" /></td>
                <td><%#Eval("Price")%></td>
                <td><%#Eval("BuyCount").ObjToInt() * Eval("Price").ObjToDecimal()%></td>
                <td><%#Eval("ProductGetPoint")%></td>
                <td><%#Eval("ProductPayMaxPoint")%>/100*<%#Eval("BuyCount")%>=<%#Eval("ProductPayMaxPoint").ObjToDecimal(0)*Eval("BuyCount").ObjToInt(0) / 100%>元</td>
                <td><asp:LinkButton runat="server" id="Del"  CommandName="Del" CommandArgument='<%#Eval("id") %>'>删除</asp:LinkButton></td>
            </tr>
                </ItemTemplate>
                </asp:repeater>
                
                </table>
        </td>
        </tr>
        </ItemTemplate>
        </asp:repeater>
       
        </table>
        <asp:button runat="server" text="Button" ID="Button1"/>
    </div>
    </form>
<asp:literal runat="server" ID="Foot"></asp:literal>
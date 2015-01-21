<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pay.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Order.Pay" EnableViewStateMac="false" %>
<%@ Import Namespace="XingAo.Core" %>
<asp:literal runat="server" ID="Head"></asp:literal>
    <form id="form1" runat="server">
    <div class="Box">
    支付页面
    <table>
    <tr>
    <th>订单编号</th>
    <th>创建日期</th>
    </tr>
        <asp:Repeater ID="Repeater1" runat="server" 
            onitemdatabound="Repeater1_ItemDataBound">
        <ItemTemplate>
        <tr>
            <td><%#Eval("OrderCode") %></td>
            <td><%#Eval("CreateTime")%></td>
        </tr>
        <tr>
            <td colspan="2">订单明细：<asp:HiddenField ID="BID" runat="server" Value='<%#Eval("ID") %>' />
            <table>
                <tr>
                    <th>商品名称</th>
                    <th>单价</th>
                    <th>购买数量</th>
                    <th>可获积分</th>
                <th>抵价积分</th>
                </tr>
                <asp:Repeater ID="Repeater2" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><a href="/CPXX/Category<%#Eval("BaseProduct_Base.ProductClassIDs").ToString().Trim(',').Split(',')[0] %>/Show<%#Eval("BaseProduct_Base.ID") %>" target="_blank"><%#Eval("ProductName")%></a></td>
                        <td><%#Eval("Price")%></td>
                        <td><%#Eval("BuyCount")%></td>
                        <td><%#Eval("ProductGetPoint")%></td>
                <td><%#Eval("ProductPayMaxPoint")%>/100*<%#Eval("BuyCount")%>=<%#Eval("ProductPayMaxPoint").ObjToDecimal(0)*Eval("BuyCount").ObjToInt(0) / 100%>元</td>
                    </tr>
                </ItemTemplate>
                </asp:Repeater>
            </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
        </table>
        <asp:checkbox runat="server" id="UsePoint" Text="使用积分抵价"></asp:checkbox>
        <br />
        支付方式：
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
            RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" value="/order/PayWith_Pay1">支付1</asp:ListItem>
            <asp:ListItem>支付2</asp:ListItem>
            <asp:ListItem>支付3</asp:ListItem>
        </asp:RadioButtonList>
        收货地址：<br />
        <asp:RadioButtonList ID="RadioButtonList2" runat="server">
        </asp:RadioButtonList>
        收货人：<asp:TextBox ID="txtNewName" runat="server"></asp:TextBox>
        收货地址：<asp:TextBox ID="txtNewAddr" runat="server"></asp:TextBox>
        联系电话：<asp:TextBox ID="txtNewTel" runat="server"></asp:TextBox>
&nbsp;<br />
        <asp:Button ID="Button1" runat="server" Text="确定支付" onclick="Button1_Click" />
    </div>
    </form>
<asp:literal runat="server" ID="Foot"></asp:literal>
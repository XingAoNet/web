<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/UcMaster.Master" AutoEventWireup="true" CodeBehind="UserOrderInfo.aspx.cs" Inherits="XingAo.Networks.CMS.Web.UserCenter.UserOrderInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript">
    $(function ()
    {
        var initSearch = $('#txtOrderSearch').val();
        $('#txtOrderSearch').click(function ()
        {
            $('#txtOrderSearch').val('');
        });
        //非焦点时的代码，忘记怎么写了
        $('#txtOrderSearch').unclick(function ()
        {
            $('#txtOrderSearch').val(initSearch);
        });
    });
</script>
<div class="header">全部订单</div>
<span style="float:right;">
    <asp:textbox runat="server" ID="txtOrderSearch" Text="商品名称、商品编号、订单编号" style="width:200px; color:#CCC;"></asp:textbox>
    <asp:button runat="server" text="查询" ID="btnSearch" onclick="btnSearch_Click" />
</span>
<asp:Repeater ID="Repeater1" runat="server" onitemdatabound="Repeater1_ItemDataBound">
    <HeaderTemplate>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="list">
        <tr align="center">
            <th width="45%">商品名称</th>
            <th>单价</th>
            <th>数量</th>
            <th width="100">创建日期</th>
            <th>订单状态</th>
            <th>操作</th>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td colspan="6" class="single" style="height:32px;">订单编号：<span style="color:#538dbd"><%#Eval("OrderCode") %></span></td>
        </tr>
            <asp:Repeater ID="Repeater2" runat="server">
            <ItemTemplate>
            <tr style="height:60px;" class="both" valign="top">
                <td>
                    <img src="<%#Eval("BaseProduct_Base.PicList").ToString().Trim(',').Split(',')[0]%>" alt="<%#Eval("ProductName")%>" style="width:52px; height:52px; padding:5px; border:1px solid #e6e6e6; float:left;" />
                    <a href="/CPXX/Category<%#Eval("BaseProduct_Base.ProductClassIDs").ToString().Trim(',').Split(',')[0] %>/Show<%#Eval("BaseProduct_Base.ID") %>" target="_blank" style="padding-left:70px;display: block;">
                        <%#Eval("ProductName")%>
                    </a>
                </td>
                <td align="center">￥<%#Eval("Price")%></td>
                <td align="center"><%#Eval("BuyCount")%></td>
                <td align="center"><%#Eval("BaseProduct_OrderBase.CreateTime")%></td>
                <td align="center"><%#GetState(Eval("BaseProduct_OrderBase.State"))%></td>
                <td align="center"><%#GetOptionLink(Eval("BaseProduct_OrderBase.State"), Eval("ID").ToString())%></td>
            </tr>
            </ItemTemplate>
            </asp:Repeater>
    </ItemTemplate>
    <FooterTemplate>
    </table>
    </FooterTemplate>
</asp:Repeater>
<webdiyer:AspNetPager ID="AspNetPager1" CssClass="page" runat="server" AlwaysShow="True" 
    CenterCurrentPageButton="True" NumericButtonCount="5" 
    CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页，每页%PageSize%条" 
    PageIndexBoxType="DropDownList" 
    PageSize="10" ShowCustomInfoSection="Right" 
    ShowPageIndexBox="Always" TextAfterPageIndexBox="页" 
    TextBeforePageIndexBox="转到" UrlPaging="True" 
    onpagechanged="AspNetPager1_PageChanged"
    UrlRewritePattern="/UserCenter/UserOrderInfo_{0}">
</webdiyer:AspNetPager>
</asp:Content>

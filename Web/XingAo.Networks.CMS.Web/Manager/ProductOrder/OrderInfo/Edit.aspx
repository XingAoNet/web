<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.ProductOrder.OrderInfo.Edit" %>
<%@ Import Namespace="XingAo.Core" %>
<script src="jquery.jqprint-0.3.js" type="text/javascript"></script>
<div class="pageContent">
	<form id="form1" runat="server" action="" class="pageForm required-validate" onsubmit="return validateCallback(this, navTabAjaxDone);">
		<div class="pageFormContent nowrap" layoutH="56">
			<asp:HiddenField ID="txtID" runat="server" />
            <fieldset>
            <legend>订单状态：</legend>
                <asp:literal runat="server" ID="litOrderState"></asp:literal>
            </fieldset>
            
            <fieldset>
            <legend>订单信息：</legend>
                <asp:repeater runat="server" ID="Rep_OrderBase">
                <ItemTemplate>
                <p>订单编号：<%#Eval("ordercode") %></p>
                <p>总金额：￥<%#Eval("TotalPrice")%></p>
                <p>折后价：<%#Eval("RebateTotalPrice")%></p>
                <p>下单时间：<%#Eval("createtime") %></p>
                <p>管理状态：<%#Eval("managerstate") %></p>
                </ItemTemplate>
                </asp:repeater>
            </fieldset>
            <fieldset>
            <legend>用户信息：</legend>
            <asp:repeater runat="server" ID="Rep_UserInfo">
                <ItemTemplate>
                <p>用户名：<a class="view" href="WebUsers/ViewUserInfo.aspx?id=<%#Eval("ID") %>" target="dialog" width="760" height="340" title="查看会员信息" rel="usermanager_view"><%#Eval("UserName")%></a></p>
                <p>姓名：<a class="view" href="WebUsers/ViewUserInfo.aspx?id=<%#Eval("ID") %>" target="dialog" width="760" height="340" title="查看会员信息" rel="usermanager_view"><%#Eval("RealName")%></a></p>
                <p>电话：<%#Eval("Mobile")%></p>
                <p>邮箱：<%#Eval("Email")%></p>
                <p>会员等级：<%#Eval("VipLevel")%></p>
                </ItemTemplate>
            </asp:repeater>
            </fieldset>
            <fieldset>
            <legend>订单明细：</legend>
            <table class="table" width="90%">
            <thead>
            <tr>
                <th>物品名称</th>
                <th width="150">获得积分数</th>
                <th width="80">数量</th>
                <th width="80">单价</th>
                <th width="150">小计</th>
            </tr>
            </thead>
            <tbody>
            <asp:repeater runat="server" ID="Rep_OrderInfo">
                <ItemTemplate>
                <tr>
                    <td><%#Eval("ProductName")%></td>
                    <td><%#Eval("BuyCount").ObjToInt() * Eval("ProductGetPoint").ObjToInt()%></td>
                    <td><%#Eval("BuyCount")%></td>
                    <td>￥<%#Eval("Price")%></td>
                    <td>￥<%#Eval("BuyCount").ObjToDecimal() * Eval("Price").ObjToDecimal()%></td>
                </tr>
                </ItemTemplate>
            </asp:repeater>
                <tr style=" background-color:Orange;">
                    <td style="padding-left:30px;">合计：</td>
                    <td><asp:literal runat="server" ID="TotelPoint"></asp:literal></td>
                    <td colspan="3" align="center">￥<asp:literal runat="server" ID="TotelPrice"></asp:literal></td>
                </tr>
            </tbody>
            </table>
            </fieldset>
            <fieldset>
            <legend>修改信息</legend>            
            <p><label>管理状态：</label><asp:dropdownlist runat="server" ID="txtManagerState" CssClass="combox"></asp:dropdownlist></p>
            <p><label>订单状态：</label><asp:dropdownlist runat="server" ID="txtState" CssClass="combox"></asp:dropdownlist></p>
            <p><label>实付总金额：</label><asp:textbox runat="server" ID="txtRebateTotalPrice"></asp:textbox></p>
            <p style="height:85px; width:90%;clear:both;"><label>实付金额备注：</label><asp:textbox runat="server" ID="txtRebateDescription" 
                    Height="80px" TextMode="MultiLine" Width="80%" ></asp:textbox></p>
            </fieldset>
			
		</div>
		<div class="formBar">
			<ul>
                <li>
                    <asp:panel runat="server" id="PrintBtn">
                        <div class="buttonActive"><a class="button" href="javascript:;"><span>打印订单</span></a></div>
                    </asp:panel>
                </li>
                <li>
                    <asp:panel runat="server" id="SaveBtn">
                        <div class="buttonActive"><div class="buttonContent"><button type="submit">保存</button></div></div>
                    </asp:panel>
                </li>
				<li>
					<div class="button"><div class="buttonContent"><button type="button" class="close">取消</button></div></div>
				</li>
			</ul>
		</div>
	</form>
</div>
<script type="text/javascript">
    $(".pageFormContent").jqprint(); 
</script>

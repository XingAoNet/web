<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/UcMaster.Master" AutoEventWireup="true" CodeBehind="UserPoint.aspx.cs" Inherits="XingAo.Networks.CMS.Web.UserCenter.UserPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="title" HeaderText="名称" />
        <asp:BoundField DataField="BeforePoint" HeaderText="操作前积分"></asp:BoundField>
        <asp:BoundField DataField="Point" HeaderText="本次增扣积分"></asp:BoundField>
        <asp:BoundField DataField="AfterPoint" HeaderText="操作后积分"></asp:BoundField>
        <asp:BoundField DataField="CreateTime" HeaderText="操作时间"></asp:BoundField>
        <asp:TemplateField HeaderText="审核">            
            <ItemTemplate>
                <%# Eval("IsPass").ToString()=="1"?"已审":"未审" %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Descriptions" HeaderText="备注"></asp:BoundField>
    </Columns>
    </asp:GridView>
    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" 
        CenterCurrentPageButton="True" 
        CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页，每页%PageSize%条" 
        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" NumericButtonCount="5" 
        onpagechanged="AspNetPager1_PageChanged" PageIndexBoxType="DropDownList" 
        PageSize="20" PrevPageText="上一页" ShowCustomInfoSection="Left" 
        ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" 
        TextBeforePageIndexBox="转到" UrlPaging="True" 
        UrlRewritePattern="/UserCenter/UserPoint_{0}">
    </webdiyer:AspNetPager>  
</asp:Content>

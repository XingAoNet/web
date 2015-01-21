<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/Share/Mobiles.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Mobile.ScratchCard._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contain" runat="server">
    <div id="header" class="bgcolor">
		<span class="title">刮刮卡活动</span>
	</div>


    <div id="mainmenu" class="fn-clear">
        <asp:Repeater ID="RegList" runat="server">
            <HeaderTemplate><ul></HeaderTemplate>
            <ItemTemplate>
                <li>
                    <a href="Card.aspx?openid=<%=Request.QueryString["openid"]%>&sguid=<%#Eval("SGuid")%>" style="text-decoration:none">
                        <p class="title"><%#Eval("Title")%></p>
                        <p class="summary"><%#Eval("IDateTime").ToString()%></p>
                        <img src="<%#Eval("PictureAddress") %>" alt="France" class="ui-li-heading"></img>
                        <div class="right-arrow"></div>
                    </a>
                </li>
            </ItemTemplate>
            <FooterTemplate></ul></FooterTemplate>
        </asp:Repeater>
    </div>    
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/UserCenter/UcMaster.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="XingAo.Networks.CMS.Web.UserCenter.UserInfo" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    用户信息：
        <asp:Repeater ID="Rep_UserInfo" runat="server">
        <ItemTemplate>
        用户名：<%#Eval("UserName")%><br />真实姓名：<%#Eval("RealName")%><br />积分：<%#Eval("Points")%><br />会员等级：<%#Eval("VipLevel")%><br />邮箱：<%#Eval("Email")%><br />手机：<%#Eval("Mobile")%>
        </ItemTemplate>
        </asp:Repeater>
        <br />
    修改密码：
     
        <br />
        旧密码：<asp:TextBox 
            ID="txtOldPwd" runat="server" TextMode="Password" 
            ValidationGroup="EditPwdGroup"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            Display="Dynamic" ErrorMessage="请输入旧密码" SetFocusOnError="True" 
            ValidationGroup="EditPwdGroup" ControlToValidate="txtOldPwd"></asp:RequiredFieldValidator>
        <br />
    新密码：<asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password" 
            ValidationGroup="EditPwdGroup"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            Display="Dynamic" ErrorMessage="请输入新密码" SetFocusOnError="True" 
            ValidationGroup="EditPwdGroup" ControlToValidate="txtNewPwd"></asp:RequiredFieldValidator>
        <br />
    确认密码：<asp:TextBox ID="txtConformPwd" runat="server" 
            TextMode="Password" ValidationGroup="EditPwdGroup"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToCompare="txtNewPwd" ControlToValidate="txtConformPwd" 
            Display="Dynamic" ErrorMessage="再次密码不一致" SetFocusOnError="True" 
            ValidationGroup="EditPwdGroup"></asp:CompareValidator>
        <asp:Button ID="Btn_UpdatePwd" runat="server" Text="修改密码" 
            onclick="Btn_UpdatePwd_Click" ValidationGroup="EditPwdGroup" />
    
</asp:Content>
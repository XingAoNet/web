<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reg.aspx.cs" Inherits="XingAo.Networks.CMS.Web.UserCenter.Reg" %>
<asp:literal runat="server" ID="Head"></asp:literal>
<script type="text/javascript">
    //验证表单

</script>
<div class="usercenter">
    <form id="form1" runat="server">
    <div class="container">
        <div class="header">
            <h3 class="logintext">注册</h3>
        </div>
        <div class="content">
            <span><label>* 用户名：</label><asp:TextBox ID="username" runat="server"></asp:TextBox></span>
            <span><label>* 密码：</label><asp:TextBox ID="pwd" runat="server" TextMode="Password"></asp:TextBox></span>
            <span><label>* 确认密码：</label><asp:TextBox ID="pwd2" runat="server" TextMode="Password"></asp:TextBox></span>
            <span><label>* 真实姓名：</label><asp:TextBox ID="realname" runat="server"></asp:TextBox></span>
            <span><label>* 邮箱：</label><asp:TextBox ID="email" runat="server"></asp:TextBox></span>
            <span><label>* 手机：</label><asp:TextBox ID="mobile" runat="server"></asp:TextBox></span>
            <span><label>&nbsp;</label><asp:Button ID="Button1" runat="server" Text="注册" onclick="Button1_Click" class="submit" /> 
                <asp:checkbox runat="server" ID="ReadReg"></asp:checkbox>我已阅读【注册协议】</span>
        </div>
    </div>
    </form>
</div>
<asp:literal runat="server" ID="Foot"></asp:literal>

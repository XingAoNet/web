<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tuisong.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Wechat.tuisong" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server" Text="XingAoNet"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" Text="xingao123"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="登录" onclick="Button1_Click" />
        <div>
        <table>
             <tr>
                <td>AccessToken：</td>
                <td><asp:TextBox ID="TxtAccessToken" runat="server" Text=""></asp:TextBox></td>
            </tr>
            <tr>
                <td>发送者：</td>
                <td><asp:TextBox ID="TextBox4" runat="server" Text=""></asp:TextBox></td>
            </tr>
            <tr>
                <td>接受者：</td>
                <td><asp:TextBox ID="TextBox5" runat="server" Text="2611039617"></asp:TextBox></td>
            </tr>
            <tr>
                <td>内容：</td>
                <td> <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Height="186px" 
                Width="450px"></asp:TextBox></td>
            </tr>
        </table>
            <asp:Button ID="Button2" runat="server" Text="发送" onclick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="get" onclick="Button3_Click" />
            <asp:TextBox ID="TextBox6" runat="server" Text=""></asp:TextBox><asp:Label ID="_lblMsg2" runat="server" Text="Label"></asp:Label>
        </div>

    </div>
    </form>
</body>
</html>

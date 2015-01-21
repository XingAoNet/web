<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RefreshToken.aspx.cs" Inherits="XingAo.Networks.CMS.TestDataShare.RefreshToken" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" action="http://localhost:19624/ShareData/refreshtoken">
    <div>
    AccessToken:
        <input id="AccessToken" name="AccessToken" type="text" />*<br />
        RefreshToken：<input id="RefreshToken" name="RefreshToken" type="text" />*
        <br />
        TimeSpan：<input id="TimeSpan" name="TimeSpan" type="text" readonly="readonly" />
        <br />
        Sign：<input id="Sign" name="Sign" type="text" readonly="readonly" />
        <br />
        重定向url（RedirectUrl）<input id="RedirectUrl" name="RedirectUrl" type="text" value="http://localhost:22713/ReceiveAccessToken.aspx" />(可选参数，如果此值不为空，则将服务器返回结果返回到此url的参数上，如果此值为空，则服务器只将返回结果输出到自己的页面上【注：所有方法都支持此参数，但是如果返回的数据较大时，建议不要使用此参数，因为url地址的长度可能会有限制】)<br />
        <input id="Submit1" type="button" value="submit" />
        </div>
    </form>
</body>
</html>
<script>
 $("#Submit1").click(
    function ()
    {

        $.get("Method/MD5.ashx?par0=RefreshToken&par1=" + $("#AccessToken").val() + "&rand=" + new Date(), function (data)
        {
            var TimeSpan = data.split("|")[1];
            var Sign = data.split("|")[0];
            $("#Sign").removeAttr("readonly").val(Sign);
            $("#TimeSpan").removeAttr("readonly").val(TimeSpan);
            $("#Submit1").attr({ "enabled": false, "value": "3秒后开始提交！" });
            setTimeout(function () { $("#form1").submit(); }, 3000);
        });
    });
    </script>
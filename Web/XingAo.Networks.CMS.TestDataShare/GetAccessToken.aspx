<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetAccessToken.aspx.cs" Inherits="XingAo.Networks.CMS.TestDataShare.GetAccessToken" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form action="http://localhost:19624/ShareData/GetToken" id="form1" name="form1" method="post">
    <div>
    取AccessToken：
     
        <br />
        用户名：<input id="UserName" name="UserName" type="text" value="XA" />*<br />
    key:<input id="Key" name="Key" type="text" value="Wv9m75N+lViwurP0IkktCrMLO+l1Hpt0EBTCBTbz0ZPFAD5nlgBlui8ccVgO8tKPAMk4kVpCRdVwl75n4U/0rQpmZj+QtvxZNAsSzr5ctZjEYBIpPoYgoztr9WfZ7Jk9mlx4OVm17qAng5txB7kKURGRilpHWT5iE+wmYRV1h8tzZXRyaCmFxL3bC1LY9knfisl40K4joPSXk339xJxXDiPyv/Nk+7VlXXOyCVoW+oAuVgHbfAQOpamBWt1b5Hke+J8Xv7fCdVguw8BZWlIlc3uMIVgAQ9TfskBJieXiNCNlSpkn9ZTo9s1QBfokXWrEg+Lwgtttydqn6rbARxdOMDKcJJhpIzkrubdooAmFK8jXukc61n78zj7U5hHGzb/zBJ0zOEbFKSvF9ZwViFVvTvIDUfMLbGCn7pejTDJ5OGgDhZnl0+sSJYRinHg2c8j+BnNEhQ0wm0LZy43QUjPdVMJuHDbDnga8M8SLMwsIHfEnw9P8qhU7O1qG7MZCBfY7p0Usjl1dhdL8v5LhXEdTxai4Te1rdcZk6zM4aaRksb451lcUQ0x3qJ3SmgsegJ9MoQhL2kLpfb8OpCJCrTanpRycdP/wotUs2r4j7q6BoK8KrLJdG08S/uWnSIelEk22dQRFzmMG1EA=" />*<br />
    AccessToken：<input id="AccessToken" name="AccessToken" type="text" readonly />（请求AccessToken时此值为空）<br />
    签名（sign）：<input id="sign" name="sign" type="text"  /><br />
    时间轴（TimeSpan）:<input id="timespan" name="timespan" type="text"  /><br />
    重定向url（RedirectUrl）<input id="RedirectUrl" name="RedirectUrl" type="text" value="http://localhost:22713/ReceiveAccessToken.aspx" />(可选参数，如果此值不为空，则将服务器返回结果返回到此url的参数上，如果此值为空，则服务器只将返回结果输出到自己的页面上【注：所有方法都支持此参数，但是如果返回的数据较大时，建议不要使用此参数，因为url地址的长度可能会有限制】)<br />
        <input id="Submit1" type="button" value="取AccessToken" />
    </div>
    </form>
    <div style="border:1px dashed #CCC; padding:15px; line-height:30px;">
第一步：
        使用管理分配的用户名以及key+签名与时间轴以post的方式请求到<a 
            href="http://www.xxx.com/ShareData/GetToken">http://www.xxx.com/ShareData/GetToken</a><br />
        1.签名sign的生成：要调用的方法名（此处为&quot;GetToken&quot;）+ 
        生成签名的时间刻度（TimeSpan） + 授权令牌AccessToken（因为此处本身就是请求取授权令牌，所以AccessToken为空）<br />
        2.将上面步骤1处生成 的字符串进行两次32位MD5加密便是签名值<br />
        3.时间轴的值不能与服务器产生的时间轴相差5秒以上或比服务器时间轴还快，否则直接拒绝请求【注意：此处时间轴并不是+8区时间轴，而是协调世界时UTC】</div>
</body>
</html>
<script type="text/javascript">
    $("#Submit1").click(
    function ()
    {
        var UserName = $("#UserName").val();
        var Key = $("#Key").val();
        var AccessToken = $("#AccessToken").val();
        var MethodName = "GetToken";

        $.get("Method/MD5.ashx?par0=" + MethodName + "&par1=" + AccessToken + "&rand=" + new Date(), function (data)
        {
            var TimeSpan = data.split("|")[1];
            var Sign = data.split("|")[0];
            $("#sign").removeAttr("readonly").val(Sign);
            $("#timespan").removeAttr("readonly").val(TimeSpan);
            $("#Submit1").attr({ "enabled": false, "value": "3秒后开始提交！" });
            setTimeout(function () { $("#form1").submit(); }, 3000);
        }, "text");
        return false;
    });
</script>
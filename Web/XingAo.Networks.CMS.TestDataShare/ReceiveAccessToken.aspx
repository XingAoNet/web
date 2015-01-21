<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiveAccessToken.aspx.cs" Inherits="XingAo.Networks.CMS.TestDataShare.ReceiveAccessToken" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
</head>
<body>
    
    
    <form id="form1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Visible="false">
    <div>
    调用方法：<asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <div id="pars" style="border:1px solid red;">
        
        </div>
    AccessToken：<input id="AccessToken" name="AccessToken" type="text" runat="server" readonly />*<br />
    签名（sign）：<input id="sign" name="sign" type="text"  />*<br />
    时间轴（TimeSpan）:<input id="timespan" name="timespan" type="text"  />*<br />
    重定向url（RedirectUrl）<input id="RedirectUrl" name="RedirectUrl" type="text" value="http://localhost:22713/ReceiveAccessToken.aspx" />(可选参数，如果此值不为空，则将服务器返回结果返回到此url的参数上，如果此值为空，则服务器只将返回结果输出到自己的页面上【注：所有方法都支持此参数，但是如果返回的数据较大时，建议不要使用此参数，因为url地址的长度可能会有限制】)<br />
    </div>
       <input id="Submit1" type="button" value="调用此方法" />
    </asp:Panel>
    </form>
    <div style="border:1px dashed #CCC; padding:15px; line-height:30px;">
第二步： 使用得到的授权令牌AccessToken来调用相关方法<br />
        1.选择要调用的方法（可能某些方法是带参数的，具体参数请查询后台相关设置）<br />
        2.签名sign的生成：要调用的方法名（此处为下拉框所选择的文本）+ 生成签名的时间刻度（TimeSpan） + 授权令牌AccessToken<br />
        3.将上面步骤1处生成 的字符串进行两次32位MD5加密便是签名值<br />
        4.时间轴的值不能与服务器产生的时间轴相差5秒以上或比服务器时间轴还快，否则直接拒绝请求【注意：此处时间轴并不是+8区时间轴，而是协调世界时UTC】<br />
        5.将表单内各参数以post方式发送到相应url上<br />
        【注意：一个授权令牌最长有效其为10分钟，所以客户端请求前最好先判断当前令牌是否还在有效期内。如果已失效，并且失效在5分钟以内的，允许通过“第一步”返回的RefreshToken来刷新授权令牌，5分钟以外的，只能重复“第一步”来取得新的授权信息，有关刷新令牌，请参考RefreshToken.aspx】</div>
</body>
</html>
<script type="text/javascript">
    $("#DropDownList1").change(function ()
    {
        if ($(this).val() != "")
        {
            $.get("Method/GetMethodPars.ashx?id=" + $(this).val()+"&r="+new Date(), function (data)
            {
                $("#pars").html(data);
            }, "text");
            $("#form1").attr("action", "http://localhost:19624/ShareData/" + $("#DropDownList1 option:selected").text());
        }
    });
    $("#Submit1").click(
    function ()
    {
        var UserName = $("#UserName").val();
        var Key = $("#Key").val();
        var AccessToken = $("#AccessToken").val();
        var MethodName = "GetToken";

        $.get("Method/MD5.ashx?par0=" + $("#DropDownList1 option:selected").text() + "&par1=" + $("#AccessToken").val() + "&rand=" + new Date(), function (data)
        {
            var TimeSpan = data.split("|")[1];
            var Sign = data.split("|")[0];
            $("#sign").removeAttr("readonly").val(Sign);
            $("#timespan").removeAttr("readonly").val(TimeSpan);
            $("#Submit1").attr({ "enabled": false, "value": "3秒后开始提交！" });
            setTimeout(function () { $("#form1").submit(); }, 3000);
        });
    });
</script>

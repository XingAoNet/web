<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonCheck.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Mobile.Persons.PersonCheck"  EnableViewState="false"%>

<!DOCTYPE html>  
<html>
<head>
    <title>基本资料</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
     <script type="text/javascript" src="/Scripts/jquery.js"></script>
    <link href="/Styles/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
 <div class="cardexplain">
    <ul class="round">
	    <li class="nob">
            <div class="kuang">
                联 系 人: <input class="px" name="txtName" maxlength="20" runat="server" id="txtName" value="" type="text"  placeholder="请输入帐号"  />
            </div>
	    </li>
        <li class="nob">
            <div class="kuang">
                手机号码: <input class="px" name="txtMobile" maxlength="20" runat="server" id="txtMobile" value="" type="text" placeholder="请输入手机号码" />
            </div>
	    </li>
        <li class="nob">
            <div class="kuang">
                联系地址: <input class="px" name="txtAddress" maxlength="100" runat="server" id="txtAddress" value="" type="text" placeholder="请输入联系地址" />
            </div>
	    </li>
        <li class="nob">
            <div class="kuang">
                邮　　箱: <input class="px" name="txtE_mail" maxlength="50" runat="server" id="txtE_mail" value="" type="text" placeholder="请输入邮箱" />
            </div>
	    </li>
    </ul>

    <div class="footReturn">
		<input type="button" id="LoginBtn" class="submit " value="提  交" />
		<div class="window hide" id="windowcenter" >
			<div id="title" class="wtitle">操作提示<span class="close" id="alertclose"></span></div>
			<div class="content">
				<div id="errInfo"></div>
			</div>
		</div>
	</div>

</div>
    <script type="text/javascript">
        function alertWindows(title)
        {
            $("#windowcenter").slideToggle("slow");
            $("#errInfo").html(title);
            setTimeout('$("#windowcenter").slideUp(500)', 4000);
        }
        $("#windowcenter").css({ "top": $("#LoginBtn").offset().top - 90 });
        function isMobil(s)
        {
            var patrn = /(^0{0,1}1[3|4|5|6|7|8|9][0-9]{9}$)/;
            if (!patrn.exec(s) || s.length != 11)
            {
                return false;
            }
            return true;
        }
        $("#LoginBtn").click(function (ex)
        {
            if ($("#txtName").val() == "")
            {
                alertWindows("帐号不能为空");
                return false;
            }
            if ($("#txtMobile").val() == "")
            {
                alertWindows("手机号码不能为空");
                return false;
            }
            if (!isMobil($("#txtMobile").val()))
            {
                alertWindows("请输入正确的手机号码！");
                return false;
            }
            $.post("CheckPerson.ashx", { action: "enroll", u: $("#txtName").val(), Mobile: $("#txtMobile").val(), address: $("#txtAddress").val(), email: $("#txtE_mail").val(), bguid: '<%=Request.QueryString["bguid"] %>', wxid: '<%=Request.QueryString["wxid"] %>', openid: '<%=Request.QueryString["openid"] %>' },
                    function (result)
                    {
                        if (result.code == 200)
                        {
                            alertWindows(result.msg);
                            window.parent.location.reload();
                        }
                        else
                            alertWindows(result.msg);
                    }, "json");
            return false;
        });
   </script>
</body>
</html>

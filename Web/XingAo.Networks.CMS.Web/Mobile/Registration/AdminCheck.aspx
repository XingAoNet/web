<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminCheck.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Mobile.Registration.AdminCheck"
    EnableViewState="false" %>

<!DOCTYPE html>  
<html>
<head>
    <title>管理员登录</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
     <script type="text/javascript" src="/Scripts/jquery.js"></script>
    <link href="/Styles/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
 <div class="cardexplain">
    <ul class="round">
	    <li class="nob">
            <div class="kuang">
                帐号: <input class="px" name="txtName" id="txtName" maxlength="20" value="" type="text"  placeholder="请输入帐号"  />
            </div>
	    </li>
        <li class="nob">
            <div class="kuang">
                密码: <input class="px" name="txtPassWord" id="txtPassWord" maxlength="20" value="" type="password" placeholder="请输入密码" />
            </div>
	    </li>
    </ul>

    <div class="footReturn">
		<input type="button" id="LoginBtn" class="submit " value="登 录" />
		<div class="window hide" id="windowcenter" >
			<div id="title" class="wtitle">操作提示<span class="close" id="alertclose"></span></div>
			<div class="content">
				<div id="errInfo"></div>
			</div>
		</div>
	</div>

</div>
    <script type="text/javascript">
        function alertWindow(title) {
            $("#windowcenter").slideToggle("slow");
            $("#errInfo").html(title);
            setTimeout('$("#windowcenter").slideUp(500)', 4000);
        }
        $("#windowcenter").css({ "top": $("#LoginBtn").offset().top - 90 });
        $("#LoginBtn").click(function (ex) {
            if ($("#txtName").val() == "") {
                alertWindow("帐号不能为空");
                return false;
            }
            if ($("#txtPassWord").val() == "") {
                alertWindow("密码不能为空");
                return false;
            }
            $.post("CheckSubmit.ashx", { action: "admin", u: $("#txtName").val(), pwd: $("#txtPassWord").val(), aguid: '<%=Request.QueryString["aguid"] %>' },
                    function (result) {
                        if (result.code == 200) {
                            alertWindow("登录成功");
                            window.parent.location.reload();
                        }
                        else
                            alertWindow(result.msg);

                    }, "json");
            return false;
        });
   </script>
</body>
</html>

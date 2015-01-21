<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>星奥管理平台</title>
<script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<style type="text/css">

html, body, div, span, applet, object, iframe,
h1, h2, h3, h4, h5, h6, p, blockquote, pre,
a, abbr, acronym, address, big, cite, code,
del, dfn, em, font, img, ins, kbd, q, s, samp,
small, strike, strong, sub, sup, tt, var,
dl, dt, dd, ol, ul, li,
fieldset, form, label, legend,
 caption { padding:0; margin:0; font-size:12px; line-height:100%; font-family:Arial, sans-serif;}

ul, ol { list-style:none;}
img { border:0;}

body { margin:0; text-align:center; background:#FFF url(themes/default/images/login_bg.png) repeat-x top;}

#login { display:block; width:950px; margin:0 auto; text-align:left;}
#login_header { display:block; padding-top:40px; height:80px;}
.login_logo { float:left; margin-top:10px;}
.login_info { float:left; margin-left:10px; line-height:80px; font-size:18px; color:#0088cc; font-weight: bold;}
.login_headerContent { float:right; display:block; width:280px; height:80px; padding:0 40px; background:url(themes/default/images/login_header_bg.png) no-repeat top right;}
.navList { display:block; overflow:hidden; height:20px; padding-left:28px;}
.navList ul { float:left; display:block; overflow:hidden;}
.navList li { float:left; display:block; margin-left:-1px; padding:0 10px; background:url(themes/default/images/login_list.png) no-repeat 0 5px;}
.navList a { display:block; white-space:nowrap; line-height:21px; color:#000; text-decoration:none;}
.navList a:hover { text-decoration:underline;}

#login_content { display:block; position:relative;}
.login_title { display:block; padding:25px 0 0 38px;}
.loginForm { display:block; width:240px; padding:40px 20px 0 20px; position:absolute; right:40px;}
.loginForm p { margin:10px 0;}
.loginForm label { float:left; width:70px; padding:0 0 0 10px; line-height:25px; color:#4c4c4c; font-size:14px;}
.loginForm input { padding:3px 2px; border-style:solid; border-width:1px; border-color:#80a5c4;}
.loginForm .login_input {}
.loginForm .code { float:left; margin-right:5px;}
.login_bar { padding-left:70px;}
.login_bar .sub { display:block; width:75px; height:30px; border:none; background:url(themes/default/images/login_sub.png) no-repeat; cursor:pointer;}

.login_banner { display:block; height:270px;}
.login_main { display:block; height:200px; padding-right:40px; background:url(themes/default/images/login_content_bg.png) no-repeat top;}

.helpList { float:right; width:200px;}
.helpList li { display:block; padding-left:10px; background:url(themes/default/images/login_list.png) no-repeat 0 -40px;}
.helpList a { line-height:21px; color:#333; text-decoration:none; }
.helpList a:hover { text-decoration:underline;}

.login_inner { display:block; width:560px; padding:30px 20px 0 20px;}
.login_inner p { margin:10px 0; line-height:150%; font-size:14px; color:#666;}

#login_footer { clear:both; display:block; margin-bottom:20px; padding:10px; border-top:solid 1px #e2e5e8; color:#666; text-align:center;}
</style>
</head>

<body>
	<div id="login">
		<div id="login_header">
			<h1 class="login_logo">
				<a href="http://www.xing-ao.net" target="_blank"><img src="themes/default/images/login_logo.jpg" /></a>
			</h1>
			<div class="login_headerContent">
				<div class="navList">
					<%--<ul>
						<li><a href="#">设为首页</a></li>
						<li><a href="http://www.xing-ao.net">反馈</a></li>
						<li><a href="doc/dwz-user-guide.pdf" target="_blank">帮助</a></li>
					</ul>--%>
				</div>
				<h2 class="login_title"><img src="themes/default/images/login_title.jpg" /></h2>
			</div>
		</div>
		<div id="login_content">
			<div class="loginForm" style="background-color:#FFF; height:260px;">
               <div class="err" style=" color:Red;"><asp:Literal ID="LiInfpo" runat="server"></asp:Literal></div>
				<form runat="server">
					
					<table border="0" align="center" cellpadding="3" cellspacing="2">
					  <tr>
					    <td height="23" align="right">用户名：</td>
					    <td colspan="2"><input type="text" name="username"  size="20" maxlength="30" class="login_input" style="width:143px; height:16px;"  /></td>
				      </tr>
					  <tr>
					    <td height="23" align="right">密　码：</td>
					    <td colspan="2"><input type="password" name="password"  maxlength="30" class="login_input" style="width:143px; height:16px;" /></td>
				      </tr>
					  <tr>
					    <td height="23" align="right">验证码：</td>
					    <td colspan="2"><table border="0" cellspacing="0" cellpadding="0">
					      <tr>
					        <td><input class="code" name="code" type="text" size="6" maxlength="5" style="width:83px; height:16px;"/></td>
					        <td><img alt="" id="ImgCheck" align="absmiddle" src="/Verification"  onclick="this.src='/Verification?r='+new Date()" /></td>
				          </tr>
					      </table></td>
				      </tr>
					  <tr>
					    <td height="23" align="right">&nbsp;</td>
					    <td><span class="login_bar" style="width:75px; margin:auto; padding:0; padding-left:-10px;">
					      <asp:Button ID="BtnLogin" runat="server" Text="" CssClass="sub" 
                            OnClick="BtnLogin_Click" />                          
					    </span></td>
					    <td>&nbsp;</td>
				      </tr>
			      </table>	
			  </form>
			</div>
			<div class="login_banner">
            <a href="#" target="_blank"><img src="themes/default/images/login_banner1.jpg" /></a>
            <a href="#" target="_blank"><img src="themes/default/images/login_banner2.jpg" /></a>
            <a href="#" target="_blank"><img src="themes/default/images/login_banner3.jpg" /></a>
            </div>
			<div class="login_main">
				<%--<ul class="helpList">
					<li><a href="#">忘记密码怎么办？</a></li>
					<li><a href="#">为什么登录失败？</a></li>
				</ul>--%>
				<div class="login_inner">
<%--					<h1 style="margin:0; padding:0; font-size:16px">公司现有研发产品：</h1> 
                    <div style="height:130px; width:595px; overflow:auto;line-height:22px;">
                  1.<strong>星奥内容管理系统（CMS）</strong>：可用于新闻发布、公司公告、友情链接、浮动广告等功能，系统集成与电子商务商品展示、商品交易、订单结算。<br />
2.<strong>星奥电子商务在线交易系统（ESHOP）</strong>：分为平台版、企业版、个人版三个版本。在线交易系统提供商品展示、交易、订单的处理。 <br />
3.<strong>星奥分销系统</strong>：用于为客户提供分销商、代理商代理公司产品的系统，改系统分为单厂商系统和多厂商系统，单厂商系统对于代理商（分销商）只能使用某一个厂商的商品；多厂商系统可以集成多个厂商的产品。 <br />
4.<strong>星奥第三方结算平台集成系统</strong>：用于集成第三方，例如支付宝接口、财付通接口、盛付通接口、以及银联接口一系列结算平台接口。<br />
5.<strong>星奥进销存集成系统</strong>：用于集成第三方进销存系统；<br />
6.<strong>星奥ERP集成系统</strong>：用于集成第三方ERP系统； 
</div>
--%>			  </div>
			</div>
		</div>
		<div id="login_footer">
			Copyright &copy; 2012 - <%=DateTime.Now.Year.ToString()%> 
            <a href="http://www.xing-ao.net" target="_black" style="text-decoration:none; color:#666;">台州星奥网络科技有限公司</a> 版权所有
		</div>
	</div>
</body>
</html>
<script type="text/javascript">
    var imgIndex = 0;
	var count=$(".login_banner a").length;
	$(".login_banner a").eq(0).show().siblings().hide();
    setInterval(function ()
    {       
        $(".login_banner a").eq(imgIndex).show().siblings().hide();
		 imgIndex++;
        if (imgIndex >= count)
            imgIndex = 0;
	},
    3000);
</script>
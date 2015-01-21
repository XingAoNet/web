<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Manager.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=7" />
<meta http-equiv="X-UA-Compatible" content="IE=8" />
<title>星奥电子商务管理平台 -- 以科技服务企业，以创新改变世界</title>
<%--UI and Js v1.4.6--%>

<link href="themes/default/style.css" rel="stylesheet" type="text/css" media="screen"/>
<link href="themes/css/core.css" rel="stylesheet" type="text/css" media="screen"/>
<link href="themes/css/print.css" rel="stylesheet" type="text/css" media="print"/>    
<link href="/Manager/Wechat/Styles/Site.css" rel="stylesheet" type="text/css" />
<link href="/Manager/Wechat/Styles/imgareaselect-default.css" rel="stylesheet" type="text/css" />
<%--<!--jquery 上传插件样式-->
<link href="uploadify/css/uploadify.css" rel="stylesheet" type="text/css" media="screen"/>--%>


<!--[if IE]>
<link href="themes/css/ieHack.css" rel="stylesheet" type="text/css" media="screen"/>
<![endif]-->

<!--[if lte IE 9]>
<script src="js/speedup.js" type="text/javascript"></script>
<![endif]-->

<script src="js/jquery-1.7.2.js" type="text/javascript"></script>
<script src="js/jquery.cookie.js" type="text/javascript"></script>
<script src="js/jquery.validate.js" type="text/javascript"></script>
<script src="js/jquery.bgiframe.js" type="text/javascript"></script>
<%--
<!--JUI自带编辑器-->
<script src="xheditor/xheditor-1.2.1.min.js" type="text/javascript"></script>
<script src="xheditor/xheditor_lang/zh-cn.js" type="text/javascript"></script>--%>
<link rel="Stylesheet" href="kindeditor417/themes/default/default.css">
<script charset="utf-8" src="kindeditor417/kindeditor.js"></script>
<script charset="utf-8" src="kindeditor417/lang/zh_CN.js"></script>


<%--
<!--jquery 上传插件-->
<script src="uploadify/scripts/jquery.uploadify.js" type="text/javascript"></script>
--%>

<%--<!-- svg图表  supports Firefox 3.0+, Safari 3.0+, Chrome 5.0+, Opera 9.5+ and Internet Explorer 6.0+ -->
<script type="text/javascript" src="chart/raphael.js"></script>
<script type="text/javascript" src="chart/g.raphael.js"></script>
<script type="text/javascript" src="chart/g.bar.js"></script>
<script type="text/javascript" src="chart/g.line.js"></script>
<script type="text/javascript" src="chart/g.pie.js"></script>
<script type="text/javascript" src="chart/g.dot.js"></script>--%>

<script src="js/dwz.core.js" type="text/javascript"></script>
<script src="js/dwz.util.date.js" type="text/javascript"></script>
<script src="js/dwz.validate.method.js" type="text/javascript"></script>
<script src="js/dwz.regional.zh.js" type="text/javascript"></script>
<script src="js/dwz.barDrag.js" type="text/javascript"></script>
<script src="js/dwz.drag.js" type="text/javascript"></script>
<script src="js/dwz.tree.js" type="text/javascript"></script>
<script src="js/dwz.accordion.js" type="text/javascript"></script>
<script src="js/dwz.ui.js" type="text/javascript"></script>
<script src="js/dwz.theme.js" type="text/javascript"></script>
<script src="js/dwz.switchEnv.js" type="text/javascript"></script>
<script src="js/dwz.alertMsg.js" type="text/javascript"></script>
<script src="js/dwz.contextmenu.js" type="text/javascript"></script>
<script src="js/dwz.navTab.js" type="text/javascript"></script>
<script src="js/dwz.tab.js" type="text/javascript"></script>
<script src="js/dwz.resize.js" type="text/javascript"></script>
<script src="js/dwz.dialog.js" type="text/javascript"></script>
<script src="js/dwz.dialogDrag.js" type="text/javascript"></script>
<script src="js/dwz.sortDrag.js" type="text/javascript"></script>
<script src="js/dwz.cssTable.js" type="text/javascript"></script>
<script src="js/dwz.stable.js" type="text/javascript"></script>
<script src="js/dwz.taskBar.js" type="text/javascript"></script>
<script src="js/dwz.ajax.js" type="text/javascript"></script>
<script src="js/dwz.pagination.js" type="text/javascript"></script>
<script src="js/dwz.database.js" type="text/javascript"></script>
<script src="js/dwz.datepicker.js" type="text/javascript"></script>
<script src="js/dwz.effects.js" type="text/javascript"></script>
<script src="js/dwz.panel.js" type="text/javascript"></script>
<script src="js/dwz.checkbox.js" type="text/javascript"></script>
<script src="js/dwz.history.js" type="text/javascript"></script>
<script src="js/dwz.combox.js" type="text/javascript"></script>
<script src="js/dwz.print.js" type="text/javascript"></script>    
<!--ccj:当网络不好时，加载该API会导致后台无法进入，需改进-->
<%--<script src="http://api.map.baidu.com/api?v=1.2" type="text/javascript"></script>--%>
<script src="/Manager/Wechat/Scripts/jquery.imgareaselect.pack.js" type="text/javascript"></script>
<script src="/Manager/Wechat/Scripts/UrlCopy.js" type="text/javascript"></script>
<script src="/Manager/Wechat/Scripts/jquery.zclip.js" type="text/javascript"></script>
<script src="js/dwz.regional.zh.js" type="text/javascript"></script>

<script type="text/javascript">
    $(function ()
    {
        DWZ.init("dwz.frag.xml", {
            loginUrl: "login_dialog.aspx", loginTitle: "登录", // 弹出登录对话框
            //		loginUrl:"login.html",	// 跳到登录页面
            statusCode: { ok: 200, error: 300, timeout: 301 }, //【可选】
            pageInfo: { pageNum: "pageNum", numPerPage: "numPerPage", orderField: "orderField", orderDirection: "orderDirection" }, //【可选】
            debug: false, // 调试模式 【true|false】
            callback: function ()
            {
                initEnv();
                $("#themeList").theme({ themeBase: "themes" }); // themeBase 相对于index页面的主题base路径
            }
        });
    });
</script>
</head>
<body scroll="no">
	<div id="layout">
		<div id="header">
			<div class="headerNav">
                <div id="navMenu">
				    <ul>
                        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
				    </ul>
			    </div>
				<ul class="nav">	
                    <li >
                        <asp:Literal ID="UserName" runat="server"></asp:Literal></li>				
					<li><a href="changepwd.aspx" target="dialog" max=false mask=true maxable=false minable=false resizable=false drawable=true width="370" height="190">修改密码</a></li>
					<li><a href="logout.ashx">退出</a></li>
				</ul>
				<%--<ul class="themeList" id="themeList">
					<li theme="default"><div class="selected">蓝色</div></li>
					<li theme="green"><div>绿色</div></li>
					<!--<li theme="red"><div>红色</div></li>-->
					<li theme="purple"><div>紫色</div></li>
					<li theme="silver"><div>银色</div></li>
					<li theme="azure"><div>天蓝</div></li>
				</ul>--%>
			</div>

			<!-- navMenu -->
			
		</div>

		<div id="leftside">
			<div id="sidebar_s">
				<div class="collapse">
					<div class="toggleCollapse"><div></div></div>
				</div>
			</div>
			<div id="sidebar">
				<div class="toggleCollapse"><h2>主菜单</h2><div>收缩</div></div>
				<div class="accordion" fillSpace="sidebar">
                    
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
				</div>
			</div>
		</div>


		<div id="container">
			<div id="navTab" class="tabsPage">
				<div class="tabsPageHeader">
					<div class="tabsPageHeaderContent"><%-- 显示左右控制时添加 class="tabsPageHeaderMargin" --%>
						<ul class="navTab-tab">
							<li tabid="main" class="main"><a href="javascript:;"><span><span class="home_icon">我的主页</span></span></a></li>
						</ul>
					</div>
					<div class="tabsLeft">left</div><%-- 禁用只需要添加一个样式 class="tabsLeft tabsLeftDisabled" --%>
					<div class="tabsRight">right</div><%-- 禁用只需要添加一个样式 class="tabsRight tabsRightDisabled" --%>
					<div class="tabsMore">more</div>
				</div>
				<ul class="tabsMoreList">
					<li><a href="javascript:;">我的主页</a></li>
				</ul>
				<div class="navTab-panel tabsPageContent layoutBox">
					<div class="page unitBox">
						<div class="accountInfo">
							<div class="alertInfo">
                                <p><strong>技术支持</strong> 地址：浙江省台州市路桥区会展中心二楼<br />
                                电话：0576-82923030  传真：0576-82923030.811</p>
							</div>
							<div class="right">
<%--<p><a href="doc/dwz-user-guide.zip" target="_blank" style="line-height:19px">DWZ框架使用手册(CHM)</a></p>
								<p><a href="doc/dwz-ajax-develop.swf" target="_blank" style="line-height:19px">DWZ框架Ajax开发视频教材</a></p>--%>
							</div>
							<p><strong>业务体系：</strong>门户网站平台、电子商务平台、实验室管理平台、危险品工业气体信息化方案</p>
						</div>
						<div class="pageFormContent" layoutH="80" style="margin-right:230px">
						  <div>
						    <div style="line-height:150%">
					        </div>
					      </div>
						</div>
						
						<div style="width:230px;position: absolute;top:60px;right:0; height:490px; overflow:hidden;" layoutH="80">
							<iframe width="100%" height="490" class="share_self"  frameborder="0" scrolling="no" id="ADFrame" src="CustomerService.htm"></iframe>
						</div>
					</div>
					
				</div>
			</div>
		</div>

	</div>
	<div id="footer">Copyright &copy; 2012-<%=DateTime.Now.Year.ToString() %> <a href="http://www.xing-ao.net" target="blank">台州星奥网络科技有限公司</a> 版权所有</div>
    <script type="text/javascript">
        $(".menu span").click(function () {
            var ss = $(this).parent().attr("att");
            window.location.href = ss;
        });
        $("#header .nav li").mousemove(function () {
            $("#header .nav ul").css({ display: "inline" });
        });
        $("#header .nav li").mouseout(function () {
            $("#header .nav ul").css({ display: "none" });
        });        
    </script>
</body>
</html>

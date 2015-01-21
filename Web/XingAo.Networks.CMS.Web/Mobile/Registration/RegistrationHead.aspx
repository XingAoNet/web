<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationHead.aspx.cs"
    Inherits="XingAo.Networks.CMS.Web.Mobile.Registration.RegistrationHead" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title><%=title%></title>
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1.0,user-scalable=no;" />  
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <script type="text/javascript" src="/Scripts/jquery.js"></script>
     <link href="/Styles/WebSite/comm.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/css.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/thickbox.js" type="text/javascript"></script>
    <script src="/Scripts/Mobile/menu.js" type="text/javascript"></script>
    <script src="/Scripts/Mobile/WebSite.js" type="text/javascript"></script>
</head>
<body>
   <% if (HasErr)
       { %>
    <div id="header" class="bgcolor">
        <a id="return" class="left" href="javascript:history.go(-1);"></a>
		<span class="title"><%=title%></span>
	</div>
    <div style="display:none;" class="webAbstract"><%=Abstract%></div>
    <div class="cardexplain">
        <ul class="round">
		    <li>
			    <div class="text"><%=title%></div>
		    </li>
	    </ul>
    </div>

    <div class="cardexplain">
        <ul class="round">
		    <li>
			    <div class="text"><asp:Literal ID="LiCreateTime" runat="server"></asp:Literal></div>
		    </li>
            <li><div class="text"><asp:Literal ID="LiState" runat="server"></asp:Literal></div></li>
	    </ul>
    </div>

    <div class="cardexplain">
        <ul class="round">
		    <li>
			    <h2>活动描述</h2>
			    <div class="text">
                <%=Abstract%>
                
                </div>
		    </li>
	    </ul>
    </div>

    <div class="cardexplain">
        <ul class="round">
		    <li>
			    <div class="text"><%=detailedcontent%></div>
		    </li>
	    </ul>
    </div>

    <div class="cardexplain enroll" runat="server" id="PostFrom">
          <div class="window hide" id="windowcenter" >
			    <div id="title" class="wtitle">操作提示<span class="close" id="alertclose"></span></div>
			    <div class="content">
				    <div id="errInfo">人数不能为空</div>
			    </div>
		    </div>
         <ul class="round">
			<li class="title mb"><span class="none">请认真填写表单</span></li>
			<li class="nob">
                <div class="kuang">
                    <span>联系人:</span><input name="txtName" type="text" class="px" id="txtName" value="" placeholder="请输入您的真实姓名" />
                </div>
		    </li>
            <li class="nob">
                <div class="kuang">
                    <span>手机:</span> <input class="px"  name="txtMoblie" id="txtMoblie"  maxlength="20" value="" type="text" placeholder="请输入您联系手机号码"  />
                </div>
		    </li>
            <asp:Repeater ID="RpList" runat="server">
                <ItemTemplate>
                     <li class="nob">
                        <div class="kuang">
                            <span><%#Container.DataItem%>:</span><input type='text' class='px' name='percontent' maxlength="100" value='' placeholder="<%#Container.DataItem%>"  />
                        </div>
		            </li>
                </ItemTemplate>
             </asp:Repeater>
	    </ul>

        <div class="footReturn">
             <input type="button" id="postSubmit" class="submit " value="提 交" />
	    </div>

        <script type="text/javascript">
             function alertWindow(title) {
                 $("#windowcenter").slideToggle("slow");
                 $("#errInfo").html(title);
                 setTimeout('$("#windowcenter").slideUp(500)', 3000);
             }
             imgLoader = new Image();
             function isMobil(s)
             {
                 var patrn = /(^0{0,1}1[3|4|5|6|7|8|9][0-9]{9}$)/;
                 if (!patrn.exec(s) || s.length != 11)
                 {
                     return false;
                 }
                 return true;
             }
             $("#postSubmit").click(function (ex) {
                
                 if ($("#txtName").val() == "") {
                     alertWindow("帐号不能为空");
                     return false;
                 }
                 if ($("#txtMoblie").val() == "") {
                     alertWindow("手机号码不能为空");
                     return false;
                 }
                 if (!isMobil($("#txtMoblie").val()))
                 {
                     alertWindow("手机号码不正确");
                     return false;
                 }
               
                 var percontent = "";
                 $("input[name='percontent']").each(function (ex) {
                     var v = $(this).val();
                     percontent += v == "" ? "未填," : $(this).val().replace(",", "，") + ",";
                 });
                 imgLoader.src = "/Images/loadingAnimation.gif"
                 tb_show();

                 $.post("CheckSubmit.ashx", { action: "enroll", u: $("#txtName").val(), Moblie: $("#txtMoblie").val(), aguid: '<%=Request.QueryString["aguid"] %>', openid: '<%=Request.QueryString["openid"] %>', percontent: percontent },
                    function (result) {
                        tb_remove();
                        $(".ui-loader").hide();
                        if (result.code == 200) {
                            alertWindow("报名成功");
                            $(".enrollList table tr:first").after(result.msg);
                            $("div.enroll input").val("");
                        }
                        else
                        {
                            alertWindow(result.msg);
                        }

                    }, "json");

             });
        </script>
    </div>
    
    <div class="cardexplain">
        <ul class="round">
            <li class="title mb"><span class="none">报名人数</span><a href="AdminCheck.aspx?AGuid=<%=aguid %>&TB_iframe=true&height=150&width=260&inlineId=myOnPageContent" title="登录" class="thickbox">管理员</a></li>
		    <li>
			    <div class="enrollList kuang"></div>
		    </li>
	    </ul>
    </div>
              <%
       }
       else
       {%>
       <div class="cardexplain">
            <ul class="round">
                <li><div class="text">您访问的活动已关闭！</div></li>
	        </ul>
        </div>
       <%} %>
     <wmf:MobileFoot runat="server" ></wmf:MobileFoot>
     <mh:MobileHelp runat="server" ID="MobileHelp1"></mh:MobileHelp>

    </body>
</html>

 <script type="text/javascript">
     $(function (ex) {
         $.post("/Mobile/Registration/EnrollList.aspx", { action: "enroll", AGuid: '<%=aguid %>' }, function (result) { $("div.enrollList").html(result); }, "html");

     });
</script>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BigWheel.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Mobile.BigWheels.BigWheel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1.0,user-scalable=no;" />
    <script type="text/javascript" src="/Scripts/jquery.js"></script>
    <link href="/Styles/css.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/thickbox.js" type="text/javascript"></script>
    <script src="/Scripts/Mobile/Turntable.js" type="text/javascript"></script>
<%--    <link href="/Styles/WebSite/comm.css" rel="stylesheet" type="text/css" />--%>
    <script src="/Scripts/Mobile/WebSite.js" type="text/javascript"></script>
    <style type="text/css">
        .Setting {text-decoration: none;float: right;position: absolute;right: 0px;top: 0px;width: 45px;height: 100%;background: url("/images/icon-setting.png") no-repeat 6px 5px;background-color: rgba(0, 0, 0, 0.2);}
        .kuang{margin-bottom: 6px;}
        .nob .px{border-radius: 5px;-webkit-border-radius: 5px;-moz-border-radius: 5px;background-color: #FFF;border: 1px solid #E8E8E8;margin: 5px 0 4px;padding: 5px 10px;}
        #registration{z-index:902;top:40px;}
        #windowcenter{z-index:9999;top:80px;}
    </style>
</head>
<body>
   <% if (HasErr)
       { %>
    <div id="header" class="bgcolor">
        <a id="return" class="left" href="javascript:history.go(-1);"></a>
        <span class="title"><%=title%></span>
        <span class="Setting thickbox" title="基本信息"></span>
    </div>
    <div class="cardexplain">
        <ul class="round">
            <li>
                <div id="bigwheel" style="width: 310px; margin: 0 auto; margin-top: 5px; margin-bottom: 5px;">
                </div>
            </li>
        </ul>
    </div>
    <div class="cardexplain enroll" id="reg">
        <div class="footReturn">
            <div class="cardexplain window hide nob" id="registration">
                <div class="wtitle">
                    基本信息<span class="close" id="clickclose"></span></div>
                    <input runat="server" ID="txtID" type="hidden" value="" />
                <div class="kuang ">
                     联 系 人 ：
                    <input class="px" name="txtName" maxlength="20" runat="server" id="txtName" value=""
                        type="text" placeholder="请输入帐号" />
                </div>
                <div class="kuang">
                    手机号码：
                    <input class="px" name="txtMobile" maxlength="20" runat="server" id="txtMobile" value=""
                        type="text" placeholder="请输入手机号码" />
                </div>
                <div class="kuang">
                    联系地址：
                    <input class="px" name="txtAddress" maxlength="100" runat="server" id="txtAddress"
                        value="" type="text" placeholder="请输入联系地址" />
                </div>
                <div class="kuang">
                    邮　　箱：
                    <input class="px" name="txtE_mail" maxlength="50" runat="server" id="txtE_mail" value=""
                        type="text" placeholder="请输入邮箱" />
                </div>
                <div class="footReturn">
                    <input type="button" id="LoginBtn" class="submit " value="提  交" />
                </div>
            </div>
        </div>
    </div>
    <div class="cardexplain enroll" runat="server" id="PostFrom">
        <div class="footReturn">
            <div class="window hide" id="windowcenter">
                <div id="title" class="wtitle">
                    操作提示<span class="close" id="alertclose"></span></div>
                <div class="content">
                    <div id="errInfo">不能为空</div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
    var ishas="<%=IsHasPerson %>";
    var txtid=$("#txtID").val();
    var err="<%=err%>";
    var context="<%=context%>";//错误信息
        var spinwheel = $("#bigwheel").sTurntable({
              width: 290,
              height: 290,
              CurRound: <%=CurRound %>,
              maxRound: <%=maxRound %>,
              Restaraunts: "<%=jiangping%>".split(','),  //奖品数据
              checkCall: function ()
              {
                  if(err=="True")
                  {                 
                      alertWindow("<%=context%>");
                      return false;
                  }
                   else if (ishas == "True")
                  {
                      $(".thickbox").click();
                      return false;
                  }
                  else 
                  {
                      return true;
                  }
              },
              CallBack: function (ex)
              {
                  $.post("PostBigWheel.ashx", { action: "LuckDraw", u: '<%=name %>', bguid: '<%=Request.QueryString["BGuid"] %>', openid: '<%=Request.QueryString["openid"] %>', prize: ex, wguid: '<%=Request.QueryString["wxid"]%>' },
                    function (result)
                    {
                        tb_remove();
                        $(".ui-loader").hide();
                        if (result.code == 200) {
                             alertWindow("恭喜您！获得"+ex);
                             $("#bwprise").after("<tr><td>"+ex+" </td><td>"+result.Other+"</td></tr>");
                        }
                        else
                        {
                            alertWindow(result.msg);
                        }
                    }, "json");
              }
          });

        $(".Setting").click(function ()
        {
            openDiv();
            $("#registration").slideToggle("slow");
        });
//        function openDiv()  
//        {  
//            var newMaskID = "mask";  //遮罩层id  
//            var newMaskWidth =document.body.scrollWidth;//遮罩层宽度  
//            var newMaskHeight =document.body.scrollHeight;//遮罩层高度      
//            //mask遮罩层    
//            var newMask = document.createElement("div");//创建遮罩层  
//            newMask.id = newMaskID;//设置遮罩层id  
//            newMask.style.position = "absolute";//遮罩层位置  
//            newMask.style.zIndex = "901";//遮罩层zIndex  
//            newMask.style.width = newMaskWidth + "px";//设置遮罩层宽度  
//            newMask.style.height = newMaskHeight + "px";//设置遮罩层高度  
//            newMask.style.top = "0px";//设置遮罩层于上边距离  
//            newMask.style.left = "0px";//设置遮罩层左边距离  
//            newMask.style.background = "#000";//#33393C//遮罩层背景色  
//            newMask.style.filter = "alpha(opacity=50)";//遮罩层透明度IE  
//            newMask.style.opacity = "0.50";//遮罩层透明度FF  
//            document.body.appendChild(newMask);//遮罩层添加到DOM中
//        }  
        $("#clickclose").click(function(){
            $("#registration").slideUp(500,function(){
                $("#mask").remove();
            });           
        });
        $("#registration").css({ "top": $("#reg").offset().top - 300 });
       
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
                alertWindow("姓名不能为空");
                return false;
            }
            if ($("#txtMobile").val() == "")
            {
                alertWindow("手机号码不能为空");
                return false;
            }
            if (!isMobil($("#txtMobile").val()))
            {
                alertWindow("请输入正确的手机号码！");
                return false;
            }
            $.post("/Mobile/Persons/CheckPerson.ashx", { action: "enroll", u: $("#txtName").val(), Mobile: $("#txtMobile").val(), address: $("#txtAddress").val(), email: $("#txtE_mail").val(), bguid: '<%=Request.QueryString["bguid"] %>', wxid: '<%=Request.QueryString["wxid"] %>', openid: '<%=Request.QueryString["openid"] %>' },
                function (result)
                {                
                    if (result.code == 200)
                    {
                        alertWindow(result.msg);
                        if(txtid == "")
                        {
                            if(result.Other=="")
                            {
                                $("#registration").slideUp(500,function(){$("#mask").remove();});   
                                setTimeout("spinwheel.data(\"_Turntable\").spin()",6000);
                                txtid+="1";
                                ishas+="1";
                            }
                            else
                            {
                                err="false";
                                context=result.Other;
                                alertWindow(result.Other);
                                setTimeout("window.parent.location.reload()",2000);
                            }
                        }
                        else
                        {
                            window.parent.location.reload();
                        }
                    }
                    else
                        alertWindow(result.msg);
                }, "json");
            return false;
        });
        function alertWindow(title)
        {
            $("#windowcenter").slideToggle("slow");
            $("#errInfo").html(title);
            setTimeout('$("#windowcenter").slideUp(500)', 4000);
        }
        $("#windowcenter").css({ "top": $("#PostFrom").offset().top - 180 });
    </script>    
    <div class="cardexplain">
        <ul class="round">
            <li>
                <h2>
                    <%=title%></h2>
            </li>
        </ul>
    </div>
    <div style="display:none;" class="webAbstract"><%=Abstract%></div>
    <div class="cardexplain">
        <ul class="round">
            <li>
                <h2>
                    活动时间</h2>
                <div class="text">
                    <asp:Literal ID="LiCreateTime" runat="server"></asp:Literal></div>
                    <div class="text">
                    <%=context%></div>
            </li>
        </ul>
    </div>
    <div class="cardexplain">
        <ul class="round">
            <li>
                <div class="text">
                    <%=detailedcontent%></div>
            </li>
        </ul>
    </div>
    <div class="cardexplain">
        <ul class="round">
            <li>
                <table cellpadding="0" cellspacing="1">
                    <tr id="bwprise">
                        <td style="width: 100px;">
                            奖品
                        </td>
                        <td style="width: 150px;">
                            时间
                        </td>
                    </tr>
                    <asp:Repeater runat="server" ID="RpList">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%#Eval("Prize")%>
                                </td>
                                <td>
                                    <%#Eval("IDateTime","{0:yyyy-MM-dd HH:mm:ss}")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
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
     <wmf:MobileFoot ID="MobileFoot1" runat="server" ></wmf:MobileFoot>
     <mh:MobileHelp runat="server" ID="MobileHelp1"></mh:MobileHelp>
</body>
</html>

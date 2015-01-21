<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/Share/Mobiles.Master" AutoEventWireup="true" CodeBehind="Card.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Mobile.ScratchCard.Card" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/wScratchPad.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contain" runat="server">
    <style type="text/css">
        .Setting {text-decoration: none;float: right;position: absolute;right: 0px;top: 0px;width: 45px;height: 100%;background: url("/images/icon-setting.png") no-repeat 6px 5px;background-color: rgba(0, 0, 0, 0.2);}
        .kuang{margin-bottom: 6px;}
        .nob .px{border-radius: 5px;-webkit-border-radius: 5px;-moz-border-radius: 5px;background-color: #FFF;border: 1px solid #E8E8E8;margin: 5px 0 4px;padding: 5px 10px;}
        #registration{z-index:9998;top:40px;}
        #windowcenter{z-index:9999;top:80px;}
    </style>
    <div id="header" class="bgcolor">
        <a id="return" class="left" href="javascript:history.go(-1);"></a>
		<span class="title">刮刮卡活动</span>
        <span class="Setting thickbox" title="基本信息"></span>
	</div>
     <div class="cardexplain">
        <ul class="round">
            <li>
               <div style=" max-width:640px; margin: 0 auto; margin-top: 5px; margin-bottom: 5px; position:relative;" >
                    <img src="<%=Background%>" id="CardImg" style=" max-width:640px;width:100%" alt="" />
                   <div id="wScratchPad3" style="position:absolute;"></div>
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
                    <input class="px txtName" maxlength="20" runat="server" id="txtName" value=""
                        type="text" placeholder="请输入帐号" />
                </div>
                <div class="kuang">
                    手机号码：
                    <input class="px txtMobile" maxlength="20" runat="server" id="txtMobile" value=""
                        type="text" placeholder="请输入手机号码" />
                </div>
                <div class="kuang">
                    联系地址：
                    <input class="px txtAddress" maxlength="100" runat="server" id="txtAddress"
                        value="" type="text" placeholder="请输入联系地址" />
                </div>
                <div class="kuang">
                    邮　　箱：
                    <input class="px txtE_mail" maxlength="50" runat="server" id="txtE_mail" value="" type="text" placeholder="请输入邮箱" />
                </div>
                <div class="footReturn">
                    <input type="button" id="LoginBtn" class="submit " value="提  交" />
                </div>
            </div>
        </div>
         <div class="window hide" id="windowcenter">
                <div id="title" class="wtitle">
                    操作提示<span class="close" id="alertclose"></span></div>
                <div class="content">
                    <div id="errInfo">不能为空</div>
                </div>
            </div>
    </div>
     <div class="cardexplain">
        <ul class="round">
            <li>
                <h2>
                    <%=title%></h2>
            </li>
        </ul>
    </div>


      <div class="cardexplain">
        <ul class="round">
            <li>
                <h2>活动时间</h2>
                <div class="text">
                    <asp:Literal ID="LiCreateTime" runat="server"></asp:Literal></div>
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
    <div style="display:none;" class="webAbstract"><%=Abstract%></div>
     <div class="cardexplain">
        <ul class="round">
            <li>
                <table cellpadding="0" cellspacing="1">
                    <tr id="bwprise">
                        <td style="width: 100px;">
                            奖品
                        </td>
                        <td style="width: 150px;">
                            数量
                        </td>
                    </tr>
                    <asp:Repeater runat="server" ID="RpList">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%#Eval("GoodsName")%>
                                </td>
                                <td>
                                    <%#Eval("GoodsCount")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </li>
        </ul>
    </div>


    <script type="text/javascript">
    <%if (isInfoNo){ %>
        setTimeout("openDivs()",200);
        setTimeout("$('#registration').slideToggle('slow')",200);
      <%} %>

        $(".Setting").click(function ()
        {
            openDivs();
            $("#registration").slideToggle("slow");
        });
        function openDivs()  
        {  
            var newMaskID = "masks";  //遮罩层id  
            var newMaskWidth =document.body.scrollWidth;//遮罩层宽度  
            var newMaskHeight =document.body.scrollHeight;//遮罩层高度      
            //mask遮罩层    
            var newMask = document.createElement("div");//创建遮罩层  
            newMask.id = newMaskID;//设置遮罩层id  
            newMask.style.position = "absolute";//遮罩层位置  
            newMask.style.zIndex = "902";//遮罩层zIndex  
            newMask.style.width = newMaskWidth + "px";//设置遮罩层宽度  
            newMask.style.height = newMaskHeight + "px";//设置遮罩层高度  
            newMask.style.top = "0px";//设置遮罩层于上边距离  
            newMask.style.left = "0px";//设置遮罩层左边距离  
            newMask.style.background = "#000";//#33393C//遮罩层背景色  
            newMask.style.filter = "alpha(opacity=50)";//遮罩层透明度IE  
            newMask.style.opacity = "0.50";//遮罩层透明度FF  
            document.body.appendChild(newMask);//遮罩层添加到DOM中
        }  
       $("#clickclose").click(function(){
            $("#registration").slideUp(500,function(){
                $("#masks").remove();
            });           
        });
        $("#LoginBtn").click(function (ex)
        {
            var name=$("input.txtName").val();
            var Mobile=$("input.txtMobile").val();
            var E_mail=$("input.txtE_mail").val();
            var Address=$("input.txtAddress").val();

            if (name == "")
            {
                alertWindow("姓名不能为空");
                return false;
            }
            
            if (Mobile == "")
            {
                alertWindow("手机号码不能为空");
                return false;
            }
            
            if (!isMobil(Mobile))
            {
                alertWindow("请输入正确的手机号码！");
                return false;
            }
            $.post("/Mobile/Persons/CheckPerson.ashx", { action: "enroll", u:name, Mobile: Mobile, address: Address, email: E_mail, bguid: '', wxid: '<%=Request.QueryString["wxid"] %>', openid: '<%=Request.QueryString["openid"] %>' },
                function (result)
                {               
                    if (result.code == 200)
                    {
                        alertWindow(result.msg);
                       window.parent.location.reload();
                    }
                    else
                        alertWindow(result.msg);
                }, "json");
            return false;
        });

        function isMobil(s)
        {
            var patrn = /(^0{0,1}1[3|4|5|6|7|8|9][0-9]{9}$)/;
            if (!patrn.exec(s) || s.length != 11)
            {
                return false;
            }
            return true;
        }

        function alertWindow(title)
        {
            $("#windowcenter").slideToggle("slow");
            $("#errInfo").html(title);
            setTimeout('$("#windowcenter").slideUp(500)', 4000);
        }
        var imgWidth=0,imgHeight=0,canvasTop=0,canvasLeft=0,bl=1,goodUrl,nowWidth=0;
        $("#CardImg").load(function(){
        nowWidth=$(this).width();
            bl=$(this).width()/640;
            imgWidth=<%=ImgWidth%>*bl;
            imgHeight=<%=ImgHeight%>*bl;
            canvasTop=<%=CanvasTop %>*bl;
            canvasLeft=<%=CanvasLeft %>*bl; 
            goodUrl="<%=GoodUrl %>"+ "&h=" + imgHeight + "&w=" + imgWidth;
        });
        $(window).resize(function () {
            if(nowWidth!=$("#CardImg").width())
                window.location.reload();
        });
        setTimeout("$('#wScratchPad3').css({ 'top': canvasTop+'px', 'left': canvasLeft+'px' })",400 );
        setTimeout("$('#wScratchPad3').wScratchPad({cursor: null,size: 20,width: imgWidth,height: imgHeight ,BackGroundImg: goodUrl,IsfillStyle:<%=isFx.ToString().ToLower() %>,scratchMove: function (e, percent) { }})",500 );

</script>

</asp:Content>

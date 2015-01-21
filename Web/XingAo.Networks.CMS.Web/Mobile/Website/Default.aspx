<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Mobile.Website.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title> </title>
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1.0,user-scalable=no;"/> 
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <link href="/Styles/WebSite/comm.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/index.css" rel="stylesheet" type="text/css" />  
    <script src="/Scripts/swipeslide/zepto.min.js" type="text/javascript"></script>
    <script src="/Scripts/swipeslide/swipeslide.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/Scripts/swipeslide/swipeslide.css" />
     <script src="/Scripts/Mobile/menu.js" type="text/javascript"></script>
    <script src="/Scripts/Mobile/WebSite.js" type="text/javascript"></script>
    
       
    <style type="text/css">
        .sortDrag{cursor: pointer;width: 50%;}
        body {max-width: 640px;margin: auto;min-height: 100%;}
        .headList{border:0px solid #B8D0D6;cursor:pointer; margin-top:10px;margin-bottom:10px; }
        .headList div{text-align:center;font-weight:900;}
        #sortDragDiv{width:98%; margin: auto;}
        .swipe{overflow:hidden;visibility:hidden;position:relative;width:100%;}
        .swipe-wrap{overflow:hidden;width:100%;position:relative;}
        .swipe-wrap>div{width:100%;height:100%;float:left;position:relative;}
        #image img{width:100%;border:0;margin:0;padding:0;}
        #image .swipe-item a{display:block;height:100%;width:100%;}
        #image .swipe-item .bottom{z-index:1;position:absolute;bottom:0;padding:0;height:30px;line-height:30px;display:block;left:0;text-align:center;background:rgba(0,0,0,0.5);text-align:left;width:100%;}
        #image .swipe-item .bottom .title{color:#FFF;margin-left:6px;}
        #image .dots{z-index:10;position:absolute;bottom:0;padding:0;height:30px;line-height:30px;display:block;left:0;text-align:right;}
        #image .dots b{display:inline-block;margin:12px 4px;width:6px;height:6px;border-radius:3px;background:rgba(144,144,144,0.8);}
        #image .dots .select{background:#fff;}
    </style>
</head>
<body>
<div id="image" class="swipe" style="visibility: visible;">
    <div class="swipe-wrap" data-id="0">
             <asp:Repeater runat="server" ID="RegList">
                <ItemTemplate>
                     <div class="swipe-item">
                        <a href="javascript:;">  
                            <img src="<%#Eval("PictureAddress") %>" class="img">
                        </a>
                        <div class="bottom"><div class="title"><%#Eval("Describe")%></div></div>
                     </div> 	
                </ItemTemplate>
            </asp:Repeater>
        </div>
</div>
    <div class="box" style="width:100%;margin: auto 0;"> 
        <div id="sortDragDiv" class="cardexplain">
            <div class="sortDrag" style="float:left;"></div>
            <div class="sortDrag" style="float:right;"></div>
            <div style="clear: both;"></div>
        </div>
    </div>
    <script type="text/javascript">
     $(document).ready(function () {
            $('#image').swipeSlide({autoPlay:3,delay:0.4});
        })

        var EditJson = <%=headjsons%>;
      
        for (i = 0; i < EditJson.length; i++)
        {
            var typeandcount = EditJson[i].ID.split("_");
           
           SetItem(typeandcount[0], parseInt(typeandcount[1]), EditJson[i].InsortDragDivIndex,  EditJson[i].Config); 
            
        }

		function SetItem(modeltype, Count, AddtoDivIndex,configJson)
		{
            var url="#";//链接地址为空时，使用默认生成的地址
            var backpic="";//div背景图片
            var backcolor="";//div‘headList’背景色
            var title="";//题目
         
            if(configJson!=undefined)
            {
               
                configJson.txtUrl=getUrl(configJson,"<%=wxid%>");
                

                url=configJson.Url;  
                if(configJson.Url=="")
                    url=configJson.txtUrl;

                if(configJson.BackPic=="")
                    backpic="/Images/Website/DefaultIcons.png";//默认图片
                else
                    backpic=configJson.BackPic;  
                if(configJson.BackColor!="")
                    backcolor = configJson.BackColor;
                if(configJson.Title!=""&&configJson.showTitle==1)
                    title=configJson.Title;
            }
		    $(".sortDrag").eq(AddtoDivIndex).append('<div class="headList" style="background:\''+backcolor +'\'";" onclick="location.href=\''+url+'\';" ><div><img src="'+backpic+'" style="width:98%;"/></div><div class="txttitle">' + title + '</div></div>');
           
       }
        
       $("body").css({"background-image":"url(<%=backurl %>)" });
       var semode = "<%=selectmode %>";
       var leftWid = "49%";
       var rightWid = "49%";
       if(semode=="2")
       {
            leftWid = "28%";
            rightWid = "68%";
       }
       if (semode == "3")
       {
           leftWid = "69%";
           rightWid = "27%";
       }
       if (semode == "4")
       {
           leftWid = "100%";
           rightWid = "100%";
           $(".headList").css({"margin":"0px"});
           $(".headList img").css({"width":"100%"}); 
       }
       $(".sortDrag").eq(0).css("width", leftWid);
       $(".sortDrag").eq(1).css("width", rightWid);
    </script>
    <wmf:MobileFoot runat="server" ></wmf:MobileFoot>
    <mh:MobileHelp runat="server" ID="MobileHelp1"></mh:MobileHelp>
</body>
</html>


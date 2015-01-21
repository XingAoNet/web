	//var ConfigJson_=[{"CloseLeft":"-98px","Left":"1px","OpenTitlePic":"/images/AdTitle_{1}.gif","ClosePic":"/images/AdClose_{1}.gif","CloseShowPic":"/images/AdSmall_{1}.gif","Bottom":"30px"}];    
    var ConfigJson_635185750862031250=[{"CloseLeft":"-98px",
"Left":"1px",
"Bottom":"30px",
"OpenTitlePic":"/upload/image/20130920/20130920091704_5156.png",
"ClosePic":"/upload/image/20130920/20130920110014_3593.jpg",
"CloseShowPic":"/upload/image/20131019/20131019092407_8437.jpg"
}]; 
    var html_635185750862031250='<div id="ChatDiv_635185750862031250" style="position: fixed;bottom: '+ConfigJson_635185750862031250[0].Bottom+';left: '+ConfigJson_635185750862031250[0].Left+';z-index: 9999999;">\n';
	html_635185750862031250+='<table border="0" cellspacing="0" cellpadding="0">\n';
	html_635185750862031250+='<tr>\n';
	html_635185750862031250+='<td><img src="'+ConfigJson_635185750862031250[0].OpenTitlePic+'" alt="" /></td>\n';
	html_635185750862031250+='<td ><img src="'+ConfigJson_635185750862031250[0].ClosePic+'" alt="" id="closeChat_635185750862031250" style="cursor:pointer" /></td>\n';
	html_635185750862031250+='</tr>\n';
	html_635185750862031250+='<tr>\n';
	html_635185750862031250+='<td colspan="2">111111111111111</td>\n';
	html_635185750862031250+='</tr>\n';
	html_635185750862031250+='</table> \n';
	html_635185750862031250+='<table border="0" cellspacing="0" cellpadding="0" style="display:none">\n';
	html_635185750862031250+='<tr>\n';
	html_635185750862031250+='<td><img src="'+ConfigJson_635185750862031250[0].CloseShowPic+'" alt="" id="openChat_635185750862031250" /></td>\n';
	html_635185750862031250+='</tr>\n';
	html_635185750862031250+='</table>\n';
	html_635185750862031250+='</div>';
	$(html_635185750862031250).appendTo($("body"));
	var Chattop_635185750862031250=$("#ChatDiv_635185750862031250").offset().top;
$("#closeChat_635185750862031250").click(
function()
{
	$("#ChatDiv_635185750862031250").animate({left:ConfigJson_635185750862031250[0].CloseLeft},300,function()
	{
		$("#ChatDiv_635185750862031250 table:first").hide().siblings().show();
		$("#ChatDiv_635185750862031250").animate({left:ConfigJson_635185750862031250[0].Left},300);
	})
	
});
$("#openChat_635185750862031250").click(
function()
{	
	$("#ChatDiv_635185750862031250").animate({left:ConfigJson_635185750862031250[0].CloseLeft},300,function()
	{
		$("#ChatDiv_635185750862031250 table").eq(1).hide().siblings().show();
		$("#ChatDiv_635185750862031250").animate({left:ConfigJson_635185750862031250[0].Left},300);
	})
	
});
var scrolltop_635185750862031250;
var timeout_635185750862031250;
if($.browser.msie&&($.browser.version == "6.0")&&!$.support.style)//ie6
{
	$(window).scroll(function() 
	{
		scrolltop_635185750862031250=$(this).scrollTop()+ Chattop_635185750862031250;
		if(timeout_635185750862031250!=undefined)
			clearTimeout(timeout_635185750862031250);
		timeout_635185750862031250=setTimeout("SetTop_635185750862031250()",500);
	});
}
function SetTop_635185750862031250()
{
	$("#ChatDiv_635185750862031250").animate({top:scrolltop_635185750862031250},700);
}
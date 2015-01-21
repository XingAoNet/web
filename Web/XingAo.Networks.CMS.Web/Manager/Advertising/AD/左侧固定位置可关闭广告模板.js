	//var ConfigJson_=[｛"CloseLeft":"-98px","Left":"1px","OpenTitlePic":"/images/AdTitle_｛1｝.gif","ClosePic":"/images/AdClose_｛1｝.gif","CloseShowPic":"/images/AdSmall_｛1｝.gif","Bottom":"30px"｝];    
    var ConfigJson_{1}={2}; 
    var html_{1}='<div id="ChatDiv_{1}" style="position: fixed;bottom: '+ConfigJson_{1}[0].Bottom+';left: '+ConfigJson_{1}[0].Left+';z-index: 9999999;">\n';
	html_{1}+='<table border="0" cellspacing="0" cellpadding="0">\n';
	html_{1}+='<tr>\n';
	html_{1}+='<td><img src="'+ConfigJson_{1}[0].OpenTitlePic+'" alt="" /></td>\n';
	html_{1}+='<td ><img src="'+ConfigJson_{1}[0].ClosePic+'" alt="" id="closeChat_{1}" style="cursor:pointer" /></td>\n';
	html_{1}+='</tr>\n';
	html_{1}+='<tr>\n';
	html_{1}+='<td colspan="2">{0}</td>\n';
	html_{1}+='</tr>\n';
	html_{1}+='</table> \n';
	html_{1}+='<table border="0" cellspacing="0" cellpadding="0" style="display:none">\n';
	html_{1}+='<tr>\n';
	html_{1}+='<td><img src="'+ConfigJson_{1}[0].CloseShowPic+'" alt="" id="openChat_{1}" /></td>\n';
	html_{1}+='</tr>\n';
	html_{1}+='</table>\n';
	html_{1}+='</div>';
	$(html_{1}).appendTo($("body"));
	var Chattop_{1}=$("#ChatDiv_{1}").offset().top;
$("#closeChat_{1}").click(
function()
｛
	$("#ChatDiv_{1}").animate(｛left:ConfigJson_{1}[0].CloseLeft｝,300,function()
	｛
		$("#ChatDiv_{1} table:first").hide().siblings().show();
		$("#ChatDiv_{1}").animate(｛left:ConfigJson_{1}[0].Left｝,300);
	｝)
	
｝);
$("#openChat_{1}").click(
function()
｛	
	$("#ChatDiv_{1}").animate(｛left:ConfigJson_{1}[0].CloseLeft｝,300,function()
	｛
		$("#ChatDiv_{1} table").eq(1).hide().siblings().show();
		$("#ChatDiv_{1}").animate(｛left:ConfigJson_{1}[0].Left｝,300);
	｝)
	
｝);
var scrolltop_{1};
var timeout_{1};
if($.browser.msie&&($.browser.version == "6.0")&&!$.support.style)//ie6
｛
	$(window).scroll(function() 
	｛
		scrolltop_{1}=$(this).scrollTop()+ Chattop_{1};
		if(timeout_{1}!=undefined)
			clearTimeout(timeout_{1});
		timeout_{1}=setTimeout("SetTop_{1}()",500);
	｝);
｝
function SetTop_{1}()
｛
	$("#ChatDiv_{1}").animate(｛top:scrolltop_{1}｝,700);
｝
(function(){
        var onBridgeReady = function () {
			var appId  = "",	//$('#txt-wx').data('appid'),
				link   = window.location,	//$('#txt-wx').data('link'),htmlDecode($('title').text())
				title  = titles==undefined?"asdf":titles ,	// htmlDecode($('#txt-wx').data('title')),
				desc = titles == undefined ? "asdf" : titles + "£¨æ¥«Î∑√Œ £°", //<br/>πŸÕ¯µÿ÷∑£∫" + window.location.href),	// htmlDecode($('#txt-wx').data('desc')),
				fakeid = "MTA0NjEwNDk0Mw==",
				desc = desc || link,
				imgUrl = "";
			
			var image = $.trim($('link[data-logo]').attr('href'));	//$('#txt-wx').data('img')
			if (image=='' || image==undefined) {
				image = $.trim($('img[data-share-logo]').attr('src'));
			}
			if (image=='' || image==undefined) {
				image = $.trim($('img:first').attr('src'));
			}
			if (image!='' && image!=undefined) {
				imgUrl = "http://" + window.location.host + image;
			}
			
			if ("1" == "0") {
				WeixinJSBridge.call("hideOptionMenu");
			}
			
			jQuery("#post-user").click(function(){
				WeixinJSBridge.invoke('profile',{'username':'gh_0752b2eb5b99','scene':'57'});
			});
			
			// ∑¢ÀÕ∏¯∫√”—;
			WeixinJSBridge.on('menu:share:appmessage', function(argv){
				WeixinJSBridge.invoke('sendAppMessage',{
					"appid"      : appId,
					"img_url"    : imgUrl,
					"img_width"  : "640",
					"img_height" : "640",
					"link"       : window.location.href,
					"desc"       : desc,
					"title"      : title
				},
				function(res) {
				});
			});
			
			// ∑÷œÌµΩ≈Û”—»¶;
			WeixinJSBridge.on('menu:share:timeline', function(argv){
				WeixinJSBridge.invoke('shareTimeline',{
					"img_url"    : imgUrl,
					"img_width"  : "640",
					"img_height" : "640",
					"link"       : window.location.href,
					"desc"       : desc,
					"title"      : title
				}, function(res) {
				});
			});
			
			// ∑÷œÌµΩŒ¢≤©;
			var weiboContent = '';
			WeixinJSBridge.on('menu:share:weibo', function(argv){
				WeixinJSBridge.invoke('shareWeibo',{
					"content" : title + window.location.href,
					"url"     : window.location.href
				},
				function(res) {
				});
			});
		};

        if(document.addEventListener){
			document.addEventListener('WeixinJSBridgeReady', onBridgeReady, false);
		} else if(document.attachEvent){
			document.attachEvent('WeixinJSBridgeReady'   , onBridgeReady);
			document.attachEvent('onWeixinJSBridgeReady' , onBridgeReady);
		}
})();
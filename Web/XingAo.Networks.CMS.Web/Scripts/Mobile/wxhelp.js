(function ()
{
    var onBridgeReady = function ()
    {
        var appId = "",
			link = window.location,
			title = $(".webtitle").html() == undefined ? (document.title == undefined ? "" : document.title) : (document.title == undefined ? "" : document.title + "-" + $(".webtitle").html()),
			desc = $(".webAbstract").html() == undefined ? (document.title == undefined ? "" : document.title + "，敬请访问！") : $(".webAbstract").html(),
			fakeid = "MTA0NjEwNDk0Mw==",
			desc = desc || link,
			imgUrl = "";
        var image;
        try
        {
            image = $.trim($('link[data-logo]').attr('href')); //$('#txt-wx').data('img')

            if (image == undefined || image == '')
            {
                image = $.trim($('img[data-share-logo]').attr('src'));
            }
            if (image == undefined || image == '')
            {
                image = $.trim($('img:first').attr('src'));
            }

            if (image == undefined || image == '')
            {
                imgUrl = "http://" + window.location.host + image;
            }
        }
        catch (e)
         { }
        if ("1" == "0")
        {
            WeixinJSBridge.call("hideOptionMenu");
        }
        // 发送给好友;
        WeixinJSBridge.on('menu:share:appmessage', function (argv)
        {
            WeixinJSBridge.invoke('sendAppMessage', {
                "appid": appId,
                "img_url": imgUrl,
                "img_width": "640",
                "img_height": "640",
                "link": window.location.href,
                "desc": desc,
                "title": title
            },
				function (res)
				{
				});
        });
        // 分享到朋友圈;
        WeixinJSBridge.on('menu:share:timeline', function (argv)
        {
            WeixinJSBridge.invoke('shareTimeline', {
                "img_url": imgUrl,
                "img_width": "640",
                "img_height": "640",
                "link": window.location.href,
                "desc": desc,
                "title": title
            }, function (res)
            {
            });
        });
        // 分享到微博;
        var weiboContent = '';
        WeixinJSBridge.on('menu:share:weibo', function (argv)
        {
            WeixinJSBridge.invoke('shareWeibo', {
                "content": title + window.location.href,
                "url": window.location.href
            },
				function (res)
				{
				});
        });
    };

    if (document.addEventListener)
    {
        document.addEventListener('WeixinJSBridgeReady', onBridgeReady, false);
    } else if (document.attachEvent)
    {
        document.attachEvent('WeixinJSBridgeReady', onBridgeReady);
        document.attachEvent('onWeixinJSBridgeReady', onBridgeReady);
    }
})();
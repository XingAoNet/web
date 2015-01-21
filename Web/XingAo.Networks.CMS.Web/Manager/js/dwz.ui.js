function initEnv() 
{
	$("body").append(DWZ.frag["dwzFrag"]);

	if ( $.browser.msie && /6.0/.test(navigator.userAgent) ) {
		try {
			document.execCommand("BackgroundImageCache", false, true);
		}catch(e){}
	}
	//清理浏览器内存,只对IE起效
	if ($.browser.msie) {
		window.setInterval("CollectGarbage();", 10000);
	}

	$(window).resize(function(){
		initLayout();
		$(this).trigger(DWZ.eventType.resizeGrid);
	});

	var ajaxbg = $("#background,#progressBar");
	ajaxbg.hide();
	$(document).ajaxStart(function(){
		ajaxbg.show();
	}).ajaxStop(function(){
		ajaxbg.hide();
	});
	
	$("#leftside").jBar({minW:150, maxW:700});
	
	if ($.taskBar) $.taskBar.init();
	navTab.init();
	if ($.fn.switchEnv) $("#switchEnvBox").switchEnv();
	if ($.fn.navMenu) $("#navMenu").navMenu();
		
	setTimeout(function(){
		initLayout();
		initUI();
		
		// navTab styles
		var jTabsPH = $("div.tabsPageHeader");
		jTabsPH.find(".tabsLeft").hoverClass("tabsLeftHover");
		jTabsPH.find(".tabsRight").hoverClass("tabsRightHover");
		jTabsPH.find(".tabsMore").hoverClass("tabsMoreHover");
	
	}, 10);

}
function initLayout()
{
	var iContentW = $(window).width() - (DWZ.ui.sbar ? $("#sidebar").width() + 10 : 34) - 5;
	var iContentH = $(window).height() - $("#header").height() - 34;
	$("#container").width(iContentW);
	$("#container .tabsPageContent").height(iContentH - 34).find("[layoutH]").layoutH();
	$("#sidebar, #sidebar_s .collapse, #splitBar, #splitBarProxy").height(iContentH - 5);
	$("#taskbar").css({top: iContentH + $("#header").height() + 5, width:$(window).width()});
}

function initUI(_box)
{
    var $p = $(_box || document);

    $("div.panel", $p).jPanel();

    //tables
    $("table.table", $p).jTable();

    // css tables
    $('table.list', $p).cssTable();

    //auto bind tabs
    $("div.tabs", $p).each(function ()
    {
        var $this = $(this);
        var options = {};
        options.currentIndex = $this.attr("currentIndex") || 0;
        options.eventType = $this.attr("eventType") || "click";
        $this.tabs(options);
    });

    $("ul.tree", $p).jTree();
    $('div.accordion', $p).each(function ()
    {
        var $this = $(this);
        $this.accordion({ fillSpace: $this.attr("fillSpace"), alwaysOpen: true, active: 0 });
    });

    $(":button.checkboxCtrl, :checkbox.checkboxCtrl", $p).checkboxCtrl($p);

    if ($.fn.combox) $("select.combox", $p).combox();
    //2013年9月12日 09:44:46 注册掉自带编辑改用其它编辑器	
    //	if ($.fn.xheditor) {
    //		$("textarea.editor", $p).each(function(){
    //			var $this = $(this);
    //			var op = {html5Upload:false, skin: 'vista',tools: $this.attr("tools") || 'full'};
    //			var upAttrs = [
    //				["upLinkUrl","upLinkExt","zip,rar,txt"],
    //				["upImgUrl","upImgExt","jpg,jpeg,gif,png"],
    //				["upFlashUrl","upFlashExt","swf"],
    //				["upMediaUrl","upMediaExt","avi"]
    //			];
    //			
    //			$(upAttrs).each(function(i){
    //				var urlAttr = upAttrs[i][0];
    //				var extAttr = upAttrs[i][1];
    //				
    //				if ($this.attr(urlAttr)) {
    //					op[urlAttr] = $this.attr(urlAttr);
    //					op[extAttr] = $this.attr(extAttr) || upAttrs[i][2];
    //				}
    //			});
    //			
    //			$this.xheditor(op);
    //		});
    //	}
    if ($("textarea.editor", $p).length > 0)
    {
        $("textarea.editor", $p).each(function (i, n)
        {
            var editor = KindEditor.create($(n),
            {
                resizeType: 2,
                uploadJson: 'kindeditor417/DotNet/upload_json.ashx',
                fileManagerJson: 'kindeditor417/DotNet/file_manager_json.ashx',
                allowFileManager: true,
                afterBlur: function () { editor.sync(); }
            });
            /*2013年10月30日 09:00:11 卢小阳 注释以下代码，因为编辑器创建时改用afterBlur: function () { editor.sync();}代码来同步内容（焦点离开编辑器就同步），所以不需要此处点击“保存”按钮时才同步编辑器的内容*/
            //            $(".buttonActive button[type='submit']").click(
            //            function ()
            //            {
            //                editor.sync();
            //            });
        });
    }

    if ($.fn.uploadify)
    {
        $(":file[uploaderOption]", $p).each(function ()
        {
            var $this = $(this);
            var options = {
                fileObjName: $this.attr("name") || "file",
                auto: true,
                multi: true,
                onUploadError: uploadifyError
            };

            var uploaderOption = DWZ.jsonEval($this.attr("uploaderOption"));
            $.extend(options, uploaderOption);

            DWZ.debug("uploaderOption: " + DWZ.obj2str(uploaderOption));

            $this.uploadify(options);
        });
    }

    // init styles
    $("input[type=text], input[type=password], textarea", $p).addClass("textInput").focusClass("focus");

    $("input[readonly], textarea[readonly]", $p).addClass("readonly");
    $("input[disabled=true], textarea[disabled=true]", $p).addClass("disabled");

    $("input[type=text]", $p).not("div.tabs input[type=text]", $p).filter("[alt]").inputAlert();

    //Grid ToolBar
    $("div.panelBar li, div.panelBar", $p).hoverClass("hover");

    //Button
    $("div.button", $p).hoverClass("buttonHover");
    $("div.buttonActive", $p).hoverClass("buttonActiveHover");

    //tabsPageHeader
    $("div.tabsHeader li, div.tabsPageHeader li, div.accordionHeader, div.accordion", $p).hoverClass("hover");

    //validate form
    $("form.required-validate", $p).each(function ()
    {
        var $form = $(this);
        $form.validate({
            onsubmit: false,
            focusInvalid: false,
            focusCleanup: true,
            errorElement: "span",
            ignore: ".ignore",
            invalidHandler: function (form, validator)
            {
                var errors = validator.numberOfInvalids();
                if (errors)
                {
                    var message = DWZ.msg("validateFormError", [errors]);
                    alertMsg.error(message);
                }
            }
        });

        $form.find('input[customvalid]').each(function ()
        {
            var $input = $(this);
            $input.rules("add", {
                customvalid: $input.attr("customvalid")
            })
        });
    });

    if ($.fn.datepicker)
    {
        $('input.date', $p).each(function ()
        {
            var $this = $(this);
            var opts = {};
            if ($this.attr("dateFmt")) opts.pattern = $this.attr("dateFmt");
            if ($this.attr("minDate")) opts.minDate = $this.attr("minDate");
            if ($this.attr("maxDate")) opts.maxDate = $this.attr("maxDate");
            if ($this.attr("mmStep")) opts.mmStep = $this.attr("mmStep");
            if ($this.attr("ssStep")) opts.ssStep = $this.attr("ssStep");
            $this.datepicker(opts);
        });
    }

    // navTab
    $("a[target=navTab]", $p).each(function ()
    {
        $(this).click(function (event)
        {
            var $this = $(this);
            var title = $this.attr("title") || $this.text();
            var tabid = $this.attr("rel") || "_blank";
            var fresh = eval($this.attr("fresh") || "true");
            var external = eval($this.attr("external") || "false");
            var url = unescape($this.attr("href")).replaceTmById($(event.target).parents(".unitBox:first"));
            DWZ.debug(url);
            if (!url.isFinishedTm())
            {
                alertMsg.error($this.attr("warn") || DWZ.msg("alertSelectMsg"));
                return false;
            }
            navTab.openTab(tabid, url, { title: title, fresh: fresh, external: external });

            event.preventDefault();
        });
    });

    //dialogs
    $("a[target=dialog]", $p).each(function ()
    {
        $(this).click(function (event)
        {
            var $this = $(this);
            var title = $this.attr("title") || $this.text();
            var rel = $this.attr("rel") || "_blank";
            var options = {};
            var w = $this.attr("width");
            var h = $this.attr("height");
            if (w) options.width = w;
            if (h) options.height = h;
            options.max = eval($this.attr("max") || "false");
            options.mask = eval($this.attr("mask") || "false");
            options.maxable = eval($this.attr("maxable") || "true");
            options.minable = eval($this.attr("minable") || "true");
            options.fresh = eval($this.attr("fresh") || "true");
            options.resizable = eval($this.attr("resizable") || "true");
            options.drawable = eval($this.attr("drawable") || "true");
            options.close = eval($this.attr("close") || "");
            options.param = $this.attr("param") || "";

            var url = unescape($this.attr("href")).replaceTmById($(event.target).parents(".unitBox:first"));
            DWZ.debug(url);
            if (!url.isFinishedTm())
            {
                alertMsg.error($this.attr("warn") || DWZ.msg("alertSelectMsg"));
                return false;
            }
            $.pdialog.open(url, rel, title, options);

            return false;
        });
    });
    $("a[target=ajax]", $p).each(function ()
    {
        $(this).click(function (event)
        {
            var $this = $(this);
            var rel = $this.attr("rel");
            if (rel)
            {
                var $rel = $("#" + rel);
                $rel.loadUrl($this.attr("href"), {}, function ()
                {
                    $rel.find("[layoutH]").layoutH();
                });
            }

            event.preventDefault();
        });
    });

    $("div.pagination", $p).each(function ()
    {
        var $this = $(this);
        $this.pagination({
            targetType: $this.attr("targetType"),
            rel: $this.attr("rel"),
            totalCount: $this.attr("totalCount"),
            numPerPage: $this.attr("numPerPage"),
            pageNumShown: $this.attr("pageNumShown"),
            currentPage: $this.attr("currentPage")
        });
    });

    if ($.fn.sortDrag) $("div.sortDrag", $p).sortDrag();

    // dwz.ajax.js
    if ($.fn.ajaxTodo) $("a[target=ajaxTodo]", $p).ajaxTodo();
    if ($.fn.dwzExport) $("a[target=dwzExport]", $p).dwzExport();

    if ($.fn.lookup) $("a[lookupGroup]", $p).lookup();
    if ($.fn.multLookup) $("[multLookup]:button", $p).multLookup();
    if ($.fn.suggest) $("input[suggestFields]", $p).suggest();
    if ($.fn.itemDetail) $("table.itemDetail", $p).itemDetail();
    if ($.fn.selectedTodo) $("a[target=selectedTodo]", $p).selectedTodo();
    if ($.fn.pagerForm) $("form[rel=pagerForm]", $p).pagerForm({ parentBox: $p });

    // 这里放其他第三方jQuery插件...///////////////////////////////////////////////////////////////////
    //2013年9月20日 17:42:26 卢小阳 添加以下调用编辑器插件来实现相关功能的插件，

    //调用编辑组件来实现单张图片上传start
    //调用形式为id="uploadButton-txtPic" class="Pic_Upload_File"
    //其中中的txtPic对应的text文本框名称，class为调用该函数的入口
    if ($("input.Pic_Upload_File", $p).length > 0)
    {
        var editor = KindEditor.editor({ allowFileManager: true });
        $("input.Pic_Upload_File", $p).each(function (i, n)
        {
            var pp = $(n).parent().parent();
            var CName = $(this).attr("name");
            var EventObjId = "#" + $(n).attr("id");
            var param = EventObjId.split("-");
            var Thumbnail;
            var valueObjId = pp.find("#" + param[1]);
            var ImgObjId = pp.find("#" + param[2]);
            var imgWidth = (valueObjId.attr("alt") || 100)//默认图片大小为100px;

            //需要改进：当img不存在的时候，应该能够自动创建img对象
            if (valueObjId.val() != "")
            {
                valueObjId.hide();
                ImgObjId.show();
                ImgObjId.attr("src", valueObjId.val());
                ImgObjId.attr("width", imgWidth);
                Delete_Pic_Upload_File($(n).parent(), $(valueObjId));
            }
            if (CName == "Thumbnail")
            {
                Thumbnail = pp.find("#" + param[3]);
            }

            $(this).click(
			function ()
			{
			    editor.loadPlugin('image',
				function ()
				{
				    editor.plugin.imageDialog(
					{
					    imageUrl: valueObjId.val(),
					    clickFn: function (url, title, width, height, border, align)
					    {
					        valueObjId.val(url) ;
					        valueObjId.hide();
					        ImgObjId.show();
					        ImgObjId.attr("src", url);
					        ImgObjId.attr("width", imgWidth);
					        Delete_Pic_Upload_File($(n).parent(), $(valueObjId));

					        if (CName == "Thumbnail")
					        {
					            Thumbnail.val(thumbnail);
					        }

					        editor.hideDialog();
					    }
					});
				});
			});
        });
    }
    function Delete_Pic_Upload_File(obj, valueObjId)
    {
        $(obj).find("img").unbind("click").click(function ()
        {
            var delImgObj = $(this);
            delImgObj.css("border", "1px solid red");
            if (confirm("您确定要删除此图片的引用吗？"))
            {
                ///删除图片引用
                ///注意：这里和批量删除图片有区别，需要改进,建议在这里都只做引用删除
                delImgObj.attr("src", "");
                delImgObj.hide();
                valueObjId.val("");
                alertMsg.info("删除图片引用成功。");
            }
            delImgObj.css("border", "0px solid red");
        });
    }
    //调用编辑组件来实现单张图片上传end

    //调用编辑组件来实现批量图片上传start
    if ($("input.Pic_Upload_Files", $p).length > 0)
    {
        var editor = KindEditor.editor({ allowFileManager: true });
        $("input.Pic_Upload_Files", $p).each(function (i)
        {
            var EventObjId = "#" + $(this).attr("id");
            var valueObjId = "#" + EventObjId.split("-")[1];
            var ImgPar = $(this).attr("alt").split("|");

            var ImgListDiv = "#" + ImgPar[0];
            var div = $(ImgListDiv);
            var ImgWidth = (ImgPar[1] || 100);
            if ($(valueObjId).val() != "")
            {
                $.each($(valueObjId).val().split(','), function (i, n)
                {
                    div.append('<img src="' + n + '" width="' + ImgWidth + '" title="点击删除图片" alt="点击删除图片" style="margin:2px;" />');
                })
                Delete_Pic_Upload_Files(div, $(valueObjId));
            }
            $(this).click(
			function ()
			{
			    editor.loadPlugin('multiimage',
				function ()
				{
				    editor.plugin.multiImageDialog(
					{
					    imageUrl: $(valueObjId).val(),
					    clickFn: function (urlList)
					    {
					        var Uploaded_Pic_List = "";
					        if (div.find("img").length > 0)
					        {
					            div.find("img").each(
                                function ()
                                {
                                    Uploaded_Pic_List += $(this).attr("src") + ",";
                                });
					        }
					        var Imgs = Uploaded_Pic_List;
					        KindEditor.each(urlList, function (i, data)
					        {
					            div.append('<img src="' + data.url + '" width="' + ImgWidth + '" title="点击删除图片" alt="点击删除图片" style="margin:2px;" />');
					            Imgs += data.url + ",";
					        });
					        Delete_Pic_Upload_Files(div, $(valueObjId));
					        if (Imgs.length > 0)
					            Imgs = Imgs.substring(0, Imgs.length - 1);
					        $(valueObjId).val(Imgs);
					        editor.hideDialog();
					    }
					});
				});
			});
        });
    }

    function Delete_Pic_Upload_Files(obj, valueObjId)
    {
        $(obj).find("img").unbind("click").click(function ()
        {
            var delImgObj = $(this);
            delImgObj.css("border", "1px solid red");
            if (confirm("您确定要删除此图片吗？"))
            {
                $.post("Common/DelPic.ashx", { "url": delImgObj.attr("src") }, function (data)
                {
                    alert(data.statusCode);
                    if (data.statusCode == 200)
                    {
                        delImgObj.remove();
                        var imgSrc = "";
                        $(obj).find("img").each(function ()
                        {
                            imgSrc += $(this).attr("src") + ",";
                        });
                        if (imgSrc.length > 1)
                            imgSrc = imgSrc.substring(0, imgSrc.length - 1);
                        valueObjId.val(imgSrc);
                    }
                    else
                    {
                        alertMsg.error(data.message);
                    }
                }, "json");
            }
            else
                delImgObj.css("border", "0px solid red");
        });
    }
    //调用编辑组件来实现批量图片上传end

    //调用编辑组件来实现单文件上传start
    if ($("input.Upload_File", $p).length > 0)
    {
        var editor = KindEditor.editor({ allowFileManager: true });
        $("input.Upload_File", $p).each(function (i)
        {
            var EventObjId = "#" + $(this).attr("id");
            var valueObjId = "#" + EventObjId.split("-")[1];
            $(this).click(function ()
            {
                editor.loadPlugin('insertfile', function ()
                {
                    editor.plugin.fileDialog({
                        fileUrl: $(valueObjId).val(),
                        clickFn: function (url, title)
                        {
                            $(valueObjId).val(url);
                            editor.hideDialog();
                        }
                    });
                });
            });
        });
    }
    //调用编辑组件来实现批量图片上传end


    //调用编辑组件来实现批量文件上传start
    if ($("input.Upload_Files", $p).length > 0)
    {
        var editor = KindEditor.editor({ allowFileManager: true });
        $("input.Upload_Files", $p).each(function (i)
        {
            var EventObjId = "#" + $(this).attr("id");
            var valueObjId = "#" + EventObjId.split("-")[1];
            $(this).click(function ()
            {
                editor.loadPlugin('insertfile', function ()
                {
                    editor.plugin.fileDialog({
                        fileUrl: $(valueObjId).val(),
                        clickFn: function (url, title)
                        {
                            var oldvalue = $(valueObjId).val();
                            if (oldvalue == "")
                                $(valueObjId).val(url);
                            else
                            {
                                if (("," + oldvalue + ",").indexOf("," + url + ",") == -1)//如果有一样的路径已经存在，则不添加
                                    $(valueObjId).val(oldvalue + "," + url);
                            }
                            editor.hideDialog();
                        }
                    });
                });
            });
        });
    }
    //调用编辑组件来实现批量图片上传end
    //2013年9月20日 17:42:26 卢小阳 添加以上调用编辑器插件来实现相关功能的插件，
    //图片裁剪保存start
    //ratio比例，可不填
    //coordinate 4个坐标点+宽度高度
    window.setTimeout(function ()
    {
        $("img.ImgAreaSelect").each(function ()
        {
            if ($(this).attr("src") == "")
                return false;
            var xx, xx2, yy, yy2, wid, hei;
            var retunobj = "#" + $(this).attr("coordinate");
            var bl = $(this).attr("ratio");
            var retun = $(retunobj).val();
            var w = $(this).height() + 2;
            $(this).parent().parent().css("height", w);
            if (retun != "")
            {
                try
                {
                    var tempxy = retun.split("|");
                    var tempxy1 = tempxy[0].split(",");
                    xx = tempxy1[0];
                    yy = tempxy1[1];
                    tempxy1 = tempxy[1].split(",");
                    xx2 = tempxy1[0];
                    yy2 = tempxy1[1];
                    tempxy1 = tempxy[2].split(",");
                    wid = tempxy1[0];
                    hei = tempxy1[1];
                }
                catch (ex) { }
            }
            $(this).imgAreaSelect({
                handles: true,
                parent: $(this).parent(),
                aspectRatio: (bl == undefined ? "" : bl),
                x1: (xx == undefined ? 0 : xx),
                y1: (yy == undefined ? 0 : yy),
                x2: (xx2 == undefined ? 100 : xx2),
                y2: (yy2 == undefined ? 100 : yy2),
                onSelectEnd: function (img, selection)
                {
                    $(retunobj).val(selection.x1 + "," + selection.y1 + "|" + selection.x2 + "," + selection.y2 + "|" + selection.width + "," + selection.height);
                }
            });
        });
    }, 300);
    //图片裁剪保存end
    //2014年1月7日 10:56 郑赟 添加以上调用编辑器插件来实现相关功能的插件，
}
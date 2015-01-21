$(".cardexplain img").click(function ()
{
    $("body").children().hide();
    var imgsrc = $(this).attr("src");
    newMaskWidth = document.body.scrollWidth;
    newMaskHeight = document.body.scrollHeight;
    $("body").append("<div id=\"OriginImg\" onclick=\"closemasks();\" style=\"position: absolute;z-index:998; background-color: rgb(0, 0, 0);TEXT-ALIGN: center;\"><img id=\"imgsss\" alt=\"tupian\" id=\"guide\" src=\"" + imgsrc + "\"/></div>");
    $("img").load(function ()
    {
        var iw = $(this).width();
        var ih = $(this).height();
        if (iw > newMaskWidth)
            newMaskWidth = iw;
        if (ih > newMaskHeight)
            newMaskHeight = ih;
        $("#OriginImg").css({ width: newMaskWidth, height: newMaskHeight });
    });
});
function closemasks()
{
    $("#OriginImg").remove();
    $("body").children().show();
}
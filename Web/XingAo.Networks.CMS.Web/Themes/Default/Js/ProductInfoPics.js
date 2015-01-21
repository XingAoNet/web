var SmallPicWidth = parseInt(MidPicWidth / 5);
var TotalPicCount = $(".Product_ShowPic_Box .SmallPic li").length;
$(".Product_ShowPic_Box").css({ "width": MidPicWidth + "px", "height": (MidPicHeight + SmallPicHeight) + "px", "overflow": "hidden", "z-index": "999999", "position": "relative" });
$(".Product_ShowPic_Box .MidPic").css({ "margin": "auto", "padding": "0", "list-style": "none" });
$(".Product_ShowPic_Box .MidPic li").css({ "margin": "0", "padding": "0", "float": "left", "height": MidPicHeight + "px", "width": MidPicWidth + "px" });
$(".Product_ShowPic_Box .MidPic img").css({ "height": MidPicHeight + "px", "width": MidPicWidth + "px" });
$(".Product_ShowPic_Box .SmallPic").css({ "margin": MidPicHeight + "px auto auto auto", "padding": "0", "list-style": "none" });
$(".Product_ShowPic_Box .SmallPic li").css({ "margin": "0 1px", "padding": "0", "float": "left", "height": SmallPicHeight + "px", "width": (SmallPicWidth - 2) + "px" });
$(".Product_ShowPic_Box .SmallPic img").css({ "height": (SmallPicHeight - 2) + "px", "width": (SmallPicWidth - 4) + "px", "border": "1px solid " + SmallPicUnSelectColor });
var Product_ShowPic_Box_SmallPic = $(".Product_ShowPic_Box .SmallPic img");
$(".Product_ShowPic_Box .SmallPic li").click(
function ()
{
    var index = $(this).index();
    CurrentMoveIndex = index;
    Product_ShowPic_Box_SmallPic.css({ "height": (SmallPicHeight - 2) + "px", "width": (SmallPicWidth - 4) + "px", "border": "1px solid " + SmallPicUnSelectColor });
    Product_ShowPic_Box_SmallPic.eq(index).css({ "height": (SmallPicHeight - 2) + "px", "width": (SmallPicWidth - 4) + "px", "border": "1px solid " + SmallPicSelectColor });
    $(".Product_ShowPic_Box #MidPicShow").animate({ "left": (0 - MidPicWidth * index) + 'px' }, 300);
});
var CurrentMoveIndex = 1;
if (Product_ShowPic_AutoMove)
{
    var ProductShowPicAutoMovesetInterval;
    ProductShowPicAutoMovesetInterval = setInterval("ProductShowPicAutoMove()", Product_ShowPic_AutoMoveSpeed);
}
function ProductShowPicAutoMove()
{
    var CurrentLiobj = Product_ShowPic_Box_SmallPic.eq(CurrentMoveIndex);
    CurrentLiobj.click();
    Product_ShowPic_Box_SmallPic.css({ "height": (SmallPicHeight - 2) + "px", "width": (SmallPicWidth - 4) + "px", "border": "1px solid " + SmallPicUnSelectColor });
    Product_ShowPic_Box_SmallPic.eq(CurrentMoveIndex).css({ "height": (SmallPicHeight - 2) + "px", "width": (SmallPicWidth - 4) + "px", "border": "1px solid " + SmallPicSelectColor });
    CurrentMoveIndex++;
    if (CurrentMoveIndex >= TotalPicCount)
        CurrentMoveIndex = 0;
}
//CloudZoom
$(document).ready(function ()
{
    $('.cloud-zoom, .cloud-zoom-gallery').CloudZoom(
{
    fadeOutCallback: function ()
    {
        if (ProductShowPicAutoMovesetInterval != undefined && ProductShowPicAutoMovesetInterval != null)
        {
            clearInterval(ProductShowPicAutoMovesetInterval);
        }
        ProductShowPicAutoMovesetInterval = setInterval("ProductShowPicAutoMove()", Product_ShowPic_AutoMoveSpeed);
    },
    fadeInCallback: function ()
    {
        if (ProductShowPicAutoMovesetInterval != undefined && ProductShowPicAutoMovesetInterval != null)
        {
            clearInterval(ProductShowPicAutoMovesetInterval);
        }
    }
});
});
$(".Product_ShowPic_Box .SmallPic li:first").click();
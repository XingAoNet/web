$(function ()
{
    $("#menu > li:last").css("background", "none");
    $('#menu ul').addClass('children'); //所有子菜单
    $('#menu .children').prev('a').addClass('sublink'); //所有子菜单相邻的超级链接，即为子菜单中包含下级菜单的菜单添加一个样式来指示当前菜单还有子菜单

    var menuOver = function ()
    {
        /* 可以针对'出现'定义自己的动画效果 */
        //$("select").css("display","none");
        $(this).children('ul').fadeIn(200); //.show();
    };
    var menuOut = function ()
    {
        /* 可以针对'消失'定义自己的动画效果 */
        //$("select").css("display","");
        $(this).children('ul').fadeOut(200); //.hide();
    };
    $('#menu li').hover(menuOver, menuOut);
});

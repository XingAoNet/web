$(function ()
{
    $("#Shopping_AddCart").click(function ()
    {
        $.post($(this).attr("href"), function (data)
        {
            if (data == "ok")
            {
                alert("添加成功！");
            }
            else
            {
                alert(data);
                window.location = "/UserCenter/UnLogin"
            }
        }, "html");
        return false;
    });
//    $("#Shopping_Buy").click(function ()
//    {
//        $.post($(this).attr("href"), function (data)
//        {
//            if (data == "ok")
//            {
//                alert("添加成功！");
//            }
//            else
//            {
//                alert(data);
//            }
//        }, "html");
//        return false;
//    });
});
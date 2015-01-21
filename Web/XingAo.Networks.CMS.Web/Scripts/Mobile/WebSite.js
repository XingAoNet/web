$(function (ex) {
    $(".plug-div .plug-btn3").click(function () {
        window.scrollTo(0, 0);
        $(".plug-menu span").removeClass("open").addClass("close");
        $(".plug-btn").removeClass("open").addClass("close");
    });

    $("#menu").click(function () {
        var $menulist = $("#menulist");
        $menulist.toggleClass("show");
        if ($("#container").height() < $menulist.height()) {
            $("#container").height($menulist.height());
        }
    });
   
    $(".plug-menu").click(function () {

        var span = $(this).find("span");
        if (span.attr("class") == "open") {
            span.removeClass("open");
            span.addClass("close");
            $(".plug-btn").removeClass("open");
            $(".plug-btn").addClass("close");
        } else {
            span.removeClass("close");
            span.addClass("open");
            $(".plug-btn").removeClass("close");
            $(".plug-btn").addClass("open");
        }
    });
    $(".plug-menu").on('touchmove', function (event) { event.preventDefault(); });

    $("a.menu-item").each(function (i, n) {
        if ($(this).attr("data"))
            $(n).attr("href", getUrl(eval($(this).attr("data")), $(this).attr("_d")));
    });


});

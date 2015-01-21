//var ConfigJson_｛１｝=[｛"StartX":"50","StartY":"60","Step":"1","Delay":"10"｝];
var ConfigJson_{1} = {2};
Init_{1}();
function Init_{1}()
｛
    var html = "<div id='floatAD_{1}' style='position:absolute;left:0px;top:0px;z-index:1000000;cleat:both;'>";
    html += '{0}';
    html += "</div>";
    $('body').append(html);
    var x =parseInt(ConfigJson_{1}[0].StartX), y = parseInt(ConfigJson_{1}[0].StartY);
    var xin = true, yin = true
    var step = ConfigJson_{1}[0].Step;
    var delay =  ConfigJson_{1}[0].Delay;
    var obj = $("#floatAD_{1}");
    function float()
    ｛
        var L = T = 0;
        var OW = obj.width(); //当前广告的宽
        var OH = obj.height(); //高
        var DW = $(document).width(); //浏览器窗口的宽
        var DH = $(document).height();

        x = x + step * (xin ? 1 : -1);
        if (x < L)
        ｛
            xin = true; x = L
        ｝
        if (x > DW - OW - 1)
        ｛//-1为了ie
            xin = false; x = DW - OW - 1
        ｝

        y = y + step * (yin ? 1 : -1);
        if (y > DH - OH - 1)
        ｛

            yin = false; y = DH - OH - 1;
        ｝
        if (y < T)
        ｛
            yin = true; y = T
        ｝

        var left = x;
        var top = y;

        obj.css(｛ 'top': top, 'left': left ｝);
    ｝
    var itl = setInterval(float, delay);
    $(obj).mouseover(function () ｛ clearInterval(itl); ｝);
    $(obj).mouseout(function () ｛ itl = setInterval(float,delay); ｝);
｝
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Mobile.Map" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1.0,user-scalable=no;"/>  
    <style type="text/css">
        body, html, #allmap
        {
            width: 100%;
            height: 100%;
            overflow: hidden;
            margin: 0;
        }
        #l-map
        {
            height: 100%;
            width: 100%;
            float: left;
            border-right: 2px solid #bcbcbc;
        }
       
    </style>
     <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="http://api.map.baidu.com/api?v=1.2" type="text/javascript"></script>
    <script type="text/javascript" src="http://developer.baidu.com/map/jsdemo/demo/convertor.js"></script>
    <title></title>
</head>
<body>
    <div id="l-map"></div>
    <asp:Repeater ID="LocationXY" runat="server">
        <ItemTemplate>
            <input name="xy" type="hidden" value="<%#Eval("Longitude")+","+Eval("Latitude") %>" />
        </ItemTemplate>
    </asp:Repeater>
    <asp:Literal ID="scriptLi" runat="server"></asp:Literal>
    <script type="text/javascript">
        var map = new BMap.Map('l-map');
        map.centerAndZoom("台州", 12);
        map.enableScrollWheelZoom();
        map.clearOverlays();
        var point=new BMap.Point(lx, ly);
        $("input[name=xy]").each(function (i, n) {
            var xy = $(n).val().split(',');
            if (xy.length == 2) {
                var x = parseFloat(xy[0]);
                var y = parseFloat(xy[1]);
                map.addOverlay(new BMap.Marker(new BMap.Point(x, y)));
            }
        });

        translateCallback = function (point) {
            map.setCenter(point);
            var marker = new BMap.Marker(point);
            map.addOverlay(marker);
            var label = new BMap.Label(llabel, { offset: new BMap.Size(20, -10) });
            marker.setLabel(label);
        }

        BMap.Convertor.translate(point, 2, translateCallback);
    </script>
       
</body>
</html>


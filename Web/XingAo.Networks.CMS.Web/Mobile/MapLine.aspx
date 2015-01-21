<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapLine.aspx.cs" Inherits="XingAo.Networks.CMS.Web.Mobile.MapLine" %>

<!DOCTYPE html>
<html>
<head>
     <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
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
    <script type="text/javascript" src="http://developer.baidu.com/map/jsdemo/demo/changeMore.js"></script>
    <title></title>
</head>
<body>
    <div id="l-map"></div>
     <asp:Literal ID="scriptLi" runat="server"></asp:Literal>
    <script type="text/javascript">
        var map = new BMap.Map('l-map');
        map.centerAndZoom("台州", 12);
        map.enableScrollWheelZoom();
        function callback(xyResults)
        {
            var xyResult = null;
            var ps = new Array();
            for (var index in xyResults)
            {
                xyResult = xyResults[index];
                if (xyResult.error != 0) { continue; }
                ps[index] = new BMap.Point(xyResult.x, xyResult.y);
            }
            var driving = new BMap.DrivingRoute(map, { renderOptions: { map: map, autoViewport: true} });
            driving.search(ps[0], new BMap.Point(ex, ey));
        }

        if (sx != undefined)
        {
            var p1 = new BMap.Point(sx, sy);
            var p2 = new BMap.Point(ex, ey);
            var points = [p1, p2];
            BMap.Convertor.transMore(points, 2, callback);

        }
    </script>
</body>
</html>

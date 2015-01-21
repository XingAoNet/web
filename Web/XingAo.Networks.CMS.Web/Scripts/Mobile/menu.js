function getUrl(config,wxid) {
    var url = "#";
    var source = config.source;
    var InfoID = config.InfoID;
    var Guid = config.Guid;
    var title = config.Title;
    switch (config.ShowType.toLocaleLowerCase())
    {

        case "list": //列表
            if (source == "ImageMaterial")//图文
                url = "/Mobile/Website/Info_ImgList.aspx?ChannelId=" + InfoID + "&wxid=" + wxid + "&title=";
            if (source == "Activities")//活动
                url = "/Mobile/Registration/RegistrationList.aspx?ParentID=" + InfoID + "&wxid=" + wxid + "&title=" + title;
            if (source == "BigWheel")//大转盘
                url = "/Mobile/BigWheels/BigWheelList.aspx?ParentID=" + InfoID + "&wxid=" + wxid + "&title=" + title;
            if (source == "ScratchCard")//刮刮卡
                url = "/Mobile/ScratchCard/default.aspx?ParentID=" + InfoID + "&wxid=" + wxid + "&title=" + title;
            break;
        case "info": //详细
            if (source == "TextMaterial")//文本
                url = "/Mobile/ShowTxt.aspx?id=" + InfoID + "&wxid=" + wxid + "&title=" + title;
            if (source == "ImageMaterial")//图文
                url = "/Mobile/Website/Info_Img.aspx?id=" + InfoID + "&wxid=" + wxid + "&title=" + title;
            if (source == "Activities")//活动
                url = "/Mobile/Registration/RegistrationHead.aspx?Openid=reg&AGuid=" + Guid + "&wxid=" + wxid + "&title=" + title;
            if (source == "BigWheel")//大转盘
                url = "/Mobile/BigWheels/BigWheel.aspx?Openid=bg&BGuid=" + Guid + "&wxid=" + wxid + "&title=" + title;
            if (source == "ScratchCard")//刮刮卡
                url = "/Mobile/ScratchCard/Card.aspx?Openid=sc&SGuid=" + Guid + "&wxid=" + wxid + "&title=" + title;
            break;
        case "custom": //自定义
            url = "#";
            break;
    }
    return url;
}